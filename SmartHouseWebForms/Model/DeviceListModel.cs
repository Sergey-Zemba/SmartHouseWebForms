using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using SmartHouseWebForms.Model.SavingModel;
using SmartHouseWebForms.SmartHouse.Devices;
using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.Model
{
    public class DeviceListModel
    {
        private List<Device> _devices;
        private IReadingWriting irw  = new SessionReadingWriting();

        public List<Device> GetDevices()
        {
            _devices = irw.Read();
            return _devices;
        }

        public void Add(string device)
        {
            _devices = irw.Read();
            int id = irw.MakeId();
            switch (device)
            {
                case "conditioner":
                    _devices.Add(new AirConditioner(id));
                    break;
                case "camera":
                    _devices.Add(new Camera(id));
                    break;
                case "fridge":
                    _devices.Add(new Fridge(id));
                    break;
                case "garage":
                    _devices.Add(new Garage(id));
                    break;
                case "panasonicCinema":
                    _devices.Add(new PanasonicHomeCinema(id, new PanasonicTv(id), new PanasonicLoudspeakers(id)));
                    break;
                case "samsungCinema":
                    _devices.Add(new SamsungHomeCinema(id, new SamsungTv(id), new SamsungLoudspeakers(id)));
                    break;
                case "panasonicLoudspeakers":
                    _devices.Add(new PanasonicLoudspeakers(id));
                    break;
                case "samsungLoudspeakers":
                    _devices.Add(new SamsungLoudspeakers(id));
                    break;
                case "panasonicTv":
                    _devices.Add(new PanasonicTv(id));
                    break;
                case "samsungTv":
                    _devices.Add(new SamsungTv(id));
                    break;
            }
            irw.Write(_devices);
        }
        public void Delete(int id)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, id);
            _devices.Remove(device);
            irw.Write(_devices);
        }

        public void OnOff(int id)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, id);
            if (device.SwitchState == SwitchState.Off)
            {
                device.On();
            }
            else
            {
                device.Off();
            }
            irw.Write(_devices);
        }

        public void Bass(int id)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, id);
            if ((device as IBass).BassState == BassState.Off)
            {
                (device as IBass).BassOn();
            }
            else
            {
                (device as IBass).BassOff();
            }
            irw.Write(_devices);
        }

        public void OpenClose(int id)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, id);
            if ((device as IOpenable).OpenState == OpenState.Close)
            {
                (device as IOpenable).Open();
            }
            else
            {
                (device as IOpenable).Close();
            }
            irw.Write(_devices);
        }
        public void Rec(int id)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, id);
            if ((device as IRecording).RecordMode == RecordMode.Live)
            {
                (device as IRecording).StartRecording();
            }
            else
            {
                (device as IRecording).StopRecording();
            }
            irw.Write(_devices);
        }

        public void Warmer(int id)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, id);
            (device as ITemperature).AddTemperture();
            irw.Write(_devices);
        }
        public void Cooler(int id)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, id);
            (device as ITemperature).DecreaseTemperature();
            irw.Write(_devices);
        }

        public void ThreeD(int id)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, id);
            if ((device as IThreeDimensional).Mode == TvMode.StandartMode)
            {
                (device as IThreeDimensional).ThreeDOn();
            }
            else
            {
                (device as IThreeDimensional).ThreeDOff();
            }
            irw.Write(_devices);
        }
        public void Louder(int id)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, id);
            (device as IVolumeable).AddVolume();
            irw.Write(_devices);
        }
        public void Hush(int id)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, id);
            (device as IVolumeable).DecreaseVolume();
            irw.Write(_devices);
        }
        public void Mute(int id)
        {
            _devices = irw.Read();
            Device device = GetDevice(_devices, id);
            if ((device as IVolumeable).MuteState == MuteState.MuteOff)
            {
                (device as IVolumeable).MuteOn();
            }
            else
            {
                (device as IVolumeable).MuteOff();
            }
            irw.Write(_devices);
        }
        private Device GetDevice(List<Device> devices, int id)
        {
            Device device = devices.Single(x => x.Id == id);
            return device;
        }

        
    }
}