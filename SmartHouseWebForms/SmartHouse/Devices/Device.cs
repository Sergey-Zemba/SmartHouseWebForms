using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    public abstract class Device : ISwitchable
    {
        private SwitchState _switchState;
        public SwitchState SwitchState
        {
            get
            {
                return _switchState;
            }

        }

        public virtual void On()
        {
            _switchState = SwitchState.On;
        }

        public virtual void Off()
        {
            _switchState = SwitchState.Off;
        }

        public override string ToString()
        {
            string str = GetType().Name + " is " + SwitchState;
            if (this is IOpenable)
            {
                IOpenable openable = this as IOpenable;
                if (openable != null)
                {
                    str += " and " + openable.OpenState;
                }
            }
            return str;
        }
    }
}
