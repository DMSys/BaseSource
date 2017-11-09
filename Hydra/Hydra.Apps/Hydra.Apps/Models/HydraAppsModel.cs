using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hydra.Apps.Models
{
    public class HydraAppsModel : List<HydraAppModel>
    {
    }

    public class HydraAppModel
    {
        public Guid UId { get; set; }

        /// <summary>
        /// Име на приложението
        /// </summary>
        public string Name { get; set; }

        public string AppUrl { get; set; }
        
        public int DeveloperId { get; set; }
        
        /// <summary>
        /// Име на разработчика
        /// </summary>
        public string DeveloperName { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public HydraAppVersionModel AppVersion { get; set; }
    }

    public class HydraAppVersionModel
    {
        /// <summary>
        /// when you make incompatible API changes
        /// </summary>
        public int Major { get; set; }

        /// <summary>
        /// when you add functionality in a backwards-compatible manner
        /// </summary>
        public int Minor { get; set; }

        /// <summary>
        /// when you make backwards-compatible bug fixes
        /// </summary>
        public int Patch { get; set; }

        public override string ToString()
        {
            return this.Major.ToString() + "." +
                this.Minor.ToString() + "." + this.Patch.ToString();
        }
    }
}