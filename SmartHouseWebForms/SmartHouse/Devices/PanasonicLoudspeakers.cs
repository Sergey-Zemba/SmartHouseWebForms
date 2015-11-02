using SmartHouseWebForms.SmartHouse.Interfaces;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    class PanasonicLoudspeakers : Loudspeakers, IBass
    {
        private bool _bass;


        public void BassOn()
        {
            _bass = true;
        }

        public void BassOff()
        {
            _bass = false;
        }
        public override string ToString()
        {
            string str = base.ToString();
            if (_bass)
            {
                str += " Bass is on";
            }
            else
            {
                str += " Bass is off";
            }
            return str;
        }
    }
}
