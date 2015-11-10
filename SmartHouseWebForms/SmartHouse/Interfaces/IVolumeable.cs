namespace SmartHouseWebForms.SmartHouse.Interfaces
{
    public interface IVolumeable
    {
        int CurrentVolume { get; }
        void AddVolume();
        void DecreaseVolume();
        void Mute();
    }
}
