using DeSjoerd.Competition.ActionObjectives.Models;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Drivers
{
    public class VideoSubmitPartDriver : ContentPartDriver<VideoSubmitPart>
    {
        protected override DriverResult Display(VideoSubmitPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_VideoSubmit", () => shapeHelper.Parts_VideoSubmit(VideoSubmitPart: part));
        }
    }
}