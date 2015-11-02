using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using SmartHouseWebForms.SmartHouse.Devices;

namespace SmartHouseWebForms.ServerControls
{
    public class CameraControl : Control
    {

        public CameraControl(Camera camera)
        {
            Camera = camera;
        }
        public Camera Camera { get; set; }
        protected override void Render(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.P);
            writer.Write(Camera);
            writer.RenderEndTag();
        }
    }
}