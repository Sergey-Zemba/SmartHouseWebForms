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
                Button1.Click += ButtonAdd_Click;
                Button2.Click += ButtonAdd_Click;
                Button3.Click += ButtonAdd_Click;
                
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            List<Device> devices = (List<Device>) Session["devices"];
            switch (((Button) sender).ID)
            {
                case "Button1":
                    devices.Add(new PanasonicLoudspeakers(devices.Count));
                    break;
                case "Button2":
                    devices.Add(new Camera(devices.Count));
                    break;
                case "Button3":
                    devices.Add(new SamsungLoudspeakers(devices.Count));
                    break;
            }
            Panel parentPanel = new Panel();
            form1.Controls.Add(parentPanel);
            foreach (Device device in devices)
            {
                Panel childPanel = new Panel();
                childPanel.ID = device.Id.ToString();
                Label state = new Label();
                state.Text = device.ToString();
                Button remove = new Button();
                remove.Text = "Remove";
                Button on = new Button();
                on.Text = "On/Off";
                if (device is IRecording)
                {
                    
                }
                childPanel.Controls.Add(state);
                childPanel.Controls.Add(remove);
                childPanel.Controls.Add(on);
                parentPanel.Controls.Add(childPanel);
            }
            Session["devices"] = devices;
        }
    }
}