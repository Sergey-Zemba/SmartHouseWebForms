using System;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]

    class SamsungHomeCinema : HomeCinema
    {
        public SamsungHomeCinema(int id, SamsungTv t, SamsungStereoSystem s)
            : base(id, t, s)
        {

        }
    }
}
