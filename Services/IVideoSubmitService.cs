using DeSjoerd.Competition.Models;
using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Services
{
    public interface IVideoSubmitService : IDependency
    {
        void SubmitVideo(ObjectivePart objective, TeamPart team, string videoUrl);
    }
}