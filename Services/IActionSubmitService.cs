using DeSjoerd.Competition.ActionObjectives.Models;
using DeSjoerd.Competition.Models;
using Orchard;
using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Services
{
    public interface IActionSubmitService : IDependency
    {
        IContent NewActionSubmit(ObjectivePart objective, TeamPart team, string submitContentType);

        ObjectiveResultPart Approve(ActionSubmitPart submit, ObjectiveResultPresetRecord preset);

        ObjectiveResultPart Approve(ActionSubmitPart submit, string resultDisplayName, int resultPoints);

        void Reject(ActionSubmitPart submit);

        ActionSubmitPart Get(int id);

        ActionSubmitPart Get(int id, VersionOptions versionOptions);

        IEnumerable<ActionSubmitPart> Get();

        IEnumerable<ActionSubmitPart> Get(VersionOptions versionOptions);

        IEnumerable<ActionSubmitPart> Get(SubmitStatus status);

        IEnumerable<ActionSubmitPart> Get(SubmitStatus status, VersionOptions versionOptions);
    }
}