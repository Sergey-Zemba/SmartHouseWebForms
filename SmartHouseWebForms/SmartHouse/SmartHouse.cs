using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SmartHouseWebForms.SmartHouse.Devices;

namespace SmartHouseWebForms.SmartHouse
{
    public class SmartHouse
    {
        private static int _key;
        private IDictionary<int, Device> _devices = new Dictionary<int, Device>();

        public void AddDevice(Device device)
        {
            _devices.Add(_key, device);
            _key++;
        }

        public void RemoveDevice(int key)
        {
            _devices.Remove(key);
        }

        public Device GetDevice(int key)
        {
            return _devices[key];
        }
    }
}