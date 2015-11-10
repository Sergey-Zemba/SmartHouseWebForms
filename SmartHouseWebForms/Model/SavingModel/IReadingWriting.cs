using System.Collections.Generic;
using SmartHouseWebForms.SmartHouse.Devices;

namespace SmartHouseWebForms.Model.SavingModel
{
    interface IReadingWriting
    {
        List<Device> Read();
        void Write(List<Device> devices);
        int MakeId();
    }
}
