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
        private SmartHouse.SmartHouse _house = new SmartHouse.SmartHouse();
        private static int _index = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(form1.Controls.Count);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            AirConditioner conditioner = new AirConditioner();
            _house.AddDevice(conditioner);
            form1.Controls.AddAt(_index, new AirConditionerControl(conditioner));
            _index++;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Camera camera = new Camera();
            _house.AddDevice(camera);
            form1.Controls.AddAt(_index, new CameraControl(camera));
            _index++;
        }
    }
}