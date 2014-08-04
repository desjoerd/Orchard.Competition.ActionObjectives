using DeSjoerd.Competition.ActionObjectives.Models;
using Orchard.Localization;
using Orchard.UI.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives
{
    public class AdminMenu : INavigationProvider
    {
        public Localizer T { get; set; }

        public string MenuName
        {
            get { return "admin"; }
        }

        public void GetNavigation(NavigationBuilder builder)
        {
            builder.Add(T("Competition"), "5", BuildMenu);
        }

        private void BuildMenu(NavigationItemBuilder menu)
        {
            //menu.Add(T("Manage Orientation"), "1.0", item =>
            //item.Action("Item", "OrientationAdmin", new { area = "DeSjoerd.Intro", }).LocalNav());

            //menu.Add(T("Games"), "1.1", item =>
            //    item.Action("List", "GameAdmin", new { area = "DeSjoerd.Intro", orientationId = orientationPart.Id }).LocalNav());

            menu.Add(T("Submits"), "2.0", item => item
                .Action("List", "ActionSubmitAdmin", new { area = "DeSjoerd.Competition.ActionObjectives" }).LocalNav());

            menu.Add(T("Pending Submits"), "2.1", item => item
                .Action("List", "ActionSubmitAdmin", new { area = "DeSjoerd.Competition.ActionObjectives", status = SubmitStatus.Pending }).LocalNav());

            menu.Add(T("Approved video submits"), "2.3", item => item
                .Action("VideoSubmits", "ActionSubmitAdmin", new { area = "DeSjoerd.Competition.ActionObjectives", status = SubmitStatus.Approved }).LocalNav());
        }
    }
}