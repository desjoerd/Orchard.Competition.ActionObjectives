using DeSjoerd.Competition.ActionObjectives.Models;
using DeSjoerd.Competition.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Core.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Drivers
{
    public class ActionObjectivePartDriver : ContentPartDriver<ActionObjectivePart>
    {
        private readonly WorkContext _workContext;
        private readonly Lazy<IContentManager> _contentManager;

        public ActionObjectivePartDriver(
            WorkContext workContext,
            Lazy<IContentManager> contentManager)
        {
            this._contentManager = contentManager;
            this._workContext = workContext;
        }

        protected override DriverResult Display(ActionObjectivePart part, string displayType, dynamic shapeHelper)
        {
            var team = _workContext.CurrentUser.As<TeamPart>();
            if (team == null)
            {
                return null;
            }
            return Combined(
                ContentShape("Parts_ActionObjective_CreateSubmit",
                    () => shapeHelper.Parts_ActionObjective_CreateSubmit(ObjectivePart: part.As<ObjectivePart>(), TeamPart: team, TeamSubmits: GetSubmitsOfTeam(part.As<ObjectivePart>(), team))),

                ContentShape("Parts_ActionObjective_Submits",
                    () => shapeHelper.Parts_ActionObjective_Submits(SubmitList: BuildSubmitList(part.As<ObjectivePart>(), team, shapeHelper))));
        }

        private dynamic BuildSubmitList(ObjectivePart objective, TeamPart team, dynamic shapeHelper)
        {
            var submits = GetSubmitsOfTeam(objective, team);

            var list = shapeHelper.List(Classes: new [] { "small-block-grid-1", "large-block-grid-4" } );

            list.AddRange(submits.Select(submit => {
                var shape = _contentManager.Value.BuildDisplay(submit, "Summary");
                shape.Classes.Add("th");
                return shape;
            }));

            return list;
        }

        private IEnumerable<ActionSubmitPart> GetSubmitsOfTeam(ObjectivePart objective, TeamPart team)
        {
            return _contentManager.Value.Query<ActionSubmitPart, ActionSubmitPartRecord>(VersionOptions.Published)
                .Where(submit => submit.ObjectivePartRecord == objective.Record && submit.TeamPartRecord == team.Record)
                .Join<CommonPartRecord>()
                .OrderByDescending(common => common.CreatedUtc).List();
        }
    }
}