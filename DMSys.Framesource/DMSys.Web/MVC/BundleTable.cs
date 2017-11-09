using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Web.Mvc
{
    public static class BundleTable
    {
        private static BundleCollection _Bundles = new BundleCollection();

        public static BundleCollection Bundles
        {
            get
            { return _Bundles; }
        }
    }
}
