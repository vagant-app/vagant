using System.Web.Optimization;

namespace Vagant.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js-libraries")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/knockout.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Common/site.css",
                      "~/Content/Common/reset.css"));

            bundles.Add(new ScriptBundle("~/bundles/Timeline")
                .Include("~/Scripts/jquery.jqtimeline.js")
                .Include("~/Scripts/Custom/bindings/timelineBinding.js"));

            bundles.Add(new StyleBundle("~/bundles/css/Timeline")
                .Include("~/Content/jquery.jqtimeline.css")
                .Include("~/Content/jquery.timeline.blue.css"));

            bundles.Add(new ScriptBundle("~/bundles/StarRating")
                .Include("~/Scripts/star-rating.js")
                .Include("~/Scripts/Custom/bindings/ratingBinding.js"));

            bundles.Add(new StyleBundle("~/bundles/css/StarRating")
                .Include("~/Content/star-rating.css"));

            RegisterHomeBundles(bundles);
            RegisterProfileBundles(bundles);
            RegisterEventBundles(bundles);
        }

        public static void RegisterProfileBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Profile")
                .Include("~/Scripts/Custom/Models/Profile/achievements.js")
                .Include("~/Scripts/Custom/Models/Profile/contactInformation.js")
                .Include("~/Scripts/Custom/Models/Profile/profileHistory.js")
                .Include("~/Scripts/Custom/Models/Profile/profile.js"));

            bundles.Add(new StyleBundle("~/Content/css/Profile")
                .IncludeDirectory("~/Content/Profile/", "*.css"));
        }

        public static void RegisterEventBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/CreateEvent")
                .Include("~/Scripts/libs/soundcloud-api.min.js")
                .Include("~/Scripts/Custom/sound/soundCloudPlayer.js")
                .Include("~/Scripts/Custom/createEventPage.js"));

            bundles.Add(new ScriptBundle("~/bundles/DetailsEvent")
                .Include("~/Scripts/Custom/models/event/starRatingModel.js")
                .Include("~/Scripts/Custom/detailsEventPage.js"));

            bundles.Add(new ScriptBundle("~/bundles/Event")
                .Include("~/Scripts/Custom/Models/Event/event.js"));

            bundles.Add(new StyleBundle("~/bundles/css/CreateEvent")
                .Include("~/Content/Event/createEvent.css"));

            bundles.Add(new StyleBundle("~/bundles/css/Event")
                .Include("~/Content/Event/event.css"));
        }

        public static void RegisterHomeBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/Home")
                .Include("~/Scripts/Custom/sound/player.js")
                .Include("~/Scripts/Custom/Models/Home/timelineModel.js")
                .Include("~/Scripts/Custom/models/event/instrumentFilter.js")
                .Include("~/Scripts/Custom/models/event/eventInstrumentModel.js")
                .Include("~/Scripts/Custom/models/event/eventListItem.js")
                .Include("~/Scripts/Custom/models/event/eventList.js")
                .Include("~/Scripts/Custom/models/event/eventGridManager.js")
                .Include("~/Scripts/Custom/pages/home.js"));

            bundles.Add(new StyleBundle("~/bundles/css/Home")
                .Include("~/Content/Home/instrument-filter.css")
                .Include("~/Content/Event/event-list.css")
                .Include("~/Content/Event/event-list-item.css")
                .Include("~/Content/Home/event-filters.css")
                .Include("~/Content/Home/home.css"));
        }
    }
}
