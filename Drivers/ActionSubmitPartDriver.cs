using DeSjoerd.Competition.ActionObjectives.Models;
using DeSjoerd.Competition.Models;
using DeSjoerd.Competition.Services;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Drivers
{
    public class ActionSubmitPartDriver : ContentPartDriver<ActionSubmitPart>
    {
        private readonly Lazy<IObjectiveService> _objectiveService;
        private readonly Lazy<IGameService> _gameService;

        public ActionSubmitPartDriver(
            Lazy<IObjectiveService> objectiveService,
            Lazy<IGameService> gameService)
        {
            _objectiveService = objectiveService;
            _gameService = gameService;
        }

        protected override DriverResult Display(ActionSubmitPart part, string displayType, dynamic shapeHelper)
        {
            List<DriverResult> results = new List<DriverResult>();

            results.Add(ContentShape("Parts_ActionSubmit_MetaAdmin", () =>
                {
                    var objective = _objectiveService.Value.Get(part.Objective.ContentItemRecord.Id, VersionOptions.Latest);

                    //var game = _gameService.Value.Get(part.Objective.GamePartRecord.ContentItemRecord.Id, VersionOptions.Latest);
                    GamePart game = part.Objective.GamePartRecord != null ? _gameService.Value.Get(part.Objective.GamePartRecord.ContentItemRecord.Id, VersionOptions.Latest) : null;

                    return (object)shapeHelper.Parts_ActionSubmit_MetaAdmin(Objective: objective, Game: game);
                }));

            results.Add(ContentShape("Parts_ActionSubmit_StatusAdmin", () =>
            {
                //var objective = _objectiveService.Value.Get(part.Objective.Id, VersionOptions.Latest);
                //var game = _gameService.Value.Get(part.Objective.GamePartRecord.Id, VersionOptions.Latest);

                return shapeHelper.Parts_ActionSubmit_StatusAdmin(ActionSubmit: part/*, Objective: objective, Game: game */);
            }));

            return Combined(results.ToArray());
        }
    }
}