using System;
using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]

    class PanasonicLoudspeakers : Loudspeakers, IBass
    {
        private BassState _bassState;
        public PanasonicLoudspeakers(int id)
            : base(id)
        {
        }
        public BassState BassState
        {
            get
            {
                return _bassState;
            }

        }
        public void BassOn()
        {
            _bassState = BassState.On;
        }

        public void BassOff()
        {
            _bassState = BassState.Off;
        }
        public override string ToString()
        {
            string str = base.ToString();
            if (BassState == BassState.On)
            {
                str += " Bass is on";
            }
            return str;
        }

        
    }
}
