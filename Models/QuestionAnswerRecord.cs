using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Models
{
    public class QuestionAnswerRecord
    {
        public virtual int Id { get; set; }

        public virtual QuestionObjectivePartRecord QuestionObjectivePartRecord { get; set; }

        public virtual string Answer { get; set; }
    }
}