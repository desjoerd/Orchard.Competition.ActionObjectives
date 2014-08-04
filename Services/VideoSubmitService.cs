using DeSjoerd.Competition.Models;
using Orchard.ContentManagement;
using Orchard.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeSjoerd.Competition.ActionObjectives.Extensions;
using DeSjoerd.Competition.ActionObjectives.Models;

namespace DeSjoerd.Competition.ActionObjectives.Services
{
    public class VideoSubmitService : IVideoSubmitService
    {
        private readonly IActionSubmitService _actionSubmitService;
        private readonly IContentManager _contentManager;

        public VideoSubmitService(
            IActionSubmitService actionSubmitService,
            IContentManager contentManager)
        {
            _actionSubmitService = actionSubmitService;
            _contentManager = contentManager;
        }

        public void SubmitVideo(ObjectivePart objective, TeamPart team, string videoUrl)
        {
            Argument.ThrowIfNull(objective, "objective");
            Argument.ThrowIfNull(team, "team");
            Argument.ThrowIfNullOrEmpty(videoUrl, "videoUrl");

            
            var newSubmit = _actionSubmitService.NewActionSubmit<VideoSubmitPart>(objective, team, "VideoSubmit");
            newSubmit.VideoUrl = videoUrl;

            _contentManager.Create(newSubmit);
        }
    }
}