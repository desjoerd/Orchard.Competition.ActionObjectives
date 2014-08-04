using DeSjoerd.Competition.ActionObjectives.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using DeSjoerd.Competition.Models;

namespace DeSjoerd.Competition.ActionObjectives.Handlers
{
    public class ActionSubmitPartHandler : ContentHandler
    {
        public ActionSubmitPartHandler(IRepository<ActionSubmitPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));

            OnLoading<ActionSubmitPart>((context, part) =>
            {
                if (part.Objective == null)
                {
                    context.ContentManager.Remove(part.ContentItem);
                }
            });

            OnRemoving<ActionObjectivePart>((context, part) =>
            {
                var submitsToBeRemoved = context.ContentManager.Query<ActionSubmitPart, ActionSubmitPartRecord>()
                    .Where(submit => submit.ObjectivePartRecord.ContentItemRecord.Id == part.ContentItem.Id)
                    .List();

                foreach (var submit in submitsToBeRemoved)
                {
                    context.ContentManager.Remove(submit.ContentItem);
                }
            });

            OnRemoving<TeamPart>((context, part) =>
            {
                var submitsToBeRemoved = context.ContentManager.Query<ActionSubmitPart, ActionSubmitPartRecord>()
                    .Where(submit => submit.TeamPartRecord.ContentItemRecord.Id == part.ContentItem.Id)
                    .List();

                foreach (var submit in submitsToBeRemoved)
                {
                    context.ContentManager.Remove(submit.ContentItem);
                }
            });
        }
    }
}