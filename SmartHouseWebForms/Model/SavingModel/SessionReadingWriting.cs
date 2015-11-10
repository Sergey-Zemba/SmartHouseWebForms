using System.Collections.Generic;
using System.Web;
using SmartHouseWebForms.SmartHouse.Devices;

namespace SmartHouseWebForms.Model.SavingModel
{
    public class SessionReadingWriting : IReadingWriting
    {
        public List<Device> Read()
        {
            List<Device> devices;
            if (HttpContext.Current.Session["devices"] != null)
            {
                devices = (List<Device>) HttpContext.Current.Session["devices"];
            }
            else
            {
                devices = new List<Device>();
            }
            return devices;
        }

        public void Write(List<Device> devices)
        {
            HttpContext.Current.Session["devices"] = devices;
        }
        public int MakeId()
        {
            int id;
            if (HttpContext.Current.Session["id"] != null)
            {
                id = (int)HttpContext.Current.Session["id"];
            }
            else
            {
                id = 0;
            }
            id++;
            HttpContext.Current.Session["id"] = id;
            return id;
        }
    }
}