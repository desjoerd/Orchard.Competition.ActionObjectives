using DeSjoerd.Competition.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Models
{
    public class ActionSubmitPart : ContentPart<ActionSubmitPartRecord>
    {
        public SubmitStatus Status
        {
            get { return Record.Status; }
            set { Record.Status = value; }
        }

        public TeamPartRecord Team
        {
            get { return Record.TeamPartRecord; }
            set { Record.TeamPartRecord = value; }
        }

        public ObjectivePartRecord Objective
        {
            get { return Record.ObjectivePartRecord; }
            set { Record.ObjectivePartRecord = value; }
        }
    }
}