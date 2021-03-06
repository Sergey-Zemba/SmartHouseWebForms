﻿using System;
using SmartHouseWebForms.SmartHouse.Interfaces;
using SmartHouseWebForms.SmartHouse.States;

namespace SmartHouseWebForms.SmartHouse.Devices
{
    [Serializable]

    class PanasonicTv : Tv, IThreeDimensional
    {
        private TvMode _mode;

        public PanasonicTv(int id)
            : base(id)
        {
        }

        public TvMode Mode { get { return _mode; } }

        public void ThreeDOn()
        {
            _mode = TvMode.ThreeDMode;
        }

        public void ThreeDOff()
        {
            _mode = TvMode.StandartMode;
        }
    }
}
