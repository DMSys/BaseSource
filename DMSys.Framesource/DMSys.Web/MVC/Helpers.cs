using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace DMSys.Web.Mvc
{
    public static class Helpers
    {
        public static IHtmlString StyleRender(this HtmlHelper helper, params string[] paths)
        {
            StringBuilder sb = new StringBuilder();
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            foreach (string path in paths)
            {
                if (BundleTable.Bundles.Styles.ContainsKey(path))
                {
                    string[] transforms = BundleTable.Bundles.Styles[path];
                    foreach (string transform in transforms)
                    {
                        sb.AppendFormat("<link href='{0}' rel='stylesheet'>", urlHelper.Content(transform));
                    }
                }
                else
                {
                    sb.AppendFormat("<link href='{0}' rel='stylesheet'>", urlHelper.Content(path));
                }
            }
            return new HtmlString(sb.ToString());
        }

        public static IHtmlString ScriptRender(this HtmlHelper helper, params string[] paths)
        {
            StringBuilder sb = new StringBuilder();
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            foreach (string path in paths)
            {
                if (BundleTable.Bundles.Scripts.ContainsKey(path))
                {
                    string[] transforms = BundleTable.Bundles.Scripts[path];
                    foreach (string transform in transforms)
                    {
                        sb.AppendFormat("<script src='{0}'></script>", urlHelper.Content(transform));
                    }
                }
                else
                {
                    sb.AppendFormat("<script src='{0}'></script>", urlHelper.Content(path));
                }
            }
            return new HtmlString(sb.ToString());
        }
    }
}
