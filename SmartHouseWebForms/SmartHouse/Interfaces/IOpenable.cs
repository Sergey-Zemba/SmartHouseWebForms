using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Interfaces
{
    public interface IOpenable
    {
        OpenState OpenState { get; }
        void Open();
        void Close();


    }
}
