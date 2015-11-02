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
        private List<DeviceControl> controls = new List<DeviceControl>();
        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (DeviceControl control in controls)
            {
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Loudspeakers l = new SamsungLoudspeakers();
            DeviceControl deviceControl = new DeviceControl(l);

        }

    }
}