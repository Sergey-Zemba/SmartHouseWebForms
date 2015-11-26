using System;
using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]

    abstract class Tv : Device, IVolumeable, IRecording
    {
        private int _volume;
        private int _prevVolume;
        private MuteState _muteState;
        private RecordMode _recordMode;
        public Tv(int id)
            : base(id)
        {
        }

        public RecordMode RecordMode { get { return _recordMode; } }
        public int CurrentVolume { get { return _volume; } }
        public MuteState MuteState { get { return _muteState; } }

        public virtual void AddVolume()
        {
            if (MuteState == MuteState.MuteOn)
            {
                MuteOff();
                _volume = _prevVolume;
            }
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
            if (MuteState == MuteState.MuteOn)
            {
                MuteOff();
                _volume = _prevVolume;
            }
            if (_volume > 0)
            {
                _volume--;
            }
            else
            {
                _volume = 0;
            }
        }
        public virtual void MuteOn()
        {
            _prevVolume = CurrentVolume;
            _volume = 0;
            _muteState = MuteState.MuteOn;
        }

        public virtual void MuteOff()
        {
            _volume = _prevVolume;
            _muteState = MuteState.MuteOff;
        }

        public virtual void StartRecording()
        {
            _recordMode = RecordMode.Record;
        }

        public virtual void StopRecording()
        {
            _recordMode = RecordMode.Live;
        }
    }
}
