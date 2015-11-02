using SmartHouseWebForms.SmartHouse.Interfaces;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    class PanasonicHomeCinema : HomeCinema, IBass, IThreeDimensional
    {
        public PanasonicHomeCinema(PanasonicTv t, PanasonicStereoSystem s)
            : base(t, s)
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
