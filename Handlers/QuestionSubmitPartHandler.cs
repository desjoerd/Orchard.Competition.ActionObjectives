﻿using DeSjoerd.Competition.ActionObjectives.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives.Handlers
{
    public class QuestionSubmitPartHandler : ContentHandler
    {
        public QuestionSubmitPartHandler(
            IRepository<QuestionSubmitPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}