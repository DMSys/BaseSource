using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HydraCompiler
{
    public class HCompiler: IDisposable
    {
        #region Properties

        private string _WorkspacePath = "";
        /// <summary>
        /// Път до файловете на проекта
        /// </summary>
        public string WorkspacePath
        {
            get
            { return _WorkspacePath; }
            set
            { _WorkspacePath = value; }
        }

        private string _OutputPath = "";
        /// <summary>
        /// Резултат от компилацията
        /// </summary>
        public string OutputPath
        {
            get
            { return _OutputPath; }
            set
            { _OutputPath = value; }
        }

        private string _TypingsPath = "";
        /// <summary>
        /// Път до файловете на DefinitelyTyped
        /// </summary>
        public string TypingsPath
        {
            get
            { return _TypingsPath; }
            set
            { _TypingsPath = value; }
        }

        private int _BuildSucceeded = 0;
        /// <summary>
        /// Успешно компи
        /// </summary>
        public int BuildSucceeded
        {
            get
            { return _BuildSucceeded; }
        }

        private int _BuildFailed = 0;
        /// <summary>
        /// Грешки при компилация
        /// </summary>
        public int BuildFailed
        {
            get
            { return _BuildFailed; }
        }

        private int _BuildSkipped = 0;
        /// <summary>
        /// Прескочени файлове при компилация
        /// </summary>
        public int BuildSkipped
        {
            get
            { return _BuildSkipped; }
        }

        #endregion Properties

        public void Dispose()
        { }

        public void Build()
        {    
            _BuildSucceeded = 0;
            _BuildFailed = 0;
            _BuildSkipped = 0;
            try
            {
                // Синхронизира файловете DefinitelyTyped
                SynchDefinitelyTyped(_TypingsPath, _WorkspacePath);
            }
            catch (Exception ex)
            {
                _BuildFailed += 1;
                Console.WriteLine(ex.Message);
            }
            try
            {
                // Компилира проекта
                HCompilerConfig compilerConfig = new HCompilerConfig()
                {
                    ProjectName = "",
                    WorkspacePath = _WorkspacePath,
                    OutputPath = _OutputPath
                };
                BuildProject(compilerConfig);
            }
            catch (Exception ex)
            {
                _BuildFailed += 1;
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Зарежда конфигурационния файл
        /// </summary>
        private HydraConfig LoadHydraConfig(string fileName)
        {
            if (File.Exists(fileName))
            {
                System.Web.Script.Serialization.JavaScriptSerializer serializer =
                    new System.Web.Script.Serialization.JavaScriptSerializer();

                string json = File.ReadAllText(fileName);

                return (HydraConfig)serializer.Deserialize(json, typeof(HydraConfig));
            }
            else
            { return null; }
        }

        /// <summary>
        /// Компилира проект
        /// </summary>
        private void BuildProject(HCompilerConfig compilerConfig)
        {
            // Зарежда локалните настройки
            string hydraConfigPath = Path.Combine(_WorkspacePath, "hydra.config.json");
            HydraConfig hydraConfig = LoadHydraConfig(hydraConfigPath);
            compilerConfig.SetHydraConfig(hydraConfig);
            // Компилира файловете
            BuildDirectoryFiles(compilerConfig);

            // Компилира подпроектите
            foreach (string srcProject in Directory.GetDirectories(compilerConfig.WorkspacePath))
            {
                string projectName = srcProject.Substring(compilerConfig.WorkspacePath.Length + 1
                    , srcProject.Length - compilerConfig.WorkspacePath.Length - 1);

                if (projectName.StartsWith("."))
                { _BuildSkipped += 1; }
                else
                {
                    PrintBuildLine(compilerConfig.ProjectName, projectName);

                    HCompilerConfig compilerConfigProject = new HCompilerConfig()
                    {
                        ProjectName = (String.IsNullOrWhiteSpace(compilerConfig.ProjectName) ? "" : compilerConfig.ProjectName + Path.DirectorySeparatorChar)
                                        + projectName,
                        WorkspacePath = srcProject,
                        OutputPath = Path.Combine(compilerConfig.OutputPath, projectName),
                        LayoutPath = compilerConfig.LayoutPath,
                        ViewTitle = compilerConfig.ViewTitle
                    };
                    Directory.CreateDirectory(compilerConfigProject.OutputPath);
                    BuildProject(compilerConfigProject);
                }
            }
        }

        /// <summary>
        /// Компилира файловете от директория
        /// </summary>
        private void BuildDirectoryFiles(HCompilerConfig compilerConfig)
        {
            string[] srcFilels = Directory.GetFiles(compilerConfig.WorkspacePath);

            foreach (string srcFile in srcFilels)
            {
                string nameFile = Path.GetFileName(srcFile);
                string nameFileUni = nameFile.ToLower();
                if ( (nameFileUni.StartsWith("_")) || (nameFileUni == "hydra.config.json") )
                { _BuildSkipped += 1; }
                else if (nameFileUni.EndsWith(".html") || nameFileUni.EndsWith(".htm"))
                {
                    PrintBuildLine(compilerConfig.ProjectName, nameFile);

                    string outFile = Path.Combine(compilerConfig.OutputPath, nameFile);
                    BuildFileHTML(srcFile, outFile, compilerConfig);
                    _BuildSucceeded += 1;
                }
                else if (nameFileUni.EndsWith(".js"))
                {
                    PrintBuildLine(compilerConfig.ProjectName, nameFile);

                    string outFile = Path.Combine(compilerConfig.OutputPath, nameFile);
                    File.Copy(srcFile, outFile, true);
                    _BuildSucceeded += 1;
                }
                else if (nameFileUni.EndsWith(".css"))
                {
                    PrintBuildLine(compilerConfig.ProjectName, nameFile);

                    string outFile = Path.Combine(compilerConfig.OutputPath, nameFile);
                    File.Copy(srcFile, outFile, true);
                    _BuildSucceeded += 1;
                }
                else
                {
                    PrintBuildLine(compilerConfig.ProjectName, nameFile);

                    string outFile = Path.Combine(compilerConfig.OutputPath, nameFile);
                    File.Copy(srcFile, outFile, true);
                    _BuildSucceeded += 1;
                }
            }
        }

        /// <summary>
        /// Компилира файл
        /// </summary>
        private void BuildFileHTML(string sourceFile, string outputFile, HCompilerConfig compilerConfig)
        {
            // Зарежда страницата
            string sourceCode = "";
            using (TextReader reader = File.OpenText(sourceFile))
            {
                sourceCode = reader.ReadToEnd();
                reader.Close();
            }
            // Взема параметрите от кода
            string viewTitle = null;
            string viewLayout = null;
            sourceCode = ExtractParameter(sourceCode, "@Title", out viewTitle);
            sourceCode = ExtractParameter(sourceCode, "@Layout", out viewLayout);
            // Валедира параметрите
            // ViewTitle
            if (viewTitle == null)
            { viewTitle = compilerConfig.ViewTitle; }
            // LayoutPath
            if (!String.IsNullOrWhiteSpace(viewLayout))
            { viewLayout = Path.Combine(compilerConfig.WorkspacePath, viewLayout); }
            else
            { viewLayout = compilerConfig.LayoutPath; }
            // Зарежда MasterPage, ако съществува
            if (!String.IsNullOrWhiteSpace(viewLayout) && File.Exists(viewLayout))
            {
                string layoutCode = "";
                using (TextReader reader = File.OpenText(viewLayout))
                {
                    layoutCode = reader.ReadToEnd();
                    reader.Close();
                }
                sourceCode = layoutCode.Replace("@RenderBody()", sourceCode);
            }
            // Добавя заглавие
            sourceCode = sourceCode.Replace("@View.Title", viewTitle);

            // Записва обработената страница
            using (StreamWriter writer = File.CreateText(outputFile))
            {
                writer.Write(sourceCode);
                writer.Flush();
                writer.Close();
            }
        }

        /// <summary>
        /// Взема ст-ста на параметъра и го премахва от кода
        /// </summary>
        private string ExtractParameter(string sourceCode, string parameterName, out string parameterValue)
        {
            parameterValue = null;          // Ст-ст на параметъра
            string resultSC = sourceCode;   // Ст-ст на параметъра
            int prmIndex = resultSC.IndexOf(parameterName);
            while (prmIndex != -1)
            {
                int prmStartIndex = prmIndex;
                prmIndex = -1;
                // Слеващия символ трябва да е '='
                int prmValueIndex = GoToNextChar(resultSC, prmStartIndex + parameterName.Length);
                if ((prmValueIndex != -1) && (resultSC[prmValueIndex] == '='))
                {
                    // Слеващия символ трябва да е '"'
                    prmValueIndex = GoToNextChar(resultSC, prmValueIndex + 1);
                    if ((prmValueIndex != -1) && (resultSC[prmValueIndex] == '"'))
                    {
                        if (resultSC[prmValueIndex] != '"')
                        { return resultSC; }
                        // Зарежда стойноста на параметъра
                        parameterValue = GetStringValue(resultSC, prmValueIndex + 1);
                        // Премахва параметъра
                        int prmEndIndex = prmValueIndex + parameterValue.Length + 2;
                        // Премахва параметъра от кода
                        resultSC =
                            resultSC.Substring(0, prmStartIndex).Trim() +
                            resultSC.Substring(prmEndIndex, resultSC.Length - prmEndIndex).Trim();
                        // Tърси следващия
                        prmIndex = resultSC.IndexOf(parameterName);
                    }
                }
            }
            return resultSC;
        }

        /// <summary>
        /// Отива до следващия символ
        /// </summary>
        private int GoToNextChar(string sourceCode, int fromIndex)
        {
            for (int i = fromIndex; i < sourceCode.Length; i++)
            {
                if (sourceCode[i] != ' ')
                { return i; }
            }
            return -1;
        }

        /// <summary>
        /// Отива до следващия символ
        /// </summary>
        private string GetStringValue(string sourceCode, int fromIndex)
        {
            StringBuilder prmValue = new StringBuilder();
            for (int i = fromIndex; i < sourceCode.Length; i++)
            {
                if (sourceCode[i] == '"')
                { return prmValue.ToString(); }
                else
                { prmValue.Append(sourceCode[i]); }
            }
            return prmValue.ToString();
        }

        /// <summary>
        /// Принтира името на компилирания файл
        /// </summary>
        private void PrintBuildLine(string projectName, string buildName)
        {
            if (String.IsNullOrWhiteSpace(projectName))
            { Console.WriteLine(buildName); }
            else
            { Console.WriteLine(projectName + Path.DirectorySeparatorChar + buildName); }
        }

        /// <summary>
        /// Синхронизира файловете DefinitelyTyped
        /// </summary>
        private void SynchDefinitelyTyped(string typingsPath, string workspacePath)
        {
            if (String.IsNullOrWhiteSpace(typingsPath))
            { return; }
            if (!Directory.Exists(typingsPath))
            {
                Console.WriteLine("Path '{0}' not exist", typingsPath);
                return; 
            }

            string workspaceTypingsPath = Path.Combine(workspacePath, ".typings");
            if (!Directory.Exists(workspaceTypingsPath))
            { Directory.CreateDirectory(workspaceTypingsPath); }

            string[] dtsFilels = Directory.GetFiles(typingsPath, "*.d.ts");
            foreach (string dtsFile in dtsFilels)
            {
                string wsFileName = Path.GetFileName(dtsFile);
                string wsFilePath = Path.Combine(workspaceTypingsPath, wsFileName);
                
                if (File.Exists(wsFilePath))
                {
                    string dtsFileMD5 = "";
                    long dtsFileLength = 0;
                    string wsFileMD5 = "";
                    long wsFileLength = 0;
                    using (var md5 = System.Security.Cryptography.MD5.Create())
                    {
                        using (var stream = File.OpenRead(dtsFile))
                        {
                            dtsFileLength = stream.Length;
                            dtsFileMD5 = BitConverter.ToString(md5.ComputeHash(stream));
                        }
                        using (var stream = File.OpenRead(wsFilePath))
                        {
                            wsFileLength = stream.Length;
                            wsFileMD5 = BitConverter.ToString(md5.ComputeHash(stream));
                        }
                        if ((dtsFileLength != wsFileLength) || (!dtsFileMD5.Equals(wsFileMD5)))
                        {
                            File.Copy(dtsFile, wsFilePath, true);
                            Console.WriteLine("DefinitelyTyped: {0}", wsFileName);
                        }
                    }
                }
                else
                {
                    File.Copy(dtsFile, wsFilePath);
                    Console.WriteLine("DefinitelyTyped: {0}", wsFileName);
                }
            }
        }
    }
}
