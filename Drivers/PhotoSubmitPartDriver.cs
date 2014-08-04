using DeSjoerd.Competition.ActionObjectives.Models;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Drivers
{
    public class PhotoSubmitPartDriver : ContentPartDriver<PhotoSubmitPart>
    {
        protected override DriverResult Display(PhotoSubmitPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_PhotoSubmit", () => shapeHelper.Parts_PhotoSubmit(PhotoSubmitPart: part));
        }
    }
}