using DeSjoerd.Competition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Models
{
    public class TeamUsedHintRecord
    {
        public virtual int Id { get; set; }

        public virtual TeamPartRecord TeamPartRecord { get; set; }

        public virtual QuestionObjectivePartRecord QuestionObjectivePartRecord { get; set; }
    }
}