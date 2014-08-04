using Orchard.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Models
{
    public class PhotoSubmitPartRecord : ContentPartRecord
    {
        public virtual string PhotoUrl { get; set; }
    }
}