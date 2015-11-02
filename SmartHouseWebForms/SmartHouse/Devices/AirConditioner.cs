﻿using SmartHouseWebForms.SmartHouse.Interfaces;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    class AirConditioner : Device, ITemperature
    {
        private int _temperature;

        public AirConditioner()
        {
            _temperature = 18;
        }
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

        public override string ToString()
        {
            string str = base.ToString();
            str += " Current temperature: " + _temperature;
            return str;
        }
    }
}