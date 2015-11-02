using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHouseWebForms.Controls;
using SmartHouseWebForms.SmartHouse.Devices;

namespace SmartHouseWebForms
{
    public partial class Default : System.Web.UI.Page
    {
        private static int _index = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DeviceControl control = new DeviceControl();
            Session.Add(_index.ToString(), control);
            _index++;
        }

    }
}