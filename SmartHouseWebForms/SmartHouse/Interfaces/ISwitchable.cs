using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Interfaces
{
    interface ISwitchable
    {
        SwitchState SwitchState { get; }
        void On();
        void Off();
    }
}
