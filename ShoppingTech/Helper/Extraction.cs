using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace ShoppingTech.Helper
{
    public class Extraction
    {
        public static string ExtractValue(string key, NameValueCollection formData)
        {
            if (formData == null) return null;
            if (formData.AllKeys.Contains(key))
            {
                var result = formData.GetValues(key);
                return result == null ? null : result[0];
            }
            return null;
        }
    }
}