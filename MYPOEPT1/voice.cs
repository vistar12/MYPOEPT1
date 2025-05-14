using System;
using System.IO;
using System.Media;

namespace MYPOEPT2
{
    public class voice
    {
        public voice()
        {
            string fullpath = AppDomain.CurrentDomain.BaseDirectory;

            Console.WriteLine(fullpath);

            string newLocation = fullpath.Replace("bin\\Debug", "");

            try
            {
                string full_path = Path.Combine(newLocation, "my record.wav");
                using (SoundPlayer myplayer = new SoundPlayer(full_path))
                {
                    myplayer.PlaySync();
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
    