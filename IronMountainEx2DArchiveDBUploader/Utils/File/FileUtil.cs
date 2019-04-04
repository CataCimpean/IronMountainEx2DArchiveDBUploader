
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
namespace IronMountainEx2DArchiveDBUploader.Utils
{
    public class FileUtil
    {
        public static void BuildFile(string metaContent, string destination)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(destination))
            {
                file.WriteLine(metaContent);
            }
        }

        public static void BuildDirectory(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

        public static long FileSize(string filePath)
        {
            return new System.IO.FileInfo(filePath).Length;
        }

        public static void DeleteFile(string filePath)
        {
            if (File.Exists(filePath)) File.Delete(filePath);
        }

        public static void DeleteDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath)) Directory.Delete(directoryPath);
        }


        public static string GetPathExtractedArchive(string dirName)
        {
            return String.Format(@"{0}\{1}", ConfigurationManager.AppSettings["UnzippedPath"].ToString(), dirName);
        }

        public static string GetFileNameWithoutExtensionByFilePath(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        public static string GetPathOfExtractedMetaFile(string dirPath)
        {
            string extractedMetaFilePath = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories)
                       .Where(file => new string[] { ".meta" }
                       .Contains(Path.GetExtension(file))).FirstOrDefault();
            return extractedMetaFilePath;
        }
    }
}
