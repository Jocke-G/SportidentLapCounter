using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using SportidentLapCounter.Controls.MainForm;

namespace SportidentLapCounter.Services
{
    public class PersistenceService
    {
        private const string XmlPath = "database.xml";

        public MainFormModel Load()
        {
            if (!File.Exists(XmlPath))
                return new MainFormModel();

            try
            {
                using (var file = new StreamReader(XmlPath))
                {
                    var serializer = new XmlSerializer(typeof(MainFormModel));
                    var obj = serializer.Deserialize(file);
                    var model = obj as MainFormModel;
                    if (model == null)
                        return new MainFormModel();

                    file.Close();
                    return model;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new MainFormModel();
            }
        }

        public void Save(MainFormModel model)
        {
            using (var streamWriter = new StreamWriter(XmlPath))
            {
                var xmlSerializer = new XmlSerializer(typeof(MainFormModel));
                xmlSerializer.Serialize(streamWriter, model);
                streamWriter.Close();
            }
        }
    }
}
