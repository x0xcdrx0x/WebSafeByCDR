using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace RemoveJewishScum
{

    public partial class Installer : Form
    {
        public string windir = Environment.SystemDirectory;
        public string tempPath = System.IO.Path.GetTempPath();
        public string Desktop = System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
        public Installer()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string AntiPornPatch = tempPath + @"\AntiPornSoft";
            Directory.Delete(AntiPornPatch, true);
            MessageBox.Show("Deleting Completed!", "Success..", MessageBoxButtons.OK);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Declare all needed strings
            string patch = "patch.exe";
            string setup = "setup.exe";
            string AntiPornPatch = tempPath + @"\AntiPornSoft";
            string sourcePathPatch = AntiPornPatch;
            string targetPathPatch = Desktop ;
            string sourcePathSetup = AntiPornPatch;
            string targetPathSetup = Desktop;

            // Use Path class to manipulate file and directory paths. 
            string sourceFilePatch = System.IO.Path.Combine(sourcePathPatch, patch);
            string destFilePatch = System.IO.Path.Combine(targetPathPatch, patch);
            string sourceFileSetup = System.IO.Path.Combine(sourcePathSetup, patch);
            string destFileSetup = System.IO.Path.Combine(targetPathSetup, patch);
            
            //For the Patch
            if (!System.IO.Directory.Exists(targetPathPatch))
            {
                System.IO.Directory.CreateDirectory(targetPathPatch);
            }

            //For the Setup
            if (!System.IO.Directory.Exists(targetPathSetup))
            {
                System.IO.Directory.CreateDirectory(targetPathSetup);
            }

            //For the Patch
            System.IO.File.Copy(sourceFilePatch, destFilePatch, true);

            if (System.IO.Directory.Exists(sourcePathPatch))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePathPatch);

                // Copy the files and overwrite destination files if they already exist. 
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    patch = System.IO.Path.GetFileName(s);
                    destFilePatch = System.IO.Path.Combine(targetPathPatch, patch);
                    System.IO.File.Copy(s, destFilePatch, true);
                }
            }

            //For the Setup
            System.IO.File.Copy(sourceFileSetup, destFileSetup, true);

            if (System.IO.Directory.Exists(sourcePathSetup))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePathSetup);

                // Copy the files and overwrite destination files if they already exist. 
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    setup = System.IO.Path.GetFileName(s);
                    destFileSetup = System.IO.Path.Combine(targetPathSetup, setup);
                    System.IO.File.Copy(s, destFileSetup, true);
                }
            }

            MessageBox.Show("The Setup file and Patch are Successfully copied to Your Desktop", "Success..", MessageBoxButtons.OK);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(tempPath + @"\AntiPornSoft\setup.exe");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process.Start(tempPath + @"\AntiPornSoft\patch.exe");
        }
    }
}
