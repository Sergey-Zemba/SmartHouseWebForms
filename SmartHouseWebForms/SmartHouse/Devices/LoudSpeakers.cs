using System;
using SmartHouseWebForms.SmartHouse.Interfaces;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]

    abstract class Loudspeakers : Device, IVolumeable
    {
        private int _volume;
        public Loudspeakers(int id)
            : base(id)
        {
        }

        public virtual void AddVolume()
        {
            if (_volume < 100)
            {
                _volume++;
            }
            else
            {
                _volume = 100;
            }
        }

        public virtual void DecreaseVolume()
        {
            if (_volume > 0)
            {
                _volume--;
            }
            else
            {
                _volume = 0;
            }
        }

        public virtual void Mute()
        {
            _volume = 0;
        }

        public override string ToString()
        {
            string str = base.ToString();
            str += " volume = " + _volume;
            return str;
        }

        
    }
}
