using SmartHouseWebForms.SmartHouse.Interfaces;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    abstract class HomeCinema : Device, IVolumeable
    {
        public HomeCinema(Tv tv, StereoSystem stereoSystem)
        {
            Tv = tv;
            StereoSystem = stereoSystem;
        }
        public Tv Tv { get; set; }
        public StereoSystem StereoSystem { get; set; }

        public virtual void AddVolume()
        {
            Tv.AddVolume();
            StereoSystem.AddVolume();
        }

        public void DecreaseVolume()
        {
            Tv.DecreaseVolume();
            StereoSystem.DecreaseVolume();
        }

        public void Mute()
        {
            Tv.Mute();
            StereoSystem.Mute();
        }
        public override void On()
        {
            base.On();
            Tv.On();
            StereoSystem.On();
        }

        public override void Off()
        {
            base.Off();
            Tv.Off();
            StereoSystem.Off();
        }

        public override string ToString()
        {
            string str = base.ToString();
            str += "\t" + Tv + "\t" + StereoSystem;
            return str;
        }
    }
}
