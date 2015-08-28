using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ShoppingTech.Helper
{
    public class FileHelper
    {
        public static bool DeleteFile(string path)
        {
            if (!File.Exists(path)) return false;
            try
            {
                File.Delete(path);
                return true;
            }
            catch (IOException e)
            {                    
                return false;
            }            
        }
    }
}