using Orchard.UI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();
            manifest.DefineScript("jQueryUnobtrusive_Ajax").SetUrl("jquery.unobtrusive-ajax.min.js", "jquery.unobtrusive-ajax.js").SetVersion("2.0.30506.0")
                .SetCdn("//ajax.aspnetcdn.com/ajax/mvc/3.0/jquery.unobtrusive-ajax.min.js", "//ajax.aspnetcdn.com/ajax/mvc/3.0/jquery.unobtrusive-ajax.js", true)
                .SetDependencies("jQuery");
        }
    }
}