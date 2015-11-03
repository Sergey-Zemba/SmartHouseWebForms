using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Interfaces
{
    public interface IBass
    {
        BassState BassState { get; }
        void BassOn();
        void BassOff();
    }
}
