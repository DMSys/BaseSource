using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HydraCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            string workspacePath = "";
            string outputPath = "";
            string typingsPath = "";            
            Console.WriteLine("Build started: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            // Входни параметри
            foreach (string arg in args)
            {
                int indexEndParаm = arg.IndexOf(':');
                // Трябва да има име на параметър
                if (indexEndParаm > 1)
                {
                    string nameParam = arg.Substring(0, indexEndParаm).Trim().ToLower();
                    switch (nameParam)
                    {
                        case "/workspace":
                            workspacePath = arg.Substring(indexEndParаm + 1, arg.Length - (indexEndParаm + 1)).Trim();
                            workspacePath = workspacePath.TrimEnd(System.IO.Path.DirectorySeparatorChar);
                            break;
                        case "/output":
                            outputPath = arg.Substring(indexEndParаm + 1, arg.Length - (indexEndParаm + 1)).Trim();
                            outputPath = outputPath.TrimEnd(System.IO.Path.DirectorySeparatorChar);
                            break;
                        case "/typings":
                            typingsPath = arg.Substring(indexEndParаm + 1, arg.Length - (indexEndParаm + 1)).Trim();
                            typingsPath = typingsPath.TrimEnd(System.IO.Path.DirectorySeparatorChar);
                            break;
                    }
                    
                }
            }
            // Валидира входните параметри
            if (System.IO.Directory.Exists(workspacePath))
            { Console.WriteLine("Build workspace: " + workspacePath); }
            else
            {
                Console.WriteLine("Workplace '" + workspacePath + "' is invalid");
                return;
            }
            if (System.IO.Directory.Exists(outputPath))
            { Console.WriteLine("Output path: " + outputPath); }
            else
            {
                Console.WriteLine("Output path '" + outputPath + "' is invalid");
                return;
            }
            using (HCompiler compiler = new HCompiler())
            {
                compiler.WorkspacePath = workspacePath;
                compiler.OutputPath = outputPath;
                compiler.TypingsPath = typingsPath;

                compiler.Build();

                Console.WriteLine("Rebuild All: {0} succeeded, {1} failed, {2} skipped"
                    , compiler.BuildSucceeded, compiler.BuildFailed, compiler.BuildSkipped);
            }            
        }
    }
}
