#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

#endregion

namespace Achilles.Acme.Content.Helpers
{
    public class SeoHelpers
    {
        static IDictionary<string, Regex> SeoTitleRegex = new Dictionary<string, Regex>()
            {
               { "SeoTitleReplace", new Regex("([^a-z0-9-_]?)",RegexOptions.IgnoreCase | RegexOptions.Compiled )}
            };

        public static string SeoFriendlyTitle( string value )
        {
            string seoTitle = "";

            if ( !string.IsNullOrEmpty( value ) )
            {
                Regex regex = SeoTitleRegex["SeoTitleReplace"];

                seoTitle = value.Trim();
                seoTitle = seoTitle.Replace( ' ', '-' );
                seoTitle = seoTitle.Replace( "---", "-" );
                seoTitle = seoTitle.Replace( "--", "-" );

                if ( regex != null )
                {
                    seoTitle = regex.Replace( seoTitle, "" );
                }

                if ( seoTitle.Length * 2 < value.Length )
                {
                    return "";
                }

                if ( seoTitle.Length > 100 )
                {
                    seoTitle = seoTitle.Substring( 0, 100 );
                }
            }

            return seoTitle;
        }
    }
}
