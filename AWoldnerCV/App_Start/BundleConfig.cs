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
            // modernizr
            Bundle modernizr = new Bundle(Modernizr);
            modernizr.Transforms.Add(new ScriptTransformer());
            modernizr.Orderer = new NullOrderer();
            modernizr.Include("~/Scripts/modernizr-*");
            bundles.Add(modernizr);

            // jquery
            Bundle jquery = new Bundle(JQuery);
            jquery.Transforms.Add(new ScriptTransformer());
            jquery.Orderer = new NullOrderer();
            jquery.Include("~/Scripts/jquery-{version}.js");
            bundles.Add(jquery);
            
            // bootstrap
            Bundle bootstrap = new Bundle(Bootstrap);
            bootstrap.Transforms.Add(new ScriptTransformer());
            bootstrap.Orderer = new NullOrderer();
            bootstrap.Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js");
            bundles.Add(bootstrap);

            // core css (less)
            Bundle corecss = new Bundle(CoreCss);
            corecss.Transforms.Add(new CssMinify());
            corecss.Orderer = new NullOrderer();
            corecss.Include("~/stylesheets/styles.css");
            bundles.Add(corecss);
        }
    }
}
