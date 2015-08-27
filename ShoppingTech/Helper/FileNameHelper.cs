using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;

namespace ShoppingTech.Helper
{
    public class FileNameHelper
    {
        public static string GetFileNameFromLocalPath(string path)
        {
            char[] charSeparators = new char[] { '\\' };
            string[] result = path.Split(charSeparators, StringSplitOptions.None);
            var idx = result.Length;
            return result[idx - 1];
        }
    }
}