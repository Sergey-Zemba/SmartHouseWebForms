using System;
using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]

    abstract class HomeCinema : Device, IVolumeable, IRecording
    {

        public HomeCinema(int id, Tv tv, StereoSystem stereoSystem) : base(id)
        {
            Tv = tv;
            StereoSystem = stereoSystem;
        }
        public Tv Tv { get; set; }
        public StereoSystem StereoSystem { get; set; }
        public RecordMode RecordMode { get { return Tv.RecordMode; } }
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

        public virtual void StartRecording()
        {
            Tv.StartRecording();
        }

        public virtual void StopRecording()
        {
            Tv.StopRecording();
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
