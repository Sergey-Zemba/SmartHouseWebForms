using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using SmartHouseWebForms.SmartHouse.Devices;
using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms
{
    public class DeviceListModel
    {
        private List<Device> devices;
        private IReadingWriting irw  = new XmlReadingWriting();

        public List<Device> GetDevices()
        {
            devices = irw.Read();
            return devices;
        }

        public void Add(string device)
        {
            devices = irw.Read();
            int id = MakeId();
            switch (device)
            {
                case "conditioner":
                    devices.Add(new AirConditioner(id));
                    break;
                case "camera":
                    devices.Add(new Camera(id));
                    break;
                case "fridge":
                    devices.Add(new Fridge(id));
                    break;
                case "garage":
                    devices.Add(new Garage(id));
                    break;
                case "panasonicCinema":
                    devices.Add(new PanasonicHomeCinema(id, new PanasonicTv(id), new PanasonicStereoSystem(id, new PanasonicLoudspeakers(id))));
                    break;
                case "samsungCinema":
                    devices.Add(new SamsungHomeCinema(id, new SamsungTv(id), new SamsungStereoSystem(id, new SamsungLoudspeakers(id))));
                    break;
                case "panasonicLoudSpeakers":
                    devices.Add(new PanasonicLoudspeakers(id));
                    break;
                case "samsungLoudSpeakers":
                    devices.Add(new SamsungLoudspeakers(id));
                    break;
                case "panasonicStereo":
                    devices.Add(new PanasonicStereoSystem(id, new PanasonicLoudspeakers(id)));
                    break;
                case "samsungStereo":
                    devices.Add(new SamsungStereoSystem(id, new SamsungLoudspeakers(id)));
                    break;
                case "panasonicTv":
                    devices.Add(new PanasonicTv(id));
                    break;
                case "samsungTv":
                    devices.Add(new SamsungTv(id));
                    break;
            }
            irw.Write(devices);
        }
        public void Delete(int id)
        {
            devices = irw.Read();
            Device device = GetDevice(devices, id);
            devices.Remove(device);
            irw.Write(devices);
        }

        public void OnOff(int id)
        {
            devices = irw.Read();
            Device device = GetDevice(devices, id);
            if (device.SwitchState == SwitchState.Off)
            {
                device.On();
            }
            else
            {
                device.Off();
            }
            irw.Write(devices);
        }

        public void Bass(int id)
        {
            devices = irw.Read();
            Device device = GetDevice(devices, id);
            if ((device as IBass).BassState == BassState.Off)
            {
                (device as IBass).BassOn();
            }
            else
            {
                (device as IBass).BassOff();
            }
            irw.Write(devices);
        }

        public void Open(int id)
        {
            devices = irw.Read();
            Device device = GetDevice(devices, id);
            if ((device as IOpenable).OpenState == OpenState.Close)
            {
                (device as IOpenable).Open();
            }
            irw.Write(devices);
        }

        public void Close(int id)
        {
            devices = irw.Read();
            Device device = GetDevice(devices, id);
            if ((device as IOpenable).OpenState == OpenState.Open)
            {
                (device as IOpenable).Close();
            }
            irw.Write(devices);
        }

        public void Rec(int id)
        {
            devices = irw.Read();
            Device device = GetDevice(devices, id);
            if ((device as IRecording).RecordMode == RecordMode.Live)
            {
                (device as IRecording).StartRecording();
            }
            else
            {
                (device as IRecording).StopRecording();
            }
            irw.Write(devices);
        }

        public void Warmer(int id)
        {
            devices = irw.Read();
            Device device = GetDevice(devices, id);
            (device as ITemperature).AddTemperture();
            irw.Write(devices);
        }
        public void Cooler(int id)
        {
            devices = irw.Read();
            Device device = GetDevice(devices, id);
            (device as ITemperature).DecreaseTemperature();
            irw.Write(devices);
        }

        public void ThreeD(int id)
        {
            devices = irw.Read();
            Device device = GetDevice(devices, id);
            if ((device as IThreeDimensional).Mode == TvMode.StandartMode)
            {
                (device as IThreeDimensional).ThreeDOn();
            }
            else
            {
                (device as IThreeDimensional).ThreeDOff();
            }
            irw.Write(devices);
        }
        public void Louder(int id)
        {
            devices = irw.Read();
            Device device = GetDevice(devices, id);
            (device as IVolumeable).AddVolume();
            irw.Write(devices);
        }
        public void Hush(int id)
        {
            devices = irw.Read();
            Device device = GetDevice(devices, id);
            (device as IVolumeable).DecreaseVolume();
            irw.Write(devices);
        }
        public void Mute(int id)
        {
            devices = irw.Read();
            Device device = GetDevice(devices, id);
            (device as IVolumeable).Mute();
            irw.Write(devices);
        }
        private Device GetDevice(List<Device> devices, int id)
        {
            Device device = devices.Single(x => x.Id == id);
            return device;
        }

        private int MakeId()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            int id;
            using (FileStream fs = new FileStream(@"C:\Users\Sergey\Source\Repos\SmartHouseWebForms\SmartHouseWebForms\ID.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    id = (int) formatter.Deserialize(fs);
                }
                else
                {
                    id = 0;
                }
            }
            using (
                FileStream fs =
                    new FileStream(@"C:\Users\Sergey\Source\Repos\SmartHouseWebForms\SmartHouseWebForms\ID.dat",
                        FileMode.Open))
            {

                id++;
                formatter.Serialize(fs, id);
            }
            return id;
        }
    }
}