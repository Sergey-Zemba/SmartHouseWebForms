using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    public class Camera : Device, IRecording
    {
        private RecordMode _recordMode;
        public Camera(int id)
            : base(id)
        {
        }

        public RecordMode RecordMode
        {
            get
            {
                return _recordMode;
            }
        }

        public void StartRecording()
        {
            _recordMode = RecordMode.Record;
        }

        public void StopRecording()
        {
            _recordMode = RecordMode.Live;
        }

        public override string ToString()
        {
            string str = base.ToString();
            if (_recordMode == RecordMode.Record)
            {
                str += " rec";
            }
            return str;
        }

        
    }
}
