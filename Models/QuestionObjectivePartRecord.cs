using Orchard.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Models
{
    public class QuestionObjectivePartRecord : ContentPartRecord
    {
        public QuestionObjectivePartRecord()
        {
            Answers = new List<QuestionAnswerRecord>();
            HintUsedByTeams = new List<TeamUsedHintRecord>();
            AutoValidate = true;

            Choices = new List<QuestionChoiceRecord>();
        }

        public virtual IList<QuestionAnswerRecord> Answers { get; set; }

        public virtual IList<TeamUsedHintRecord> HintUsedByTeams { get; set; }

        public virtual bool AutoValidate { get; set; }

        public virtual string Hint { get; set; }

        public virtual int HintPrice { get; set; }

        public virtual int MaxTries { get; set; }

        #region multiple choice

        public virtual IList<QuestionChoiceRecord> Choices { get; set; }
        public virtual bool IsMultipleChoice { get; set; }

        #endregion
    }
}