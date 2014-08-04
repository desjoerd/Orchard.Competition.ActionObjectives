using DeSjoerd.Competition.Models;
using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeSjoerd.Competition.ActionObjectives.Services
{
    public interface IQuestionSubmitService : IDependency
    {
        void SubmitAnswer(ObjectivePart objective, TeamPart team, string answer);
    }
}
