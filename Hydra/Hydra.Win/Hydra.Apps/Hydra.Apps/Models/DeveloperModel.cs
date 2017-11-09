using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hydra.Apps.Models
{
    public class DevelopersModel : List<DeveloperModel>
    {
    }

    public class DeveloperModel
    {
        public int DevId { get; set; }

        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}