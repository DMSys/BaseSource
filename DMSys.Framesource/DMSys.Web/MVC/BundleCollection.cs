using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMSys.Web.Mvc
{
    public class BundleCollection
    {
        private Dictionary<string, string[]> _Styles = new Dictionary<string, string[]>();

        public Dictionary<string, string[]> Styles
        {
            get
            { return _Styles; }
        }

        private Dictionary<string, string[]> _Scripts = new Dictionary<string, string[]>();

        public Dictionary<string, string[]> Scripts
        {
            get
            { return _Scripts; }
        }

        public void AddStyle(string virtualPath, params string[] transforms)
        {
            _Styles.Add(virtualPath, transforms);
        }

        public void AddScripts(string virtualPath, params string[] transforms)
        {
            _Scripts.Add(virtualPath, transforms);
        }
    }
}
