﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Device> devices = new List<Device>();
                SaveDeviceList(devices);
                int id = 0;
                SaveId(id);
            }
        }
        protected void OnItemCommand(object source, RepeaterCommandEventArgs e)
        {
            List<Device> devices = GetDeviceList();
            Device device = GetDevice(devices, e);
            if (e.CommandName == "Delete")
            {
                devices.Remove(device);
                BindDevices(devices);
                SaveDeviceList(devices);
            }
            else if (e.CommandName == "On/Off")
            {
                if (device.SwitchState == SwitchState.Off)
                {
                    device.On();
                }
                else
                {
                    device.Off();
                }
                BindDevices(devices);
                SaveDeviceList(devices);
            }
            else if (e.CommandName == "Bass")
            {
                if ((device as IBass).BassState == BassState.Off)
                {
                    (device as IBass).BassOn();
                }
                else
                {
                    (device as IBass).BassOff();
                }
                BindDevices(devices);
                SaveDeviceList(devices);
            }
            else if (e.CommandName == "Open")
            {
                if ((device as IOpenable).OpenState == OpenState.Close)
                {
                    (device as IOpenable).Open();
                }
                BindDevices(devices);
                SaveDeviceList(devices);
            }
            else if (e.CommandName == "Close")
            {
                if ((device as IOpenable).OpenState == OpenState.Open)
                {
                    (device as IOpenable).Close();
                }
                BindDevices(devices);
                SaveDeviceList(devices);
            }
            else if (e.CommandName == "REC")
            {
                if ((device as IRecording).RecordMode == RecordMode.Live)
                {
                    (device as IRecording).StartRecording();
                }
                else
                {
                    (device as IRecording).StopRecording();
                }
                BindDevices(devices);
                SaveDeviceList(devices);
            }
            else if (e.CommandName == "Warmer")
            {
                (device as ITemperature).AddTemperture();
                BindDevices(devices);
                SaveDeviceList(devices);
            }
            else if (e.CommandName == "Cooler")
            {
                (device as ITemperature).DecreaseTemperature();
                BindDevices(devices);
                SaveDeviceList(devices);
            }
            else if (e.CommandName == "ThreeD")
            {
                if ((device as IThreeDimensional).Mode == TvMode.StandartMode)
                {
                    (device as IThreeDimensional).ThreeDOn();
                }
                else
                {
                    (device as IThreeDimensional).ThreeDOff();
                }
                BindDevices(devices);
                SaveDeviceList(devices);
            }
            else if (e.CommandName == "Louder")
            {
                (device as IVolumeable).AddVolume();
                BindDevices(devices);
                SaveDeviceList(devices);
            }
            else if (e.CommandName == "Hush")
            {
                (device as IVolumeable).DecreaseVolume();
                BindDevices(devices);
                SaveDeviceList(devices);
            }
            else if (e.CommandName == "Mute")
            {
                (device as IVolumeable).Mute();
                BindDevices(devices);
                SaveDeviceList(devices);
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
            List<Device> devices = GetDeviceList();
            int id = GetId();
            devices.Add(new AirConditioner(id));
            BindDevices(devices);
            SaveDeviceList(devices);
            SaveId(id);
        }

        protected void AddCamera_Click(object sender, EventArgs e)
        {
            List<Device> devices = GetDeviceList();
            int id = GetId();
            devices.Add(new Camera(id));
            BindDevices(devices);
            SaveDeviceList(devices);
            SaveId(id);
        }

        protected void AddFridge_Click(object sender, EventArgs e)
        {
            List<Device> devices = GetDeviceList();
            int id = GetId();
            devices.Add(new Fridge(id));
            BindDevices(devices);
            SaveDeviceList(devices);
            SaveId(id);
        }

        protected void AddGarage_Click(object sender, EventArgs e)
        {
            List<Device> devices = GetDeviceList();
            int id = GetId();
            devices.Add(new Garage(id));
            BindDevices(devices);
            SaveDeviceList(devices);
            SaveId(id);
        }

        protected void AddHomeCinema_Click(object sender, EventArgs e)
        {
            RadioButtonsUp(PanasonicCinemaRadio, SamsungCinemaRadio);
            List<Device> devices = GetDeviceList();
            BindDevices(devices);
            SaveDeviceList(devices);
        }

        protected void PanasonicCinemaRadio_CheckedChanged(object sender, EventArgs e)
        {
            List<Device> devices = GetDeviceList();
            int id = GetId();
            devices.Add(new PanasonicHomeCinema(id, new PanasonicTv(id), new PanasonicStereoSystem(id, new PanasonicLoudspeakers(id))));
            BindDevices(devices);
            SaveDeviceList(devices);
            SaveId(id);
            RadioButtonsDown(PanasonicCinemaRadio, SamsungCinemaRadio);
        }

        protected void SamsungCinemaRadio_CheckedChanged(object sender, EventArgs e)
        {
            List<Device> devices = GetDeviceList();
            int id = GetId();
            devices.Add(new SamsungHomeCinema(id, new SamsungTv(id), new SamsungStereoSystem(id, new SamsungLoudspeakers(id))));
            BindDevices(devices);
            SaveDeviceList(devices);
            SaveId(id);
            RadioButtonsDown(PanasonicCinemaRadio, SamsungCinemaRadio);
        }

        protected void AddLoudspeakers_Click(object sender, EventArgs e)
        {
            RadioButtonsUp(PanasonicLoudspeakersRadio, SamsungLoudspeakersRadio);
            List<Device> devices = GetDeviceList();
            BindDevices(devices);
            SaveDeviceList(devices);
        }

        protected void PanasonicLoudspeakersRadio_CheckedChanged(object sender, EventArgs e)
        {
            List<Device> devices = GetDeviceList();
            int id = GetId();
            devices.Add(new PanasonicLoudspeakers(id));
            BindDevices(devices);
            SaveDeviceList(devices);
            SaveId(id);
            RadioButtonsDown(PanasonicLoudspeakersRadio, SamsungLoudspeakersRadio);
        }

        protected void SamsungLoudspeakersRadio_CheckedChanged(object sender, EventArgs e)
        {
            List<Device> devices = GetDeviceList();
            int id = GetId();
            devices.Add(new SamsungLoudspeakers(id));
            BindDevices(devices);
            SaveDeviceList(devices);
            SaveId(id);
            RadioButtonsDown(PanasonicLoudspeakersRadio, SamsungLoudspeakersRadio);
        }
        protected void AddStereoSystem_Click(object sender, EventArgs e)
        {
            RadioButtonsUp(PanasonicStereoRadio, SamsungStereoRadio);
            List<Device> devices = GetDeviceList();
            BindDevices(devices);
            SaveDeviceList(devices);
        }
        protected void PanasonicStereoRadio_CheckedChanged(object sender, EventArgs e)
        {
            List<Device> devices = GetDeviceList();
            int id = GetId();
            devices.Add(new PanasonicStereoSystem(id, new PanasonicLoudspeakers(id)));
            BindDevices(devices);
            SaveDeviceList(devices);
            SaveId(id);
            RadioButtonsDown(PanasonicStereoRadio, SamsungStereoRadio);
        }

        protected void SamsungStereoRadio_CheckedChanged(object sender, EventArgs e)
        {
            List<Device> devices = GetDeviceList();
            int id = GetId();
            devices.Add(new SamsungStereoSystem(id, new SamsungLoudspeakers(id)));
            BindDevices(devices);
            SaveDeviceList(devices);
            SaveId(id);
            RadioButtonsDown(PanasonicStereoRadio, SamsungStereoRadio);
        }

        protected void AddTV_Click(object sender, EventArgs e)
        {
            RadioButtonsUp(PanasonicTVRadio, SamsungTVRadio);
            List<Device> devices = GetDeviceList();
            BindDevices(devices);
            SaveDeviceList(devices);
        }

        protected void PanasonicTVRadio_CheckedChanged(object sender, EventArgs e)
        {
            List<Device> devices = GetDeviceList();
            int id = GetId();
            devices.Add(new PanasonicTv(id));
            BindDevices(devices);
            SaveDeviceList(devices);
            SaveId(id);
            RadioButtonsDown(PanasonicTVRadio, SamsungTVRadio);
        }

        protected void SamsungTVRadio_CheckedChanged(object sender, EventArgs e)
        {
            List<Device> devices = GetDeviceList();
            int id = GetId();
            devices.Add(new SamsungTv(id));
            BindDevices(devices);
            SaveDeviceList(devices);
            SaveId(id);
            RadioButtonsDown(PanasonicTVRadio, SamsungTVRadio);
        }

        private Device GetDevice(List<Device> devices, RepeaterCommandEventArgs e)
        {
            HiddenField h = (HiddenField)e.Item.FindControl("hid");
            int id = Int32.Parse(h.Value);
            Device device = devices.Single(x => x.Id == id);
            return device;
        }
        private List<Device> GetDeviceList()
        {
            return (List<Device>)Session["devices"];
        }

        private void SaveDeviceList(List<Device> devices)
        {
            Session["devices"] = devices;
        }

        private int GetId()
        {
            return (int)Session["id"];
        }

        private void SaveId(int id)
        {
            id++;
            Session["id"] = id;
        }

        private void BindDevices(List<Device> devices)
        {
            Repeater1.DataSource = devices;
            Repeater1.DataBind();
        }

        private void RadioButtonsDown(RadioButton rb1, RadioButton rb2)
        {
            rb1.Checked = false;
            rb2.Checked = false;
            rb1.Visible = false;
            rb2.Visible = false;
        }
        private void RadioButtonsUp(RadioButton rb1, RadioButton rb2)
        {
            rb1.Visible = true;
            rb2.Visible = true;
        }
    }
}