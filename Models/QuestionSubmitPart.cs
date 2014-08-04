using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Models
{
    public class QuestionSubmitPart : ContentPart<QuestionSubmitPartRecord>
    {
        public string Answer
        {
            get { return Record.Answer; }
            set { Record.Answer = value; }
        }
    }
}