using DeSjoerd.Competition.ActionObjectives.Models;
using DeSjoerd.Competition.Models;
using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Services
{
    public interface IPhotoSubmitService : IDependency
    {
        void SubmitPhoto(ObjectivePart objective, TeamPart team, HttpPostedFileBase photo);
    }
}
