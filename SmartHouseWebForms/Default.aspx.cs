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
        }



        protected void OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                var h = (HiddenField)e.Item.FindControl("hid");
                var id = Int32.Parse(h.Value);
                List<Device> devices = ((List<Device>)Session["devices"]);
                var device = devices.Single(x => x.Id == id);
                devices.Remove(device);
                Repeater1.DataSource = devices;
                Repeater1.DataBind();
                Session["devices"] = devices;
            }
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var device = (Device)e.Item.DataItem;
                PlaceHolder p = e.Item.FindControl("plcHolder") as PlaceHolder;
                if (device is IRecording)
                {
                    Label l = new Label();
                    l.Text = device.ToString();
                    p.Controls.Add(l);
                }
                else if (device is IBass)
                {
                    Button b = new Button();
                    b.Text = "Bass";
                    p.Controls.Add(b);
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Device> devices = ((List<Device>)Session["devices"]);
            devices.Add(new PanasonicLoudspeakers(devices.Count));
            Repeater1.DataSource = devices;
            Repeater1.DataBind();
            Session["devices"] = devices;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            List<Device> devices = ((List<Device>)Session["devices"]);
            devices.Add(new Camera(devices.Count));
            Repeater1.DataSource = devices;
            Repeater1.DataBind();
            Session["devices"] = devices;
        }
    }
}