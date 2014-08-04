using Orchard.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Models
{
    public class QuestionSubmitPartRecord : ContentPartRecord
    {
        public virtual string Answer { get; set; }
    }
}