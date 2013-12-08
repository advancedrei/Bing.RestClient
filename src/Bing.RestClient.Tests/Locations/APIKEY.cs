using System.IO;

namespace GeoCoderTests
{
    static class APIKEY
    {
        //#error either place you key in the file loaded below or return it directly here
        //#warning http://msdn.microsoft.com/en-us/library/ff701713.aspx
        private static readonly string _key;

        static APIKEY()
        {
            try
            {
                using (var file = File.OpenRead(@"D:\temp\bing.key.txt"))
                using (var reader = new StreamReader(file))
                    _key = reader.ReadLine();
            }
            catch
            {
                _key = "";
            }
        }

        public static string Key
        {
            get
            {
                return _key;
            }
        }
    }
}
