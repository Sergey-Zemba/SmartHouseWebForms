using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Interfaces
{
    public interface IVolumeable
    {
        int CurrentVolume { get; }
        MuteState MuteState { get; }
        void AddVolume();
        void DecreaseVolume();
        void MuteOn();
        void MuteOff();
    }
}
