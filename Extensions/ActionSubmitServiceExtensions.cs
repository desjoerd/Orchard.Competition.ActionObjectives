using DeSjoerd.Competition.ActionObjectives.Services;
using DeSjoerd.Competition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace DeSjoerd.Competition.ActionObjectives.Extensions
{
    public static class ActionSubmitServiceExtensions
    {
        public static T NewActionSubmit<T>(this IActionSubmitService actionSubmitService, ObjectivePart objective, TeamPart team, string submitContentType) where T : IContent
        {
            var newSubmit = actionSubmitService.NewActionSubmit(objective, team, submitContentType);
            return newSubmit != null ? newSubmit.As<T>() : default(T);
        }
    }
}