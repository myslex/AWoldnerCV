using BundleTransformer.Autoprefixer;
using BundleTransformer.CleanCss.Minifiers;
using BundleTransformer.Core.Builders;
using BundleTransformer.Core.Bundles;
using BundleTransformer.Core.Orderers;
using BundleTransformer.Core.Resolvers;
using BundleTransformer.Core.Transformers;
using System.Web;
using System.Web.Optimization;

namespace AWoldnerCV
{
    public class BundleConfig
    {
        public const string JQuery = "~/bundles/jquery";
        public const string JQueryValidate = "~/bundles/jqueryvalidate";

        public const string Modernizr = "~/bundles/modernizr";
        public const string Bootstrap = "~/bundles/bootstrap";

        public const string CoreCss = "~/bundles/style";

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            var nullBuilder = new NullBuilder();
            var styleTransformer = new StyleTransformer();
            var scriptTransformer = new ScriptTransformer();
            var nullOrderer = new NullOrderer();

            // Replace a default bundle resolver in order to the debugging HTTP-handler
            // can use transformations of the corresponding bundle
            BundleResolver.Current = new CustomBundleResolver();

            // modernizr
            Bundle modernizr = new Bundle(Modernizr);
            modernizr.Builder = nullBuilder;
            modernizr.Orderer = nullOrderer;
            modernizr.Include("~/Scripts/modernizr-*");
            modernizr.Transforms.Add(scriptTransformer);

            bundles.Add(modernizr);

            // jquery
            Bundle jquery = new Bundle(JQuery);
            jquery.Builder = nullBuilder;
            jquery.Orderer = nullOrderer;
            jquery.Include("~/Scripts/jquery-{version}.js");
            jquery.Transforms.Add(scriptTransformer);

            bundles.Add(jquery);

            // bootstrap
            Bundle bootstrap = new Bundle(Bootstrap);
            bootstrap.Builder = nullBuilder;
            bootstrap.Orderer = nullOrderer;
            bootstrap.Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js");
            bootstrap.Transforms.Add(scriptTransformer);

            bundles.Add(bootstrap);

            // core css (less)
            Bundle corecss = new Bundle(CoreCss);
            corecss.Builder = nullBuilder;
            corecss.Orderer = nullOrderer;
            corecss.Include("~/stylesheets/styles.css");
            corecss.Transforms.Add(styleTransformer);
            bundles.Add(corecss);

            BundleTable.EnableOptimizations = true;
        }
    }
}
