using DeSjoerd.Competition.ActionObjectives.Models;
using DeSjoerd.Competition.Models;
using Orchard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeSjoerd.Competition.ActionObjectives.Services
{
    public interface IQuestionObjectiveService : IDependency
    {
        void BuyHint(QuestionObjectivePart questionObjective, TeamPart team);
    }
}
