using DeSjoerd.Competition.ActionObjectives.Models;
using DeSjoerd.Competition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DeSjoerd.Competition.ActionObjectives.Extensions
{
    public static class UrlHelperExtensions
    {
        private static string GetReturnUrl()
        {
            var request = HttpContext.Current.Request;
            return request.QueryString["ReturnUrl"] ?? request.RawUrl;
        }

        public static string PhotoObjectiveSubmit(this UrlHelper url, ObjectivePart objective)
        {
            return url.Action("Submit", "PhotoObjective", new { id = objective.ContentItem.Id, ReturnUrl = GetReturnUrl(), area = "DeSjoerd.Competition.ActionObjectives" });
        }

        public static string VideoObjectiveSubmit(this UrlHelper url, ObjectivePart objective)
        {
            return url.Action("Submit", "VideoObjective", new { id = objective.ContentItem.Id, ReturnUrl = GetReturnUrl(), area = "DeSjoerd.Competition.ActionObjectives" });
        }

        public static string QuestionObjectiveSubmit(this UrlHelper url, ObjectivePart objective)
        {
            return url.Action("Submit", "QuestionObjective", new { id = objective.ContentItem.Id, ReturnUrl = GetReturnUrl(), area = "DeSjoerd.Competition.ActionObjectives" });
        }

        public static string BuyHint(this UrlHelper url, QuestionObjectivePart questionObjective)
        {
            return url.Action("BuyHint", "QuestionObjective", new { id = questionObjective.ContentItem.Id, ReturnUrl = GetReturnUrl(), area = "DeSjoerd.Competition.ActionObjectives" });
        }
    }
}