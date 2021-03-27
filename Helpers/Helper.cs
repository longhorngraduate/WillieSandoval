using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillieSandoval_2_28_2021.Helpers
{
    public class Helper
    {
        [HttpGet]
        public static string GetFileContents(string path)
        {
            string readText = "Error";

            if (!System.IO.File.Exists(path))
            {
                //// Create a file to write to.
                //string createText = "Hello and Welcome" + Environment.NewLine;
                //System.IO.File.WriteAllText(path, createText, Encoding.UTF8);
                return "Error - File Doesn't Exist.";
            }

            //string appendText = "This is extra text" + Environment.NewLine;
            //System.IO.File.AppendAllText(path, appendText, Encoding.UTF8);

            try
            {
                // Open the file to read from.
                readText = System.IO.File.ReadAllText(path);
                //Console.WriteLine(readText);
            }
            catch (Exception exc)
            {
                return "Error - Exception when reading.";
            }

            return readText;
        }
    }
}
