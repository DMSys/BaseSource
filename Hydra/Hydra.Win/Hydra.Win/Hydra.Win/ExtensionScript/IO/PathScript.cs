using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Hydra.Win.ExtensionScript.IO
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public class PathScript
    {
        /// <summary>
        /// Determines whether the specified file exists.
        /// </summary>
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        /// <summary>
        /// Returns the names of files (including their paths) in the specified directory.
        /// </summary>
        public string GetFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            if (files.Length > 0)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(files[0]);
                for (int i = 1; i < files.Length; i++)
                {
                    sb.Append("," + files[i]);
                }
                return sb.ToString();
            }
            else
            { return ""; }
        }

        /// <summary>
        /// Copies an existing file to a new file. Overwriting a file of the same name is allowed.
        /// </summary>
        public void FileCopy(string sourceFileName, string destFileName, bool overwrite)
        {
            File.Copy(sourceFileName, destFileName, overwrite);
        }

        /// <summary>
        /// Deletes the specified file.
        /// </summary>
        public void FileDelete(string path)
        {
            File.Delete(path);
        }

        /// <summary>
        /// Moves a specified file to a new location, providing the option to specify a new file name.
        /// </summary>
        public void FileMove(string sourceFileName, string destFileName)
        {
            File.Move(sourceFileName, destFileName);
        }

        /// <summary>
        /// Returns the extension of the specified path string.
        /// </summary>
        public string GetExtension(string path)
        {
            return Path.GetExtension(path);
        }

        /// <summary>
        /// Returns the file name and extension of the specified path string.
        /// </summary>
        public string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }

        /// <summary>
        /// Returns the file name of the specified path string without the extension.
        /// </summary>
        public string GetFileNameWithoutExtension(string path)
        {
            return Path.GetFileNameWithoutExtension(path);
        }
    }
}
