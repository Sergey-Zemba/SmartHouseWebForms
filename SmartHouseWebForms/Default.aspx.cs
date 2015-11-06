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
            if (e.CommandName == "On/Off")
            {
                HiddenField h = (HiddenField)e.Item.FindControl("hid");
                int id = Int32.Parse(h.Value);
                List<Device> devices = GetDeviceList();
                Device device = devices.Single(x => x.Id == id);
                devices.Remove(device);
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
                PlaceHolder p = e.Item.FindControl("plcHolder") as PlaceHolder;
                Label state = new Label();
                state.Text = device.ToString();
                LinkButton switchLinkButton = new LinkButton();
                switchLinkButton.Text = "On/Off";
                switchLinkButton.CommandName = "On/Off";
                p.Controls.Add(state);
                p.Controls.Add(switchLinkButton);
                if (device is IBass)
                {
                    LinkButton bassLinkButton = new LinkButton();
                    bassLinkButton.Text = "Bass";
                    p.Controls.Add(bassLinkButton);
                }
                if (device is IOpenable)
                {
                    LinkButton openLinkButton = new LinkButton();
                    openLinkButton.Text = "Open";
                    LinkButton closeLinkButton = new LinkButton();
                    closeLinkButton.Text = "Close";
                    p.Controls.Add(openLinkButton);
                    p.Controls.Add(closeLinkButton);
                }
                if (device is IRecording)
                {
                    LinkButton recLinkButton = new LinkButton();
                    recLinkButton.Text = "REC";
                    p.Controls.Add(recLinkButton);
                }
                if (device is ITemperature)
                {
                    LinkButton warmerLinkButton = new LinkButton();
                    warmerLinkButton.Text = "Temperature Up";
                    LinkButton coolerLinkButton = new LinkButton();
                    coolerLinkButton.Text = "Temperature Down";
                    p.Controls.Add(warmerLinkButton);
                    p.Controls.Add(coolerLinkButton);
                }
                if (device is IThreeDimensional)
                {
                    LinkButton threeDLinkButton = new LinkButton();
                    threeDLinkButton.Text = "3D";
                    p.Controls.Add(threeDLinkButton);
                }
                if (device is IVolumeable)
                {
                    LinkButton louderLinkButton = new LinkButton();
                    louderLinkButton.Text = "Louder";
                    LinkButton hushLinkButton = new LinkButton();
                    hushLinkButton.Text = "Hush";
                    LinkButton muteLinkButton = new LinkButton();
                    muteLinkButton.Text = "Mute";
                    p.Controls.Add(louderLinkButton);
                    p.Controls.Add(hushLinkButton);
                    p.Controls.Add(muteLinkButton);
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
            devices.Add(new SamsungStereoSystem(id,new SamsungLoudspeakers(id)));
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