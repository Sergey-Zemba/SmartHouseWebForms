using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Web;
using System.Xml.Serialization;
using SmartHouseWebForms.SmartHouse.Devices;

namespace SmartHouseWebForms
{
    public class XmlReadingWriting : IReadingWriting
    {
        private BinaryFormatter formatter = new BinaryFormatter();


        public List<Device> Read()
        {
            List<Device> devices;
            using (FileStream fs = new FileStream(@"C:\Users\Sergey\Source\Repos\SmartHouseWebForms\SmartHouseWebForms\Devices.dat", FileMode.OpenOrCreate))
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
            using (FileStream fs = new FileStream(@"C:\Users\Sergey\Source\Repos\SmartHouseWebForms\SmartHouseWebForms\Devices.dat", FileMode.Open))
            {
                formatter.Serialize(fs, devices);
            }
        }
    }
}