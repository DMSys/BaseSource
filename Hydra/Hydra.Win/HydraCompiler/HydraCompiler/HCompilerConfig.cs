using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HydraCompiler
{
    public class HCompilerConfig
    {
        public string ProjectName { get; set; }

        public string LayoutPath { get; set; }

        public string ViewTitle { get; set; }

        public string WorkspacePath { get; set; }

        public string OutputPath { get; set; }

        public void SetHydraConfig(HydraConfig hydraConfig)
        {
            if (hydraConfig != null)
            {
                if (!String.IsNullOrWhiteSpace(hydraConfig.Layout))
                {
                    this.LayoutPath = System.IO.Path.Combine(this.WorkspacePath, hydraConfig.Layout);
                }
                if (!String.IsNullOrWhiteSpace(hydraConfig.Title))
                {
                    this.ViewTitle = hydraConfig.Title;
                }
            }
        }
    }
}