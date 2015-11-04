using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    abstract class Tv : Device, IVolumeable, IRecording
    {
        private int _volume;
        private RecordMode _recordMode;
        public Tv(int id)
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

        public virtual void StartRecording()
        {
            _recordMode = RecordMode.Record;
        }

        public virtual void StopRecording()
        {
            _recordMode = RecordMode.Live;
        }
        public override string ToString()
        {
            string str = base.ToString();
            str += " volume = " + _volume;
            if (_recordMode == RecordMode.Record)
            {
                str += " rec";
            }
            return str;
        }

        
    }
}
