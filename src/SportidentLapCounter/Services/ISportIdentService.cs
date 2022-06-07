using SPORTident;
using SPORTident.Communication.UsbDevice;
using System;
using System.Collections.Generic;

namespace SportidentLapCounter.Services
{
    public interface ISportIdentService
    {
        event EventHandler<CardPunchData> RadioPunch;
        event EventHandler<SportidentCard> CardReadout;

        List<DeviceInfo> GetAllDevices();
        void Connect(DeviceInfo deviceInfo);
        void Disconnect(DeviceInfo deviceInfo);
    }
}
