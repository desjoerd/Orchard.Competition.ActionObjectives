using Orchard.Mvc.Routes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DeSjoerd.Competition.ActionObjectives
{
    public class Routes : IRouteProvider
    {
        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                new RouteDescriptor {
		            Route = new Route(
			            "Objective/{id}/SubmitPhoto",
			            new RouteValueDictionary {
				            {"area", "DeSjoerd.Competition.ActionObjectives"},
				            {"controller", "PhotoObjective"},
				            {"action", "Submit"}
			            },
			            new RouteValueDictionary(),
			            new RouteValueDictionary {
				            {"area", "DeSjoerd.Competition.ActionObjectives"}
			            },
			            new MvcRouteHandler())
	            },
                new RouteDescriptor {
		            Route = new Route(
			            "Objective/{id}/SubmitVideo",
			            new RouteValueDictionary {
				            {"area", "DeSjoerd.Competition.ActionObjectives"},
				            {"controller", "VideoObjective"},
				            {"action", "Submit"}
			            },
			            new RouteValueDictionary(),
			            new RouteValueDictionary {
				            {"area", "DeSjoerd.Competition.ActionObjectives"}
			            },
			            new MvcRouteHandler())
	            },
                new RouteDescriptor {
		            Route = new Route(
			            "Objective/{id}/SubmitAnswer",
			            new RouteValueDictionary {
				            {"area", "DeSjoerd.Competition.ActionObjectives"},
				            {"controller", "QuestionObjective"},
				            {"action", "Submit"}
			            },
			            new RouteValueDictionary(),
			            new RouteValueDictionary {
				            {"area", "DeSjoerd.Competition.ActionObjectives"}
			            },
			            new MvcRouteHandler())
	            },
                new RouteDescriptor {
		            Route = new Route(
			            "Admin/Competition/Submits",
			            new RouteValueDictionary {
				            {"area", "DeSjoerd.Competition.ActionObjectives"},
				            {"controller", "ActionSubmitAdmin"},
				            {"action", "List"}
			            },
			            new RouteValueDictionary(),
			            new RouteValueDictionary {
				            {"area", "DeSjoerd.Competition.ActionObjectives"}
			            },
			            new MvcRouteHandler())
	            },
                new RouteDescriptor {
		            Route = new Route(
			            "Admin/Competition/Submits/Accept",
			            new RouteValueDictionary {
				            {"area", "DeSjoerd.Competition.ActionObjectives"},
				            {"controller", "ActionSubmitAdmin"},
				            {"action", "Accept"}
			            },
			            new RouteValueDictionary(),
			            new RouteValueDictionary {
				            {"area", "DeSjoerd.Competition.ActionObjectives"}
			            },
			            new MvcRouteHandler())
	            },
                new RouteDescriptor {
		            Route = new Route(
			            "Admin/Competition/Submits/Reject",
			            new RouteValueDictionary {
				            {"area", "DeSjoerd.Competition.ActionObjectives"},
				            {"controller", "ActionSubmitAdmin"},
				            {"action", "Reject"}
			            },
			            new RouteValueDictionary(),
			            new RouteValueDictionary {
				            {"area", "DeSjoerd.Competition.ActionObjectives"}
			            },
			            new MvcRouteHandler())
	            },
            };
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }
    }
}