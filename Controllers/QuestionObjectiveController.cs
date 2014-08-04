using DeSjoerd.Competition.ActionObjectives.Services;
using Orchard;
using Orchard.Localization;
using Orchard.ContentManagement;
using Orchard.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeSjoerd.Competition.Models;
using Orchard.UI.Notify;
using Orchard.Mvc.Extensions;
using Orchard.Mvc;
using DeSjoerd.Competition.ActionObjectives.Models;

namespace DeSjoerd.Competition.ActionObjectives.Controllers
{
    [Themed]
    public class QuestionObjectiveController : Controller
    {
        private readonly IQuestionSubmitService _questionSubmitService;
        private readonly IQuestionObjectiveService _questionObjectiveService;


        public QuestionObjectiveController(
     IOrchardServices services,
     IQuestionSubmitService questionSubmitService,
            IQuestionObjectiveService questionObjectiveService)
        {
            this._questionSubmitService = questionSubmitService;
            this._questionObjectiveService = questionObjectiveService;

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
        public ActionResult Submit(int id, string answer, string returnUrl)
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

            if (String.IsNullOrWhiteSpace(answer))
            {
                ModelState.AddModelError("answer", T("Enter an answer").ToString());
            }

            if (!ModelState.IsValid)
            {
                return new ShapeResult(this, Services.ContentManager.BuildDisplay(objective, "Detail"));
            }

            _questionSubmitService.SubmitAnswer(objective, team, answer);

            Services.Notifier.Information(T("Answer submitted"));
            return this.RedirectLocal(returnUrl);
        }

        public ActionResult BuyHint(int id, string returnUrl)
        {
            var team = Services.WorkContext.CurrentUser != null ? Services.WorkContext.CurrentUser.As<TeamPart>() : null;
            if (team == null)
            {
                return new HttpUnauthorizedResult();
            }

            var questionObjective = Services.ContentManager.Get<QuestionObjectivePart>(id);
            if (questionObjective == null)
            {
                return new HttpNotFoundResult();
            }

            _questionObjectiveService.BuyHint(questionObjective, team);

            return this.RedirectLocal(returnUrl);
        }
    }
}
