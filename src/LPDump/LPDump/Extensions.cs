using System.Diagnostics;
using System.IO;

namespace LPDump
{
    public static class Extensions
    {
        public static T Dump<T>(this T source)
        {
            var localUrl = Path.GetTempFileName() + ".html";
            using (var writer = LINQPad.Util.CreateXhtmlWriter(true))
            {
                writer.Write(source);
                File.WriteAllText(localUrl, writer.ToString());
            }
            Process.Start(localUrl);
            return source;
        }
    }
}
