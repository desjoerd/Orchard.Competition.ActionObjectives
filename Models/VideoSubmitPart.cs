using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Models
{
    public class VideoSubmitPart : ContentPart<VideoSubmitPartRecord>
    {
        public string VideoUrl
        {
            get { return Record.VideoUrl; }
            set { Record.VideoUrl = value; }
        }
    }
}