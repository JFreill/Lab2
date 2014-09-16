using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Lab2
{
    public partial class Manual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string LocalHostDir = "C:/Users/James/Documents/Visual Studio 2013/Projects/.NET Workspace/Lab2";
            string ProjectDir = "~";

            try
            {
                string[] path = System.IO.Directory.GetDirectories(LocalHostDir);
                ProcessDirectory(path, LocalHostDir);
            }
            catch (Exception ex)
            {
                Response.Write("Local Host not connected ( Caught Exception! ), Attemptting to query server instance...<br /><b>Exception print out:</b> <i>" + ex.ToString() + "</i><br /><br /><b>Server instance is being queried...</b><br />");
                try
                {
                    string[] path = System.IO.Directory.GetDirectories(Server.MapPath("~"));
                    ProcessDirectory(path, ProjectDir);
                }
                catch (Exception ex1)
                {
                    Response.Write("Attempted to query server instance and failed...<br /><b>Exception print out:</b> <i>" + ex1.ToString() + "</i><br />");
                } 
            } 
            
        }

        /// <summary>
        /// Author: James Freill
        /// uses a foreach loop to properly go though the directory of the root project.
        /// </summary>
        /// <param name="path"></param>
        public void ProcessDirectory(string[] path, string dirLocation)
        {
            foreach (string dir in path)
            {
                if (File.Exists(dir))
                {
                    // This is a File, Prints file attributes.
                    GetFileInfo(dir);
                } 
                else if (Directory.Exists(dir))
                {
                    // This is a directory.
                    GetDirectories(dir);
                }
                else
                {
                    // Error check to make sure the directory is valid.
                    Response.Write("There we no files in this directory, OR it was a invalid directory...");                    
                }
            }
            Response.Write("<br /><b>Total size of the Directory is: " + GetDirSize(dirLocation) + "MB</b>");
        }

        /// <summary>
        /// Author: James Freill
        /// Lists files, and sub directories within the target directory that has been passed in.
        /// Uses: System.IO.Directory.GetFiles();
        /// </summary>
        /// <param name="directory"></param>
        public void GetDirectories(string directory)
        {
            Response.Write("<br /><b>DIRECTORY NAME: " + directory + "</b><br />");   
            // List of files found within the directory.            
            string[] fileList = Directory.GetFiles(directory);
            if (fileList.Count() == 0)
            {
                Response.Write("<br />Directory is empty...<br />");
            }
            foreach (string fileName in fileList)
            {
                GetFileInfo(fileName);
            }          
            // Using recursion to go through subdirectories.
            string[] subDirs = Directory.GetDirectories(directory);
            foreach (string dir in subDirs)
            {
                GetDirectories(dir);
            }
        }

        /// <summary>
        /// Author: James Freill
        /// Lists a files attributes:
        /// Name
        /// Length
        /// Full Name
        /// Directory Name
        /// Extension
        /// uses System.IO.FileInfo() to get file attributes.
        /// </summary>
        /// <param name="file"></param>
        public void GetFileInfo(string file)
        {
            FileInfo fileInfo = new System.IO.FileInfo(file);
            Response.Write("<br />Name: " + fileInfo.Name + "<br />");
            Response.Write("Length: " + fileInfo.Length + "<br />");
            Response.Write("Full Name: " + fileInfo.FullName + "<br />");
            Response.Write("Directory Name: " + fileInfo.DirectoryName + "<br />");
            Response.Write("Extension: " + fileInfo.Extension + "<br />");
        }

        /// <summary>
        /// Author: James Freill
        /// gathers size of all directories listed by passed in path locaton.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public float GetDirSize(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            long size = 0;
            foreach(string file in Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
            {
                size += new FileInfo(file).Length;
            }
            return size / 1000000f;
        }


    }
}
