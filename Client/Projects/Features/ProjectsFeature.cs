using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Projects.State;
using Fluxor;

namespace Client.Projects.Features
{
    public class ProjectsFeature : Feature<ProjectsState>
    {
        public override string GetName() => "Projects";

        protected override ProjectsState GetInitialState() =>
            new ProjectsState(false, null, null, null);
    }
}