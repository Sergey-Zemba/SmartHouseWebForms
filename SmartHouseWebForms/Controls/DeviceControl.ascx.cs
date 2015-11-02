using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHouseWebForms.SmartHouse.Devices;
using SmartHouseWebForms.SmartHouse.Interfaces;

namespace SmartHouseWebForms.Controls
{
    public partial class DeviceControl : System.Web.UI.UserControl
    {
        private Button button3, button4;
        public DeviceControl(Device device)
        {
            Device = device;
        }

        public Device Device { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void button3_Click(object sender, EventArgs e)
        {
            if (((Button) sender).Text == "Bass On")
            {
                (Device as IBass).BassOn();
            }
        }
        protected void button4_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "Bass Off")
            {
                (Device as IBass).BassOn();
            }
        }
    }
}