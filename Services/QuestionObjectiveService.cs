using DeSjoerd.Competition.Models;
using DeSjoerd.Competition.ActionObjectives.Extensions;
using Orchard.ContentManagement;
using Orchard.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeSjoerd.Competition.ActionObjectives.Models;
using Orchard.Data;

namespace DeSjoerd.Competition.ActionObjectives.Services
{
    public class QuestionObjectiveService : IQuestionObjectiveService, IQuestionSubmitService
    {
        private readonly IActionSubmitService _actionSubmitService;
        private readonly IContentManager _contentManager;
        private readonly IRepository<TeamUsedHintRecord> _teamUsedHintRepository;

        public QuestionObjectiveService(
            IActionSubmitService actionSubmitService,
            IContentManager contentManager,
            IRepository<TeamUsedHintRecord> teamUsedHintRepository)
        {
            _actionSubmitService = actionSubmitService;
            _contentManager = contentManager;
            _teamUsedHintRepository = teamUsedHintRepository;
        }

        public void SubmitAnswer(ObjectivePart objective, TeamPart team, string answer)
        {
            Argument.ThrowIfNull(objective, "objective");
            Argument.ThrowIfNull(team, "team");
            Argument.ThrowIfNullOrEmpty(answer, "answer");

            var newSubmit = _actionSubmitService.NewActionSubmit<QuestionSubmitPart>(objective, team, "QuestionSubmit");
            newSubmit.Answer = answer.Trim();

            _contentManager.Create(newSubmit);

            var question = objective.As<QuestionObjectivePart>();
            if (question != null && question.AutoValidate)
            {
                var newActionSubmit = newSubmit.As<ActionSubmitPart>();

                var answers = question.Answers.ToList();
                if (answers.Any(a => a.Answer.Trim().ToLowerInvariant() == answer.Trim().ToLowerInvariant()))
                {
                    var resultPreset = objective.ObjectiveResultPresets.FirstOrDefault();

                    var points = resultPreset.Points;
                    var resultDisplayName = resultPreset.DisplayName;

                    if (question.HintUsedByTeams.Any(teamHint => teamHint.TeamPartRecord.ContentItemRecord.Id == team.ContentItem.Id))
                    {
                        points -= question.HintPrice;
                    }

                    _actionSubmitService.Approve(newActionSubmit, resultDisplayName, points);
                }
                else
                {
                    _actionSubmitService.Reject(newActionSubmit);
                }
            }
        }

        public void BuyHint(QuestionObjectivePart questionObjective, TeamPart team)
        {
            Argument.ThrowIfNull(questionObjective, "questionObjective");
            Argument.ThrowIfNull(team, "team");

            if (questionObjective.HasHint && !questionObjective.HintUsedByTeams.Any(t => t.TeamPartRecord.ContentItemRecord.Id == team.ContentItem.Id))
            {
                var teamUsedHint = new TeamUsedHintRecord
                {
                    QuestionObjectivePartRecord = questionObjective.Record,
                    TeamPartRecord = team.Record
                };

                _teamUsedHintRepository.Create(teamUsedHint);

                //questionObjective.HintUsedByTeams.Add(new TeamUsedHintRecord
                //{
                //    QuestionObjectivePartRecord = questionObjective.Record,
                //    TeamPartRecord = team.Record
                //});
            }
        }
    }
}