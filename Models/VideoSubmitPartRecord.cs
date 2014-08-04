using Orchard.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeSjoerd.Competition.ActionObjectives.Models
{
    public class VideoSubmitPartRecord : ContentPartRecord
    {
        public virtual string VideoUrl { get; set; }
    }
}
