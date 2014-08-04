using Orchard.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Models
{
    public class PhotoSubmitPart : ContentPart<PhotoSubmitPartRecord>
    {
        public string PhotoUrl
        {
            get { return Record.PhotoUrl; }
            set { Record.PhotoUrl = value; }
        }
    }
}