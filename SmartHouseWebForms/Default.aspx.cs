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
            if (!IsPostBack)
            {
                Dictionary<string, Device> devices = new Dictionary<string, Device>();
                Session["devices"] = devices;
            }
            else
            {
                Button2 = new Button();
                Button2.ID = UniqueID;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, Device> devices = (Dictionary<string, Device>) Session["devices"];
            devices.Add(Button2.ID, new PanasonicLoudspeakers());
            Session["devices"] = devices;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Dictionary<string, Device> devices = (Dictionary<string, Device>)Session["devices"];
            devices.Remove(Button2.ID);
            Session["devices"] = devices;
        }

    }
}