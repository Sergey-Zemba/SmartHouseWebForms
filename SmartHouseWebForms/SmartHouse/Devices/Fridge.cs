using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    class Fridge : Device, IOpenable, ITemperature
    {
        private OpenState _openState;
        private int _temperature;

        public OpenState OpenState
        {
            get
            {
                return _openState;
            }

        }

        public void Open()
        {

            _openState = OpenState.Open;

        }

        public void Close()
        {
            _openState = OpenState.Close;
        }
        public void AddTemperture()
        {
            if (_temperature < 5)
            {
                _temperature++;
            }
            else
            {
                _temperature = 5;
            }

        }

        public void DecreaseTemperature()
        {
            if (_temperature > -5)
            {
                _temperature--;
            }
            else
            {
                _temperature = -5;
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
