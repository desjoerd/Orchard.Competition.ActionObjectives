using DeSjoerd.Competition.ActionObjectives.Services;
using Orchard;
using Orchard.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.ContentManagement;
using DeSjoerd.Competition.Models;
using Orchard.UI.Notify;
using Orchard.Mvc.Extensions;
using Orchard.Themes;

namespace DeSjoerd.Competition.ActionObjectives.Controllers
{
    [Themed]
    public class VideoObjectiveController : Controller
    {
        private readonly IVideoSubmitService _videoSubmitService;


        public VideoObjectiveController(
            IOrchardServices services,
            IVideoSubmitService videoSubmitService)
        {
            this._videoSubmitService = videoSubmitService;

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
        public ActionResult Submit(int id, string videoUrl, string returnUrl)
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

            if (String.IsNullOrWhiteSpace(videoUrl))
            {
                ModelState.AddModelError("videoUrl", T("Enter an url to a video").ToString());
            }

            if (!ModelState.IsValid)
            {
                return View(Services.ContentManager.BuildDisplay(objective, "Detail"));
            }

            _videoSubmitService.SubmitVideo(objective, team, videoUrl);

            Services.Notifier.Information(T("Video submitted"));
            return this.RedirectLocal(returnUrl);
        }
    }
}
