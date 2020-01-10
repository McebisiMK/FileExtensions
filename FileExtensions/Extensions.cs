using System;
using System.Collections.Generic;
using System.Linq;

namespace FilesSizeByExtensions.FileExtensions
{
    public class Extensions : IExtensions
    {
        public List<string> GetMusic()
        {
            var musicExtensions = new List<string> { ".mp3", ".wma", ".wav" };

            return musicExtensions;
        }

        public List<string> GetImages()
        {
            var imagesExtensions = new List<string> { ".png", ".jpeg", ".gif" };

            return imagesExtensions;
        }

        public List<string> GetVideos()
        {
            var videosExtensions = new List<string> { ".mov", ".flv", ".mp4" };

            return videosExtensions;
        }

        public List<string> GetOther(string files)
        {
            var musicExtensions = GetMusic();
            var imagesExtensions = GetImages();
            var videosExtensions = GetVideos();
            var otherExtensions = GetOtherExtensions(files, musicExtensions, imagesExtensions, videosExtensions);

            return otherExtensions;
        }

        private List<string> GetOtherExtensions(string files, List<string> music, List<string> images, List<string> videos)
        {
            var allExtensions = GetAllExtensions(files);
            var otherExtensions = allExtensions
                                    .Where(extension => !music.Contains(extension))
                                    .Where(extension => !images.Contains(extension))
                                    .Where(extension => !videos.Contains(extension))
                                    .ToList();

            return otherExtensions;
        }

        private List<string> GetAllExtensions(string files)
        {
            var allExtensions = files
                                .Split("\n")
                                .Select(
                                            file => file
                                                    .Split('.')
                                                    .Last()
                                                    .Split(' ')
                                                    .First()
                                        )
                                .Select(extension => $".{extension}")
                                .ToList();

            return allExtensions;
        }
    }
}