using SmartHouseWebForms.SmartHouse.Interfaces;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    class PanasonicStereoSystem : StereoSystem
    {
        public PanasonicStereoSystem(int id, PanasonicLoudspeakers p)
            : base(id, p)
        {

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
