using System;
using System.Drawing;
using System.IO;

namespace MYPOEPT2
{
    internal class Ascii_Logo
    {
        public Ascii_Logo()
        {
            string logo_path = AppDomain.CurrentDomain.BaseDirectory;


            string new_path = logo_path.Replace("bin\\Debug\\", "");


            string full_location = Path.Combine(new_path, "CYBERSECURITYY.png");

            // Checks if the file exists
            if (!File.Exists(full_location))
            {
                Console.WriteLine("Error: Image file not found at " + full_location);
                return;
            }

            //  For Loading and resize the image
            Bitmap image = new Bitmap(full_location);
            image = new Bitmap(image, new Size(70, 50));


            Console.ForegroundColor = ConsoleColor.DarkYellow;



            for (int height = 0; height < image.Height; height++)
            {
                for (int width = 0; width < image.Width; width++)
                {
                    Color Pixel_Color = image.GetPixel(width, height);
                    int white = (Pixel_Color.R + Pixel_Color.G + Pixel_Color.B) / 3;
                    char asciiChar = white > 200 ? '.' : white > 150 ? '*' : white > 100 ? 'o' : white > 50 ? '#' : '@';
                    Console.Write(asciiChar);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
        