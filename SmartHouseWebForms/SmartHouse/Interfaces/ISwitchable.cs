using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Interfaces
{
    public interface ISwitchable
    {
        SwitchState SwitchState { get; }
        void On();
        void Off();
    }
}
