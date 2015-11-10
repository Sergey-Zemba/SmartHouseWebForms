using System;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]

    class SamsungHomeCinema : HomeCinema
    {
        public SamsungHomeCinema(int id, SamsungTv t, SamsungLoudspeakers l)
            : base(id, t, l)
        {

        }
    }
}
