using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    class Garage : Device, IOpenable
    {
        private OpenState _openState;
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


    }
}
