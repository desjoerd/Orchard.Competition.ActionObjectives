using DeSjoerd.Competition.ActionObjectives.Models;
using DeSjoerd.Competition.ActionObjectives.Services;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Localization;
using Orchard.UI.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeSjoerd.Competition.ActionObjectives.Controllers
{
    [Admin]
    public class ActionSubmitAdminController : Controller
    {
        private readonly IActionSubmitService _actionSubmitService;

        public ActionSubmitAdminController(
            IActionSubmitService actionSubmitService,
            IOrchardServices services)
        {
            _actionSubmitService = actionSubmitService;
            Services = services;
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        public IOrchardServices Services { get; set; }

        //
        // GET: /ActionSubmitAdmin/

        public ActionResult List(SubmitStatus? status)
        {
            IEnumerable<ActionSubmitPart> submits;
            if (status != null)
            {
                submits = _actionSubmitService.Get(status.Value, VersionOptions.Latest);
            }
            else
            {
                submits = _actionSubmitService.Get(VersionOptions.Latest);
            }

            var list = Services.New.List();
            list.AddRange(submits.Select(submit => Services.ContentManager.BuildDisplay(submit, "SummaryAdmin")));

            dynamic viewModel = Services.New.ViewModel()
                .ContentItems(list);

            return View((object)viewModel);
        }

        public ActionResult VideoSubmits(SubmitStatus? status)
        {
            IEnumerable<ActionSubmitPart> submits;
            if (status != null)
            {
                submits = _actionSubmitService.Get(status.Value, VersionOptions.Latest);
            }
            else
            {
                submits = _actionSubmitService.Get(VersionOptions.Latest);
            }
            submits = submits.Where(submit => submit.Is<VideoSubmitPart>()).ToList();

            var list = Services.New.List();
            list.AddRange(submits.Select(submit => Services.ContentManager.BuildDisplay(submit, "SummaryAdmin")));

            dynamic viewModel = Services.New.ViewModel()
                .ContentItems(list);

            return View((object)viewModel);
        }

        [HttpPost]
        public ActionResult Accept(int actionSubmitId, int presetId)
        {
            var submit = _actionSubmitService.Get(actionSubmitId, VersionOptions.Published);
            if (submit == null)
            {
                return HttpNotFound();
            }
            var preset = submit.Objective != null ? submit.Objective.ObjectiveResultPresets.FirstOrDefault(p => p.Id == presetId) : null;
            if (preset == null)
            {
                return HttpNotFound();
            }

            _actionSubmitService.Approve(submit, preset);

            var shape = Services.New.Parts_ActionSubmit_StatusAdmin(ActionSubmit: submit);

            return PartialView((object)shape);
        }

        [HttpPost]
        public ActionResult Reject(int actionSubmitId)
        {
            var submit = _actionSubmitService.Get(actionSubmitId, VersionOptions.Published);
            if (submit == null)
            {
                return HttpNotFound();
            }

            _actionSubmitService.Reject(submit);

            var shape = Services.New.Parts_ActionSubmit_StatusAdmin(ActionSubmit: submit);

            return PartialView((object)shape);
        }
    }
}
