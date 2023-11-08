using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace UpdaterFiles
{
    public class Migrator
    {
        private IGetterInfoFiles _myGetterList;
    
        public Migrator(IGetterInfoFiles myGetterList) 
        {
            _myGetterList = myGetterList;
        }

        public void CopyFiles()
        { 
            var files = _myGetterList.GetFiles();
            foreach (var item in files)
            {
                RunRobocopy(@$"{item.Source}", @$"{ item.DestinationFolder}", item.Name, "/S /E /MT:32");
            }

        }

        /// <summary>
        /// Robocoppy faster copy.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        /// <param name="options"></param>
        private static void RunRobocopy(string sourceFile, string destinationFolder, string nameFile ,string options)
        {
            Process robocopyProcess = new Process();

            robocopyProcess.StartInfo.FileName = "robocopy.exe"; // The name of the Robocopy executable
            robocopyProcess.StartInfo.Arguments = $"\"{sourceFile}\" \"{destinationFolder}\" \"{nameFile}\" /COPY:DAT"; // Use appropriate options for your needs
            robocopyProcess.StartInfo.UseShellExecute = false;
            robocopyProcess.StartInfo.RedirectStandardOutput = true;
            robocopyProcess.StartInfo.CreateNoWindow = true;

            robocopyProcess.Start();

            string output = robocopyProcess.StandardOutput.ReadToEnd();

            robocopyProcess.WaitForExit();

            Console.WriteLine(output); // You can process or log the output as needed
        }
    }
}
