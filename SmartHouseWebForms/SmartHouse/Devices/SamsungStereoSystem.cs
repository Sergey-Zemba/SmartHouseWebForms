using System;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]

    class SamsungStereoSystem : StereoSystem
    {
        public SamsungStereoSystem(int id, SamsungLoudspeakers s)
            : base(id, s)
        {

        }
    }
}
