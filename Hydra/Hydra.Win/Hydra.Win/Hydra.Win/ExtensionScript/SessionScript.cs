using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Win.ExtensionScript
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class SessionScript
    {
        private Dictionary<string, string> _Session = new Dictionary<string, string>();

        public string Get(string name, string defaultValue = null)
        {
            string value = null;
            if (_Session.TryGetValue(name, out value))
            { return value; }
            else
            { return defaultValue; }
        }

        public void Set(string name, string value)
        {
            if (_Session.ContainsKey(name))
            { _Session[name] = value; }
            else
            { _Session.Add(name, value); }
        }

        public void Clear()
        {
            _Session.Clear();
        }
    }
}
