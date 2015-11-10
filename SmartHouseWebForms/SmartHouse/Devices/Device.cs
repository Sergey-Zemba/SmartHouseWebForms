using System;
using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]
    
    public abstract class Device : ISwitchable
    {
        private int _id;
        private SwitchState _switchState;

        public Device(int id)
        {
            _id = id;
        }

        public int Id { get { return _id; }}
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
            if (SwitchState == SwitchState.On)
            {
                if (this is IBass)
                {
                    if ((this as IBass).BassState == BassState.On)
                    {
                        str += " Bass";
                    }
                }
                if (this is IOpenable)
                {
                    IOpenable openable = this as IOpenable;
                    if (openable != null)
                    {
                        str += " and " + openable.OpenState;
                    }
                }
                if (this is IRecording)
                {
                    if ((this as IRecording).RecordMode == RecordMode.Record)
                    {
                        str += " REC";
                    }
                }
                if (this is ITemperature)
                {
                    str += " Current temperature " + (this as ITemperature).CurrentTemperature + "°C";
                }
                if (this is IThreeDimensional)
                {
                    if ((this as IThreeDimensional).Mode == TvMode.ThreeDMode)
                    {
                        str += " 3D";
                    }
                }
                if (this is IVolumeable)
                {
                    str += " Volume " + (this as IVolumeable).CurrentVolume;
                }
            }
            return str;
        }
    }
}
