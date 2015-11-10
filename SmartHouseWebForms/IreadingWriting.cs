using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHouseWebForms.SmartHouse.Devices;

namespace SmartHouseWebForms
{
    interface IReadingWriting
    {
        List<Device> Read();
        void Write(List<Device> devices);
    }
}
