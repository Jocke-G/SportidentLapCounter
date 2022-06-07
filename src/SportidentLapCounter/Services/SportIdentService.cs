using SPORTident;
using SPORTident.Communication;
using SPORTident.Communication.UsbDevice;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportidentLapCounter.Services
{
    public class SportIdentService: ISportIdentService
    {
        private readonly List<Communication> _connectedDevices;

        public event EventHandler<CardPunchData> RadioPunch;
        public event EventHandler<SportidentCard> CardReadout;

        public SportIdentService()
        {
            _connectedDevices = new List<Communication>();
        }

        public List<DeviceInfo> GetAllDevices()
        {
            return DeviceInfo.GetAvailableDeviceList(true, (int)DeviceType.Serial | (int)DeviceType.UsbHid)
                .Where(device => device.DeviceFamily != null)
                .ToList();
        }

        public void Connect(DeviceInfo deviceInfo)
        {
            var device = new Communication
            {
                DeviceConnection = deviceInfo,
            };
            device.TriggerPunchReceived += OnTriggerPunchReceived;
            device.SiCardReadCompleted += OnSiCardReadCompleted;
            device.CardsReadMode = CardsReadMode.ReadCards;
            device.Open();

            _connectedDevices.Add(device);
        }

        public void Disconnect(DeviceInfo deviceInfo)
        {
            var device = _connectedDevices.FirstOrDefault(x => x.DeviceConnection == deviceInfo);
            if (device == null)
            {
                return;
            }

            device.TriggerPunchReceived -= OnTriggerPunchReceived;
            device.SiCardReadCompleted -= OnSiCardReadCompleted;
            device.Close();
            _connectedDevices.Remove(device);
        }

        private void OnTriggerPunchReceived(object sender, SportidentDataEventArgs e)
        {
            if (!e.HasPunchData)
            {
                return;
            }

            foreach (var punchData in e.PunchData)
            {
                RadioPunch.Invoke(sender, punchData);
            }
        }

        private void OnSiCardReadCompleted(object sender, SportidentDataEventArgs e)
        {
            if (!e.HasCards)
            {
                return;
            }

            foreach (var card in e.Cards)
            {
                CardReadout.Invoke(sender, card);
            }
        }
    }
}
