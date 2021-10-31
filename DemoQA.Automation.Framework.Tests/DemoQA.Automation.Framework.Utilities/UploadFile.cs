using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace DemoQA.Automation.Framework.Utilities
{
    public static class UploadFile
    {
        /// <summary>
        /// Gets path files in framework.
        /// </summary>
        /// <returns>Path file.</returns>
        public static string FilesPath
        {
            get
            {
                string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                assemblyFolder = assemblyFolder.Split(new string[] { "file:\\" }, StringSplitOptions.None)[1];
                return assemblyFolder + "\\Data\\Files";
            }
        }

        /// <summary>
        /// Method to attach files given its name.
        /// </summary>
        /// <param name="files">File names</param>
        public static void UploadFiles(params string[] files)
        {
            string filePath = string.Empty;
            string assemblyFolder = FilesPath;
            int index = 1;
            foreach (var item in files)
            {
                string fullPath = Path.Combine(assemblyFolder, item);
                filePath = index < files.Length ? filePath + "\"" + fullPath + "\" " :
                     filePath + "\"" + fullPath + "\"";
                index++;
            }

            Thread.Sleep(2000);

            // Entering paths on wizard window
            SendKeys.SendWait("{ENTER}");
            SendKeys.SendWait(filePath);
            SendKeys.SendWait("{ENTER}");
        }
    }
}
