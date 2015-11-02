using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHouseWebForms.SmartHouse.Devices;
using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.Controls
{
    public partial class DeviceControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Device device = new PanasonicLoudspeakers();
                Session["loud"] = device;
                Label1.Text = (device as PanasonicLoudspeakers).ToString();
            }
            else
            {
                Device device = (Device)Session["loud"];
                if (device is IBass)
                {
                    Button3.Visible = true;
                }
                Label1.Text = (device as PanasonicLoudspeakers).ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Device device = (Device)Session["loud"];
            if (device.SwitchState == SwitchState.On)
            {
                device.Off();
            }
            else
            {
                device.On();
            }
            Label1.Text = (device as PanasonicLoudspeakers).ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Device device = (Device)Session["loud"];
            if ((device as IBass).BassState == BassState.Off)
            {
                (device as IBass).BassOn();
            }
            else
            {
                (device as IBass).BassOff();
            }
            Label1.Text = (device as PanasonicLoudspeakers).ToString();
        }

    }
}