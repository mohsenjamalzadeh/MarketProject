using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _0_Framework.Application
{
    public static class Tools
    {

        private static readonly string urlPattern = "[^a-zA-Z0-9-.]";

        public static string Slugify(this string url)
        {
            var friendlyUrl = Regex.Replace(url, @"\s", "-").ToLower();
            friendlyUrl = Regex.Replace(friendlyUrl, urlPattern, string.Empty);

            return friendlyUrl;
        }
    }
}