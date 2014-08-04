using DeSjoerd.Competition.Models;
using Orchard.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Models
{
    public class ActionSubmitPartRecord : ContentPartRecord
    {
        public virtual TeamPartRecord TeamPartRecord { get; set; }

        public virtual ObjectivePartRecord ObjectivePartRecord { get; set; }

        public virtual ObjectiveResultPartRecord ObjectiveResultPartRecord { get; set; }

        public virtual SubmitStatus Status { get; set; }
    }
}