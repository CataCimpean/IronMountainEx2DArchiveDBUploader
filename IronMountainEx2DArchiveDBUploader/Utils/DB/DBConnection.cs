using System.Configuration;

namespace IronMountainEx2DArchiveDBUploader.Utils.DB
{
    public abstract class DBConnection
    {
        public static string GetConnDB()
        {
            return ConfigurationManager.AppSettings["IronAccessDB"].ToString();
        }
    }
}
