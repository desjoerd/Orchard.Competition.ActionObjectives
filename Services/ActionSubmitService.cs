using DeSjoerd.Competition.ActionObjectives.Models;
using DeSjoerd.Competition.Models;
using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Services
{
    public class ActionSubmitService : IActionSubmitService
    {
        private readonly IContentManager _contentManager;

        public ActionSubmitService(
            IContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public IContent NewActionSubmit(ObjectivePart objective, TeamPart team, string submitContentType)
        {
            var newSubmit = _contentManager.New<ActionSubmitPart>(submitContentType);
            if (newSubmit == null)
            {
                return null;
            }

            newSubmit.Team = team.Record;
            newSubmit.Objective = objective.Record;

            return newSubmit;
        }

        public ObjectiveResultPart Approve(ActionSubmitPart submit, ObjectiveResultPresetRecord preset)
        {
            return Approve(submit, preset.DisplayName, preset.Points);
        }

        public ObjectiveResultPart Approve(ActionSubmitPart submit, string resultDisplayName, int resultPoints)
        {
            var result = _contentManager.New<ObjectiveResultPart>("SimpleObjectiveResult");

            result.DisplayName = resultDisplayName;
            result.Points = resultPoints;
            result.Team = submit.Team;
            result.Objective = submit.Objective;

            _contentManager.Create(result);

            submit.Status = SubmitStatus.Approved;

            return result;
        }

        public void Reject(ActionSubmitPart submit)
        {
            submit.Status = SubmitStatus.Rejected;
        }

        public ActionSubmitPart Get(int id)
        {
            return Get(id, VersionOptions.Published);
        }

        public ActionSubmitPart Get(int id, VersionOptions versionOptions)
        {
            return _contentManager.Get<ActionSubmitPart>(id, versionOptions);
        }

        public IEnumerable<ActionSubmitPart> Get()
        {
            return Get(VersionOptions.Published);
        }

        public IEnumerable<ActionSubmitPart> Get(VersionOptions versionOptions)
        {
            return _contentManager.Query<ActionSubmitPart>(versionOptions).List();
        }

        public IEnumerable<ActionSubmitPart> Get(SubmitStatus status)
        {
            return Get(status, VersionOptions.Published);
        }

        public IEnumerable<ActionSubmitPart> Get(SubmitStatus status, VersionOptions versionOptions)
        {
            return _contentManager.Query<ActionSubmitPart, ActionSubmitPartRecord>(versionOptions)
                .Where(submit => submit.Status == status).List();
        }
    }
}