using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using SmartHouseWebForms.SmartHouse.Devices;

namespace SmartHouseWebForms.Model.SavingModel
{
    public class BinaryReadingWriting : IReadingWriting
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
        public int MakeId()
        {
            int id;
            using (FileStream fs = new FileStream(HttpContext.Current.Server.MapPath("~/ID.dat"), FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    id = (int)formatter.Deserialize(fs);
                }
                else
                {
                    id = 0;
                }
            }
            using (
                FileStream fs =
                    new FileStream(HttpContext.Current.Server.MapPath("~/ID.dat"),
                        FileMode.Open))
            {

                id++;
                formatter.Serialize(fs, id);
            }
            return id;
        }
    }
}