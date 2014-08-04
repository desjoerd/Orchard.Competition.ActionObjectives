using DeSjoerd.Competition.ActionObjectives.Models;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Drivers
{
    public class QuestionSubmitPartDriver : ContentPartDriver<QuestionSubmitPart>
    {
        protected override DriverResult Display(QuestionSubmitPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_QuestionSubmit", () => shapeHelper.Parts_QuestionSubmit(QuestionSubmitPart: part));
        }
    }
}