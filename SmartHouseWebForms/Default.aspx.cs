using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHouseWebForms.ServerControls;
using SmartHouseWebForms.SmartHouse.Devices;

namespace SmartHouseWebForms
{
    public partial class Default : System.Web.UI.Page
    {
        private SmartHouse.SmartHouse _house;
        protected void Page_Load(object sender, EventArgs e)
        {
            _house = new SmartHouse.SmartHouse();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            _house.AddDevice(new AirConditioner());
            form1.Controls.Add(new AirConditionerContol());
        }
    }
}