using System;
using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]
    class Garage : Device, IOpenable
    {
        private OpenState _openState;
        public Garage(int id)
            : base(id)
        {
        }
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
