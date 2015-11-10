using System;
using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]

    class PanasonicStereoSystem : StereoSystem, IBass
    {

        public PanasonicStereoSystem(int id, PanasonicLoudspeakers p)
            : base(id, p)
        {

        }

        public BassState BassState
        {
            get
            {
                PanasonicLoudspeakers panasonicLoudspeakers = Loudspeakers as PanasonicLoudspeakers;
                return panasonicLoudspeakers.BassState;
            }
        }

        public void BassOn()
        {
            PanasonicLoudspeakers panasonicLoudspeakers = Loudspeakers as PanasonicLoudspeakers;
            if (panasonicLoudspeakers != null)
            {
                panasonicLoudspeakers.BassOn();
            }
        }

        public void BassOff()
        {
            PanasonicLoudspeakers panasonicLoudspeakers = Loudspeakers as PanasonicLoudspeakers;
            if (panasonicLoudspeakers != null)
            {
                panasonicLoudspeakers.BassOff();
            }
        }
    }
}
