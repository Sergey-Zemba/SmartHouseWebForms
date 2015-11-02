using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Interfaces
{
    interface IOpenable
    {
        OpenState OpenState { get; }
        void Open();
        void Close();


    }
}
