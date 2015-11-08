using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Interfaces
{
    public interface IThreeDimensional
    {
        TvMode Mode { get; }
        void ThreeDOn();
        void ThreeDOff();
    }
}
