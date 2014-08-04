using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Models
{
    public class QuestionObjectivePart : ContentPart<QuestionObjectivePartRecord>
    {
        public IList<QuestionAnswerRecord> Answers
        {
            get { return Record.Answers; }
        }

        public bool HasHint
        {
            get { return !string.IsNullOrEmpty(Hint); }
        }

        public string Hint
        {
            get { return Record.Hint; }
            set { Record.Hint = value; }
        }

        public int HintPrice
        {
            get { return Record.HintPrice; }
            set { Record.HintPrice = value; }
        }

        public bool AutoValidate
        {
            get { return Record.AutoValidate; }
            set { Record.AutoValidate = value; }
        }

        public IList<TeamUsedHintRecord> HintUsedByTeams { get { return Record.HintUsedByTeams; } }

        public int MaxTries
        {
            get { return Record.MaxTries; }
            set { Record.MaxTries = value; }
        }

        #region multiple choice

        public IList<QuestionChoiceRecord> Choices { get { return Record.Choices; } }
        public bool IsMultipleChoice
        {
            get { return Record.IsMultipleChoice; }
            set { Record.IsMultipleChoice = value; }
        }

        #endregion
    }
}