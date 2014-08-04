using DeSjoerd.Competition.ActionObjectives.Models;
using DeSjoerd.Competition.ActionObjectives.ViewModels;
using DeSjoerd.Competition.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Drivers
{
    public class QuestionObjectivePartDriver : ContentPartDriver<QuestionObjectivePart>
    {
        private Lazy<IRepository<QuestionAnswerRecord>> _answerRepository;
        private Lazy<IRepository<QuestionChoiceRecord>> _choiceRepository;

        public QuestionObjectivePartDriver(
            IOrchardServices services,
            Lazy<IRepository<QuestionAnswerRecord>> answerRepository,
            Lazy<IRepository<QuestionChoiceRecord>> choiceRepository)
        {
            Services = services;
            _answerRepository = answerRepository;
            _choiceRepository = choiceRepository;
        }

        public IOrchardServices Services { get; set; }


        protected override string Prefix
        {
            get
            {
                return "QuestionObjective";
            }
        }

        protected override DriverResult Display(QuestionObjectivePart part, string displayType, dynamic shapeHelper)
        {
            if (part.HasHint)
            {
                return ContentShape("Parts_QuestionObjective_Hint",
                    () =>
                    {
                        var team = Services.WorkContext.CurrentUser != null ? Services.WorkContext.CurrentUser.As<TeamPart>() : null;
                        if (team != null)
                        {
                            var teamUsedHint = part.HintUsedByTeams.Any(t => t.TeamPartRecord.ContentItemRecord.Id == team.ContentItem.Id);

                            return shapeHelper.Parts_QuestionObjective_Hint(QuestionObjectivePart: part, TeamPart: team, TeamUsedHint: teamUsedHint);
                        }
                        else
                        {
                            return null;
                        }
                    });
            }
            else
            {
                return null;
            }
        }

        protected override DriverResult Editor(QuestionObjectivePart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_QuestionObjective_Edit", () =>
                    shapeHelper.EditorTemplate(TemplateName: "Parts/QuestionObjective", Model: BuildEditorViewModel(part), Prefix: Prefix));
        }

        protected override DriverResult Editor(QuestionObjectivePart part, IUpdateModel updater, dynamic shapeHelper)
        {
            var viewModel = new QuestionObjectiveEditorViewModel();
            if (updater.TryUpdateModel(viewModel, Prefix, null, null))
            {
                part.AutoValidate = viewModel.AutoValidate;
                part.Hint = viewModel.Hint;
                part.HintPrice = viewModel.HintPrice;
                part.MaxTries = viewModel.MaxTries;

                foreach (var answer in part.Answers)
                {
                    _answerRepository.Value.Delete(answer);
                }
                foreach (var answer in viewModel.Answers)
                {
                    var newAnswer = new QuestionAnswerRecord
                    {
                        Answer = answer.Trim(),
                        QuestionObjectivePartRecord = part.Record
                    };
                    _answerRepository.Value.Create(newAnswer);
                    part.Answers.Add(newAnswer);
                }

                // multiple choice
                part.IsMultipleChoice = viewModel.IsMultipleChoice;
                foreach (var choice in part.Choices)
                {
                    _choiceRepository.Value.Delete(choice);
                }
                foreach (var choice in viewModel.Choices)
                {
                    var newChoice = new QuestionChoiceRecord
                    {
                        Choice = choice.Trim(),
                        QuestionObjectivePartRecord = part.Record
                    };
                    _choiceRepository.Value.Create(newChoice);
                    part.Choices.Add(newChoice);
                }
            }

            return Editor(part, shapeHelper);
        }

        private QuestionObjectiveEditorViewModel BuildEditorViewModel(QuestionObjectivePart part)
        {
            return new QuestionObjectiveEditorViewModel
            {
                Answers = part.Answers.Select(a => a.Answer).ToList(),
                AutoValidate = part.AutoValidate,
                Hint = part.Hint,
                HintPrice = part.HintPrice,
                MaxTries = part.MaxTries,
                // multiple choice
                Choices = part.Choices.Select(c => c.Choice).ToList(),
                IsMultipleChoice = part.IsMultipleChoice
            };
        }
    }
}