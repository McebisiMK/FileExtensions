using System.Collections.Generic;

namespace FilesSizeByExtensions.FileExtensions
{
    public interface IExtensions
    {
        List<string> GetMusic();
        List<string> GetImages();
        List<string> GetVideos();
        List<string> GetOther(string files);
    }
}