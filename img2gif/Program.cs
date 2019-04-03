using System;
using System.Drawing;
using System.IO;
using System.Linq;
using AnimatedGif;

namespace img2gif
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]) && File.Exists(args[0].Replace("\"", "")))
            {
                var ImagePath = args[0].Replace("\"", "");
                var GifPath = args[0].Remove(args[0].LastIndexOf('\\'));

                var FileName = args[0].Split('\\').Last();
                var GifName = $"{FileName.Remove(FileName.LastIndexOf('.'))}.gif";

                var DestGifPath = Path.Combine(GifPath, GifName);

                try
                {
                    using (var gif = AnimatedGif.AnimatedGif.Create(DestGifPath, 3000, 3))
                    {
                        var img = Image.FromFile(ImagePath);
                        gif.AddFrame(img, -1, GifQuality.Bit8);
                    }

                    if(File.Exists(DestGifPath))
                        Console.Write(DestGifPath);
                }
                catch { }
            }
            else
            {
                Console.Write("Usage: img2gif.exe \"C:\\path\\to\\img.jpg\"");
            }
        }
        
    }
}
