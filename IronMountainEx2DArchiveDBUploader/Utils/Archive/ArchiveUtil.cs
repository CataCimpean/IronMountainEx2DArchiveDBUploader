using Ionic.Zip;

namespace IronMountainEx2DArchiveDBUploader.Utils.Archive
{
    public class ArchiveUtil
    {
        /// <summary>
        /// Used for extract Archive file
        /// </summary>
        /// <param name="zipSource"></param>
        /// <param name="pathToExtract"></param>
        public static void UnzipFile(string zipSource, string pathToExtract)
        {
            using (ZipFile zip = ZipFile.Read(zipSource))
            {
                //override destinationPath if exist
                zip.ExtractAll(pathToExtract, ExtractExistingFileAction.OverwriteSilently);
            }
        }
    }
}
