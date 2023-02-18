using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Shared
{
    public static class clsGlobal
    {
        public static string gPasswordHash = "AnDr1devITV";
        public static string gSaltKey = "s@lT1Zk3ydevMGZ";
        public static string gVIKey = "@AzzeM81YydevLQJ";
        public const int gCompressIfStringLonger = 100000;
        public const string gMessageCommandSeperator = "||||/|";

        public static string LocalizePath(this string path)
        {
            return path.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);
        }

        public static string ReplaceInvalidFileNameCharacters(this string path, char replacement = '_')
        {
            var sanitized = path;

            foreach (var c in Path.GetInvalidFileNameChars())
            {
                sanitized = sanitized.Replace(c, replacement);
            }

            return sanitized;
        }

        public static string ToLocalRelativeFilename(this string remoteFilename)
        {
            if (string.IsNullOrWhiteSpace(remoteFilename))
            {
                throw new ArgumentException($"Invalid remote filename; expected a non-whitespace value, received '{remoteFilename}'", nameof(remoteFilename));
            }

            // normalize path separators
            var localizedRemoteFilename = LocalizePath(remoteFilename);

            var parts = localizedRemoteFilename.Split(Path.DirectorySeparatorChar);

            if (parts.Length == 1)
            {
                return ReplaceInvalidFileNameCharacters(parts.First());
            }

            var file = ReplaceInvalidFileNameCharacters(parts.Last());
            var directory = ReplaceInvalidFileNameCharacters(parts.Reverse().Skip(1).Take(1).Single());

            return Path.Combine(directory, file);
        }

        public static string ToLocalFilename(this string remoteFilename, string baseDirectory)
        {
            return Path.Combine(baseDirectory, ToLocalRelativeFilename(remoteFilename));
        }
        public static Stream GetLocalFileStream(string remoteFilename, string saveDirectory)
        {
            var localFilename = ToLocalFilename(remoteFilename, baseDirectory: saveDirectory);
            var path = Path.GetDirectoryName(localFilename);

            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }

            return new FileStream(localFilename, FileMode.Create);
        }

    }
}
