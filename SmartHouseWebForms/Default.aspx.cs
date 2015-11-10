using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHouseWebForms.SmartHouse.Devices;
using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms
{


    public partial class Default : System.Web.UI.Page
    {
        DeviceListModel model = new DeviceListModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDevices(model.GetDevices());
            }
            else
            {
                RadioButtonsDown(PanasonicTVRadio, SamsungTVRadio);
            }
        }
        protected void OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = GetId(e);
            if (e.CommandName == "Delete")
            {
                model.Delete(id);
                BindDevices(model.GetDevices());
            }
            else if (e.CommandName == "On/Off")
            {
                model.OnOff(id);
                BindDevices(model.GetDevices());
            }
            else if (e.CommandName == "Bass")
            {
                model.Bass(id);
                BindDevices(model.GetDevices());
            }
            else if (e.CommandName == "Open")
            {
                model.Open(id);
                BindDevices(model.GetDevices());
            }
            else if (e.CommandName == "Close")
            {
                model.Close(id);
                BindDevices(model.GetDevices());
            }
            else if (e.CommandName == "REC")
            {
                model.Rec(id);
                BindDevices(model.GetDevices());
            }
            else if (e.CommandName == "Warmer")
            {
                model.Warmer(id);
                BindDevices(model.GetDevices());
            }
            else if (e.CommandName == "Cooler")
            {
                model.Cooler(id);
                BindDevices(model.GetDevices());
            }
            else if (e.CommandName == "ThreeD")
            {
                model.ThreeD(id);
                BindDevices(model.GetDevices());
            }
            else if (e.CommandName == "Louder")
            {
                model.Louder(id);
                BindDevices(model.GetDevices());
            }
            else if (e.CommandName == "Hush")
            {
                model.Hush(id);
                BindDevices(model.GetDevices());
            }
            else if (e.CommandName == "Mute")
            {
                model.Mute(id);
                BindDevices(model.GetDevices());
            }
            
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Device device = (Device)e.Item.DataItem;
                ((Label)e.Item.FindControl("State")).Text = device.ToString();
                if (device is IBass)
                {
                    ((Panel)e.Item.FindControl("BassPanel")).Visible = true;
                }
                if (device is IOpenable)
                {
                    ((Panel)e.Item.FindControl("LockPanel")).Visible = true;
                }
                if (device is IRecording)
                {
                    ((Panel)e.Item.FindControl("RecordingPanel")).Visible = true;
                }
                if (device is ITemperature)
                {
                    ((Panel)e.Item.FindControl("TemperaturePanel")).Visible = true;
                }
                if (device is IThreeDimensional)
                {
                    ((Panel)e.Item.FindControl("ThreeDPanel")).Visible = true;
                }
                if (device is IVolumeable)
                {
                    ((Panel)e.Item.FindControl("VolumePanel")).Visible = true;
                }
            }
        }

        protected void AddAirConditioner_Click(object sender, EventArgs e)
        {
            model.Add("conditioner");
            BindDevices(model.GetDevices());
        }

        protected void AddCamera_Click(object sender, EventArgs e)
        {
            model.Add("camera");
            BindDevices(model.GetDevices());
        }

        protected void AddFridge_Click(object sender, EventArgs e)
        {
            model.Add("fridge");
            BindDevices(model.GetDevices());
        }

        protected void AddGarage_Click(object sender, EventArgs e)
        {
            model.Add("garage");
            BindDevices(model.GetDevices());
        }

        protected void AddHomeCinema_Click(object sender, EventArgs e)
        {
            RadioButtonsUp(PanasonicCinemaRadio, SamsungCinemaRadio);
            BindDevices(model.GetDevices());
        }

        protected void PanasonicCinemaRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("panasonicCinema");
            BindDevices(model.GetDevices());
            RadioButtonsDown(PanasonicCinemaRadio, SamsungCinemaRadio);
        }

        protected void SamsungCinemaRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("samsungCinema");
            BindDevices(model.GetDevices());
            RadioButtonsDown(PanasonicCinemaRadio, SamsungCinemaRadio);
        }

        protected void AddLoudspeakers_Click(object sender, EventArgs e)
        {
            RadioButtonsUp(PanasonicLoudspeakersRadio, SamsungLoudspeakersRadio);
            BindDevices(model.GetDevices());
        }

        protected void PanasonicLoudspeakersRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("panasonicLoudspeakers");
            BindDevices(model.GetDevices());
            RadioButtonsDown(PanasonicLoudspeakersRadio, SamsungLoudspeakersRadio);
        }

        protected void SamsungLoudspeakersRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("samsungLoudspeakers");
            BindDevices(model.GetDevices());
            RadioButtonsDown(PanasonicLoudspeakersRadio, SamsungLoudspeakersRadio);
        }
        protected void AddStereoSystem_Click(object sender, EventArgs e)
        {
            RadioButtonsUp(PanasonicStereoRadio, SamsungStereoRadio);
            BindDevices(model.GetDevices());
        }
        protected void PanasonicStereoRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("panasonicStereo");
            BindDevices(model.GetDevices());
            RadioButtonsDown(PanasonicStereoRadio, SamsungStereoRadio);
        }

        protected void SamsungStereoRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("samsungStereo");
            BindDevices(model.GetDevices());
            RadioButtonsDown(PanasonicStereoRadio, SamsungStereoRadio);
        }

        protected void AddTV_Click(object sender, EventArgs e)
        {
            RadioButtonsUp(PanasonicTVRadio, SamsungTVRadio);
            BindDevices(model.GetDevices());
        }

        protected void PanasonicTVRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("panasonicTv");
            BindDevices(model.GetDevices());
            RadioButtonsDown(PanasonicTVRadio, SamsungTVRadio);
        }

        protected void SamsungTVRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("samsungTv");
            BindDevices(model.GetDevices());
            RadioButtonsDown(PanasonicTVRadio, SamsungTVRadio);
        }

        private int GetId(RepeaterCommandEventArgs e)
        {
            HiddenField h = (HiddenField)e.Item.FindControl("hid");
            int id = Int32.Parse(h.Value);
            return id;
        }
        private void BindDevices(List<Device> devices)
        {
            Repeater1.DataSource = devices;
            Repeater1.DataBind();
        }

        private void RadioButtonsDown(params RadioButton[] radioButtons)
        {
            foreach (RadioButton rb in radioButtons)
            {
                rb.Checked = false;
                rb.Visible = false;
            }
        }
        private void RadioButtonsUp(params RadioButton[] radioButtons)
        {
            foreach (RadioButton rb in radioButtons)
            {
                rb.Visible = true;
            }
        }
    }
}