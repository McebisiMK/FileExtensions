using System.Collections.Generic;

namespace FilesSizeByExtensions.SpaceCalculator
{
    public interface IFileSpaceCalculator
    {
        int GetOccupiedSpace(string files, List<string> extensions);
    }
}