using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.ViewModels
{
    public class QuestionObjectiveEditorViewModel
    {
        public QuestionObjectiveEditorViewModel()
        {
            Answers = new List<string>();
            AutoValidate = true;

            IsMultipleChoice = false;
            Choices = new List<string>();
        }

        public List<string> Answers { get; set; }

        public bool AutoValidate { get; set; }

        public string Hint { get; set; }

        public int HintPrice { get; set; }

        public int MaxTries { get; set; }

        #region Multiple choice

        public List<string> Choices { get; set; }
        public bool IsMultipleChoice { get; set; }

        #endregion
    }
}