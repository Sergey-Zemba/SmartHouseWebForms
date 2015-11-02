using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using SmartHouseWebForms.SmartHouse.Devices;

namespace SmartHouseWebForms.ServerControls
{
    public class AirConditionerControl : Control
    {
        public AirConditionerControl(AirConditioner conditioner)
        {
            Conditioner = conditioner;
        }
        public AirConditioner Conditioner { get; set; }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.P);
            writer.Write(Conditioner);
            writer.RenderEndTag();
        }
    }
}