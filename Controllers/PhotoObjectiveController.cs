using Orchard;
using Orchard.Localization;
using Orchard.UI.Notify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Mvc.Extensions;
using Orchard.ContentManagement;
using DeSjoerd.Competition.Models;
using DeSjoerd.Competition.ActionObjectives.Models;
using DeSjoerd.Competition.ActionObjectives.Services;
using Orchard.Themes;

namespace DeSjoerd.Competition.ActionObjectives.Controllers
{
    [Themed]
    public class PhotoObjectiveController : Controller
    {
        private readonly IPhotoSubmitService _photoSubmitService;

        public PhotoObjectiveController(
            IOrchardServices services,
            IPhotoSubmitService photoSubmitService)
        {
            this._photoSubmitService = photoSubmitService;

            T = NullLocalizer.Instance;
            Services = services;
        }

        public Localizer T { get; set; }

        public IOrchardServices Services { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">objectiveId</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Submit(int id, string returnUrl)
        {
            var team = Services.WorkContext.CurrentUser != null ? Services.WorkContext.CurrentUser.As<TeamPart>() : null;
            if (team == null)
            {
                return new HttpUnauthorizedResult();
            }

            var objective = Services.ContentManager.Get<ObjectivePart>(id);
            if (objective == null)
            {
                return new HttpNotFoundResult();
            }

            if (String.IsNullOrWhiteSpace(Request.Files[0].FileName))
            {
                ModelState.AddModelError("Media", T("Select a file to upload").ToString());
            }

            if (!ModelState.IsValid)
            {
                return View(Services.ContentManager.BuildDisplay(objective, "Detail"));
            }

            foreach (string fileName in Request.Files)
            {
                try
                {
                    _photoSubmitService.SubmitPhoto(objective, team, Request.Files[fileName]);
                }
                catch (ArgumentException e)
                {
                    Services.Notifier.Error(T("Uploading media file failed: {0}", e.Message));
                    return View(Services.ContentManager.BuildDisplay(objective, "Detail"));
                }
            }

            Services.Notifier.Information(T("Media file(s) uploaded"));
            return this.RedirectLocal(returnUrl);
        }

    }
}
