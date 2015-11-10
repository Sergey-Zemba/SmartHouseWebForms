using System;
using SmartHouseWebForms.SmartHouse.Interfaces;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]

    abstract class StereoSystem : Device, IVolumeable
    {
        public StereoSystem(int id, Loudspeakers loudspeakers) : base(id)
        {
            Loudspeakers = loudspeakers;
        }
        public Loudspeakers Loudspeakers { get; set; }

        public virtual void AddVolume()
        {
            Loudspeakers.AddVolume();
        }

        public virtual void DecreaseVolume()
        {
            Loudspeakers.DecreaseVolume();
        }

        public virtual void Mute()
        {
            Loudspeakers.Mute();
        }

        public override void On()
        {
            base.On();
            Loudspeakers.On();
        }

        public override void Off()
        {
            base.Off();
            Loudspeakers.Off();
        }

        public override string ToString()
        {
            string str = base.ToString();
            str += "\t" + Loudspeakers;
            return str;
        }
    }
}
