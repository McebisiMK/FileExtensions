using System;
using Autofac;
using FilesSizeByExtensions.FileExtensions;
using FilesSizeByExtensions.SpaceCalculator;

namespace FileExtensions
{
    class Program
    {
        private static string files = "1 music.mp3 45b\nmusic.wma 56b\nmusic.wav 56b\nimages.png 67b\nimages.gif 45b\nimages.jpeg 10b\nvideo.mov 98b\nvideo.flv 34b\nvideo.mp4 67b\nother.zip 45b\nother.rar 90b\nother.mix 67b";
        static void Main(string[] args)
        {
            var container = Container();
            var extensions = container.Resolve<IExtensions>();
            var fileSpaceCalculator = container.Resolve<IFileSpaceCalculator>();

            var musicSpace = fileSpaceCalculator.GetOccupiedSpace(files, extensions.GetMusic());
            var imagesSpace = fileSpaceCalculator.GetOccupiedSpace(files, extensions.GetImages());
            var videosSpace = fileSpaceCalculator.GetOccupiedSpace(files, extensions.GetVideos());
            var otherSpace = fileSpaceCalculator.GetOccupiedSpace(files, extensions.GetOther(files));

            Display(musicSpace, imagesSpace, videosSpace, otherSpace);
            Console.ReadKey();
        }

        private static IContainer Container()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<Modules>();

            return containerBuilder.Build();
        }

        private static void Display(int musicSpace, int imagesSpace, int videosSpace, int otherSpace)
        {
            Console.WriteLine($"Music Files: {musicSpace} \nImage Files: {imagesSpace} \nVideo Files: {videosSpace} \nOther Files: {otherSpace}");
        }
    }
}
