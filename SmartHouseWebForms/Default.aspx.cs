using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using SmartHouseWebForms.Model;
using SmartHouseWebForms.SmartHouse.Devices;
using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms
{


    public partial class Default : Page
    {
        DeviceListModel model = new DeviceListModel();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            BindDevices(model.GetDevices());
        }
        protected void OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = GetId(e);
            if (e.CommandName == "Delete")
            {
                model.Delete(id);
            }
            else if (e.CommandName == "On/Off")
            {
                model.OnOff(id);
            }
            else if (e.CommandName == "Bass")
            {
                model.Bass(id);
            }
            else if (e.CommandName == "Open/Close")
            {
                model.OpenClose(id);
            }
            else if (e.CommandName == "REC")
            {
                model.Rec(id);
            }
            else if (e.CommandName == "Warmer")
            {
                model.Warmer(id);
            }
            else if (e.CommandName == "Cooler")
            {
                model.Cooler(id);
            }
            else if (e.CommandName == "ThreeD")
            {
                model.ThreeD(id);
            }
            else if (e.CommandName == "Louder")
            {
                model.Louder(id);
            }
            else if (e.CommandName == "Hush")
            {
                model.Hush(id);
            }
            else if (e.CommandName == "Mute")
            {
                model.Mute(id);
            }
            RadioButtonsDown();
            Response.Redirect(Request.RawUrl);
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Device device = (Device)e.Item.DataItem;
                SetImage(device, e);
                ((ImageButton)e.Item.FindControl("DeleteButton")).ImageUrl = "/Css/Controls/Delete.png";
                if (device.SwitchState == SwitchState.Off)
                {
                    ((ImageButton) e.Item.FindControl("SwitchButton")).ImageUrl = "/Css/Controls/Off.png";
                }
                else
                {
                    ((ImageButton)e.Item.FindControl("SwitchButton")).ImageUrl = "/Css/Controls/On.png";
                }
                if (device is IBass && device.SwitchState == SwitchState.On)
                {
                    ((Panel)e.Item.FindControl("BassPanel")).Visible = true;
                    ((ImageButton)e.Item.FindControl("BassButton")).ImageUrl = "/Css/Controls/Bass.png";
                    if ((device as IBass).BassState == BassState.On)
                    {
                        ((Image)e.Item.FindControl("BassIndicator")).Visible = true;
                    }
                    else
                    {
                        ((Image)e.Item.FindControl("BassIndicator")).Visible = false;
                    }
                }
                if (device is IOpenable && device.SwitchState == SwitchState.On)
                {
                    ((Panel)e.Item.FindControl("LockPanel")).Visible = true;
                    if ((device as IOpenable).OpenState == OpenState.Open)
                    {

                        ((ImageButton) e.Item.FindControl("LockButton")).ImageUrl = "/Css/Controls/Open.png";
                    }
                    else
                    {

                        ((ImageButton)e.Item.FindControl("LockButton")).ImageUrl = "/Css/Controls/Close.png";
                    }
                }
                if (device is IRecording && device.SwitchState == SwitchState.On)
                {
                    ((Panel)e.Item.FindControl("RecordingPanel")).Visible = true;
                    ((ImageButton)e.Item.FindControl("RecButton")).ImageUrl = "/Css/Controls/Rec.png";
                    if ((device as IRecording).RecordMode == RecordMode.Record)
                    {
                        ((Image)e.Item.FindControl("RecIndicator")).Visible = true;
                    }
                    else
                    {
                        ((Image)e.Item.FindControl("RecIndicator")).Visible = false;
                    }
                }
                if (device is ITemperature && device.SwitchState == SwitchState.On)
                {
                    ((Panel)e.Item.FindControl("TemperaturePanel")).Visible = true;
                    ((Label)e.Item.FindControl("Temperature")).Text = (device as ITemperature).CurrentTemperature + "°C";
                    ((ImageButton)e.Item.FindControl("TempUp")).ImageUrl = "/Css/Controls/Up.png";
                    ((ImageButton)e.Item.FindControl("TempDown")).ImageUrl = "/Css/Controls/Down.png";
                }
                if (device is IThreeDimensional && device.SwitchState == SwitchState.On)
                {
                    ((Panel)e.Item.FindControl("ThreeDPanel")).Visible = true;
                    ((ImageButton)e.Item.FindControl("ThreeDButton")).ImageUrl = "/Css/Controls/3D.png";
                    if ((device as IThreeDimensional).Mode == TvMode.ThreeDMode)
                    {
                        ((Image)e.Item.FindControl("ThreeDIndicator")).Visible = true;
                    }
                    else
                    {
                        ((Image)e.Item.FindControl("ThreeDIndicator")).Visible = false;
                    }
                }
                if (device is IVolumeable && device.SwitchState == SwitchState.On)
                {
                    ((Panel)e.Item.FindControl("VolumePanel")).Visible = true;
                    ((Label)e.Item.FindControl("Volume")).Text = "Vol. " + (device as IVolumeable).CurrentVolume;
                    ((ImageButton)e.Item.FindControl("VolUp")).ImageUrl = "/Css/Controls/Up.png";
                    ((ImageButton)e.Item.FindControl("VolDown")).ImageUrl = "/Css/Controls/Down.png";
                    ((ImageButton)e.Item.FindControl("Mute")).ImageUrl = "/Css/Controls/Mute.png";
                    if ((device as IVolumeable).MuteState == MuteState.MuteOn)
                    {
                        ((Image)e.Item.FindControl("MuteIndicator")).Visible = true;
                    }
                    else
                    {
                        ((Image)e.Item.FindControl("MuteIndicator")).Visible = false;
                    }
                }
            }
        }

        protected void AddAirConditioner_Click(object sender, EventArgs e)
        {
            model.Add("conditioner");
            RadioButtonsDown();
        }

        protected void AddCamera_Click(object sender, EventArgs e)
        {
            model.Add("camera");
            RadioButtonsDown();
        }

        protected void AddFridge_Click(object sender, EventArgs e)
        {
            model.Add("fridge");
            RadioButtonsDown();
        }

        protected void AddGarage_Click(object sender, EventArgs e)
        {
            model.Add("garage");
            RadioButtonsDown();
        }

        protected void AddHomeCinema_Click(object sender, EventArgs e)
        {
            RadioButtonsDown();
            Panel p = (Panel)Page.FindControl("CinemaRadio");
            p.Visible = true;
        }

        protected void PanasonicCinemaRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("panasonicCinema");
            RadioButtonsDown();
        }

        protected void SamsungCinemaRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("samsungCinema");
            RadioButtonsDown();
        }

        protected void AddLoudspeakers_Click(object sender, EventArgs e)
        {
            RadioButtonsDown();
            Panel p = (Panel)Page.FindControl("LoudspeakersRadio");
            p.Visible = true;
        }

        protected void PanasonicLoudspeakersRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("panasonicLoudspeakers");
            RadioButtonsDown();
        }

        protected void SamsungLoudspeakersRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("samsungLoudspeakers");
            RadioButtonsDown();
        }
        protected void AddTV_Click(object sender, EventArgs e)
        {
            RadioButtonsDown();
            Panel p = (Panel)Page.FindControl("TVRadio");
            p.Visible = true;
        }

        protected void PanasonicTVRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("panasonicTv");
            RadioButtonsDown();
        }

        protected void SamsungTVRadio_CheckedChanged(object sender, EventArgs e)
        {
            model.Add("samsungTv");
            RadioButtonsDown();
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

        private void RadioButtonsDown()
        {
            List<Panel> panels = new List<Panel>
            {
                CinemaRadio, LoudspeakersRadio, TVRadio
            };
            foreach (Panel panel in panels)
            {
                if (panel.Visible)
                {
                    panel.Visible = false;
                }
            }
            List<RadioButton> radioButtons = new List<RadioButton>
            {
                PanasonicCinemaRadio, PanasonicLoudspeakersRadio,
                PanasonicTVRadio,SamsungCinemaRadio, SamsungLoudspeakersRadio, SamsungTVRadio
            };
            foreach (RadioButton rb in radioButtons)
            {
                rb.Checked = false;
            }
        }

        private void SetImage(Device device, RepeaterItemEventArgs e)
        {
            if (device is AirConditioner)
            {
                ((Panel)e.Item.FindControl("device")).BackImageUrl = "/Css/Devices/conditioner.jpg";
            }
            if (device is Camera)
            {
                ((Panel)e.Item.FindControl("device")).BackImageUrl = "/Css/Devices/camera.jpg";
            }
            if (device is Fridge)
            {
                ((Panel)e.Item.FindControl("device")).BackImageUrl = "/Css/Devices/fridge.png";
            }
            if (device is Garage)
            {
                ((Panel)e.Item.FindControl("device")).BackImageUrl = "/Css/Devices/garage.jpg";
            }
            if (device is PanasonicHomeCinema)
            {
                ((Panel)e.Item.FindControl("device")).BackImageUrl = "/Css/Devices/panasonicCinema.jpg";
            }
            if (device is SamsungHomeCinema)
            {
                ((Panel)e.Item.FindControl("device")).BackImageUrl = "/Css/Devices/samsungCinema.jpg";
            }
            if (device is PanasonicLoudspeakers)
            {
                ((Panel)e.Item.FindControl("device")).BackImageUrl = "/Css/Devices/panasonicLoudspeakers.jpg";
            }
            if (device is SamsungLoudspeakers)
            {
                ((Panel)e.Item.FindControl("device")).BackImageUrl = "/Css/Devices/samsungLoudspeakers.jpg";
            }
            if (device is PanasonicTv)
            {
                ((Panel)e.Item.FindControl("device")).BackImageUrl = "/Css/Devices/panasonicTV.jpg";
            }
            if (device is SamsungTv)
            {
                ((Panel)e.Item.FindControl("device")).BackImageUrl = "/Css/Devices/samsungTV.jpg";
            }
        }
    }
}