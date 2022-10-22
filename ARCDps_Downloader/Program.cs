using System;
using System.IO;
using System.Net;

namespace ARCDps_Downloader
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const string src_path = "https://www.deltaconnected.com/arcdps/x64/d3d11.dll";
            const string dst_path = @"E:\Guild Wars 2\bin64\d3d11.dll";
            const string new_name = @"E:\Guild Wars 2\bin64\d3d9.dll";
            GW2ExtDownloader(src_path, dst_path);
            Rename(dst_path, new_name);
        }

        private static void GW2ExtDownloader(string src_path, string dst_path)
        {
            using (WebClient client = new WebClient())
            {
                Console.WriteLine("\n=== GW2 arcDPS Downloader @ZL, 20210924 ===");
                Console.WriteLine("started..");

                if (!File.Exists(src_path))
                {
                    if (File.Exists(dst_path)) { File.Delete(dst_path); }
                    client.DownloadFile(src_path, dst_path);
                    Console.WriteLine("dst Updated: {0}", Directory.GetParent(dst_path));
                }
                else
                {
                    Console.WriteLine("src PathNotFound: {0}", Directory.GetParent(src_path));
                }
            }
        }

        private static void Rename(string old_name, string new_name)
        {
            if(File.Exists(new_name))
            {
                File.Delete(new_name);
            }
            File.Move(old_name, new_name);
        }
    }
}
