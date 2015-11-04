using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    class PanasonicHomeCinema : HomeCinema
    {
        public PanasonicHomeCinema(int id, PanasonicTv t, PanasonicStereoSystem s)
            : base(id, t, s)
        {

        }

        public void BassOn()
        {
            PanasonicStereoSystem panasonicStereoSystem = StereoSystem as PanasonicStereoSystem;
            if (panasonicStereoSystem != null)
            {
                panasonicStereoSystem.BassOn();
            }
        }

        public void BassOff()
        {
            PanasonicStereoSystem panasonicStereoSystem = StereoSystem as PanasonicStereoSystem;
            if (panasonicStereoSystem != null)
            {
                panasonicStereoSystem.BassOff();
            }
        }

        public void ThreeDOn()
        {
            PanasonicTv panasonicTv = Tv as PanasonicTv;
            if (panasonicTv != null)
            {
                panasonicTv.ThreeDOn();
            }
        }

        public void ThreeDOff()
        {
            PanasonicTv panasonicTv = Tv as PanasonicTv;
            if (panasonicTv != null)
            {
                panasonicTv.ThreeDOff();
            }
        }
    }
}
