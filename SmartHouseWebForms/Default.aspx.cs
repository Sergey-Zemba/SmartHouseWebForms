using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHouseWebForms.Controls;
using SmartHouseWebForms.SmartHouse.Devices;
using SmartHouseWebForms.SmartHouse.Interfaces;

namespace SmartHouseWebForms
{


    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Device> devices = new List<Device>();
                Session["devices"] = devices;
            }
            else
            {
                List<Device> devices = (List<Device>)Session["devices"];
                Repeater1.DataSource = devices;
                Repeater1.DataBind();
                Session["devices"] = devices;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Device> devices = (List<Device>) Session["devices"];
            devices.Add(new PanasonicLoudspeakers(devices.Count));
            Repeater1.DataSource = devices;
            Repeater1.DataBind();
            Session["devices"] = devices;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            List<Device> devices = (List<Device>)Session["devices"];
            devices.Add(new SamsungLoudspeakers(devices.Count));
            Repeater1.DataSource = devices;
            Repeater1.DataBind();
            Session["devices"] = devices;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Device> devices = (List<Device>)Session["devices"];
            devices.Add(new Camera(devices.Count));
            Repeater1.DataSource = devices;
            Repeater1.DataBind();
            Session["devices"] = devices;
        }

        
    }
}