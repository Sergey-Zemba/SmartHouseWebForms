using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Interfaces
{
    interface IBass
    {
        BassState BassState { get; }
        void BassOn();
        void BassOff();
    }
}
