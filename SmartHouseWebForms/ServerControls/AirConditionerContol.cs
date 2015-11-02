using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace SmartHouseWebForms.ServerControls
{
    public class AirConditionerContol : Control
    {
        protected override void Render(HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.P);
            writer.Write("Conditioner");
            writer.RenderEndTag();
        }
    }
}