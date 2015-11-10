using System;
using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]

    abstract class HomeCinema : Device, IVolumeable, IRecording
    {

        public HomeCinema(int id, Tv tv, Loudspeakers loudspeakers) : base(id)
        {
            Tv = tv;
            Loudspeakers = loudspeakers;
        }
        public Tv Tv { get; set; }
        public Loudspeakers Loudspeakers { get; set; }
        public RecordMode RecordMode { get { return Tv.RecordMode; } }
        public int CurrentVolume { get { return Loudspeakers.CurrentVolume; } }
        public virtual void AddVolume()
        {
            Tv.AddVolume();
            Loudspeakers.AddVolume();
        }

        public void DecreaseVolume()
        {
            Tv.DecreaseVolume();
            Loudspeakers.DecreaseVolume();
        }

        public void Mute()
        {
            Tv.Mute();
            Loudspeakers.Mute();
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
            Loudspeakers.On();
        }

        public override void Off()
        {
            base.Off();
            Tv.Off();
            Loudspeakers.Off();
        }
    }
}
