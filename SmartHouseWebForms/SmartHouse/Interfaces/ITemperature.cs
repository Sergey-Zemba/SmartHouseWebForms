namespace SmartHouseWebForms.SmartHouse.Interfaces
{
    public interface ITemperature
    {
        int CurrentTemperature { get; }
        void AddTemperture();
        void DecreaseTemperature();
    }
}
