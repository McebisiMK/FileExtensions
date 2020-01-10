using System;
using System.Collections.Generic;
using System.Linq;
using FilesSizeByExtensions.Formatting;

namespace FilesSizeByExtensions.SpaceCalculator
{
    public class FileSpaceCalculator : IFileSpaceCalculator
    {
        private IFormatter _formatter;

        public FileSpaceCalculator(IFormatter formatter)
        {
            _formatter = formatter;
        }

        public int GetOccupiedSpace(string files, List<string> extensions)
        {
            var filesByCategory = GetFilesByCategory(files, extensions);
            var space = GetSpace(filesByCategory);

            return space.Sum(size => _formatter.Format(size));
        }

        private List<string> GetFilesByCategory(string files, List<string> extensions)
        {
            var filesByExtensions = files
                                    .Split("\n")
                                    .Where(file => extensions.Any(extension => file.Contains(extension)))
                                    .ToList();

            return filesByExtensions;
        }

        private List<string> GetSpace(List<string> filesByCategory)
        {
            return filesByCategory
                    .Select(file => file.Split(' ').Last())
                    .ToList();
        }
    }
}