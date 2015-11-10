using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using SmartHouseWebForms.SmartHouse.Devices;

namespace SmartHouseWebForms.Model
{
    public class XmlReadingWriting : IReadingWriting
    {
        private BinaryFormatter formatter = new BinaryFormatter();


        public List<Device> Read()
        {
            List<Device> devices;
            using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/Devices.dat"), FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    devices = (List<Device>)formatter.Deserialize(fs);
                }
                else
                {
                    devices = new List<Device>();
                }
            }
            return devices;
        }

        public void Write(List<Device> devices)
        {
            using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/Devices.dat"), FileMode.Open))
            {
                formatter.Serialize(fs, devices);
            }
        }
    }
}