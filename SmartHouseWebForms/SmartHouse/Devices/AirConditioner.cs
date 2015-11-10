using System;
using SmartHouseWebForms.SmartHouse.Interfaces;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]
    public class AirConditioner : Device, ITemperature
    {
        private int _temperature;

        public AirConditioner(int id) : base(id)
        {
            _temperature = 18;
        }

        public int CurrentTemperature { get { return _temperature; } }
        public void AddTemperture()
        {
            if (_temperature < 25)
            {
                _temperature++;
            }
            else
            {
                _temperature = 25;
            }

        }

        public void DecreaseTemperature()
        {
            if (_temperature > 16)
            {
                _temperature--;
            }
            else
            {
                _temperature = 16;
            }
        }
    }
}
