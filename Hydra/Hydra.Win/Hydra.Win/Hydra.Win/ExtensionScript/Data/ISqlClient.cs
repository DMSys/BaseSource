using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hydra.Win.ExtensionScript.Data
{
    interface ISqlClient
    {
        void Open();

        string ExecuteReader(LinqQueryModel linqQuery);
    }
}
