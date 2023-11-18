using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Sept2023WebAppMVC.Utilities
{
    public static class Loger
    {
        public static void Log(string message)
        {

            //string filePath = @"D:\Rajashekar\Test\";
            string filePath = ConfigurationManager.AppSettings["FilePath"].ToString();
            string filename = $"Loger {DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")}.txt";
            string combinedPath = filePath + filename;
            //if (!File.Exists(combinedPath))
            //{
            //    File.Create(combinedPath);
            //}

            // Create the file, or overwrite if the file exists.
            using (FileStream fs = File.Create(combinedPath))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(DateTime.Now.ToString() + " " + message);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }

            // Open the stream and read it back.
            using (StreamReader sr = File.OpenText(combinedPath))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

            //if (!File.Exists(combinedPath))
            //{
            //    File.Create(combinedPath);
            //}
            //StringBuilder sb = new StringBuilder();

            //sb.Append(DateTime.Now.ToString());
            //sb.Append(" ");
            //sb.Append(message);
            //File.AppendAllText(combinedPath, sb.ToString());
            //sb.Clear();


            //sb.Clear();

            //using (StreamWriter writer = new StreamWriter(combinedPath))
            //{
            //    writer.Write(sb.ToString());
            //}

            //using (var stream = File.OpenWrite(combinedPath))
            //{
            //    stream.Write(sb.ToString());
            //};  //File is automatically closed when done, even on error

            ////File is never properly closed
            //var stream2 = File.OpenWrite(mainPath);
            //stream2.Close(); //Don't do this as it is not exception safe

            //////Will fail because file is already open, doesn't matter that it is the same process
            ////var stream3 = File.OpenWrite(mainPath);
        }

        public static void LogerMessage(string controller, string actionMethod, string message)
        {
            string msg = $"{ controller}/{actionMethod} {message}";
            Log(msg);
        }

        public static void LogerMessage(string controller, string actionMethod, long executionTime)
        {
            string msg = $"Aciton execution { controller}/{actionMethod}  took time {executionTime} ms";
            Log(msg);
        }
    }
}