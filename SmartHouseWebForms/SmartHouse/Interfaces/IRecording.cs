using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Interfaces
{
    public interface IRecording
    {
        RecordMode RecordMode { get; }
        void StartRecording();
        void StopRecording();
    }
}
