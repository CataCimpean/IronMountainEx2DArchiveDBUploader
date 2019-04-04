using IronMountainEx2DArchiveDBUploader.DTO;
using IronMountainEx2DArchiveDBUploader.Utils.DB;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace IronMountainEx2DArchiveDBUploader.DAL
{
    public class AccessDAL : DBConnection
    {
        public static void InsertDataDB(List<MetadataDTO> metadataList)
        {
            using (OleDbConnection connection = new OleDbConnection(GetConnDB()))
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                try
                {
                    if (metadataList != null && metadataList.Count > 0)
                    {
                        string insertQuery = "INSERT INTO IronImagesDB ([ID],[CreationDate],[ImageRoute]) values (?,?,?)";
                        command.CommandText = insertQuery;

                        connection.Open();
                        foreach (MetadataDTO metadataObj in metadataList)
                        {
                            command.Parameters.Clear();
                            command.Parameters.Add(new OleDbParameter("ID", metadataObj.ID));
                            command.Parameters.Add(new OleDbParameter("CreationDate", metadataObj.CreationDate));
                            command.Parameters.Add(new OleDbParameter("ImageRoute", metadataObj.ImageRoute));
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (OleDbException ex)
                {
                    //Error when try to insert duplicate key
                    if (ex.ErrorCode == -2147467259)
                    {
                        throw new Exception("Cannot insert duplicate key.. Please change ID in .meta file ");
                    }
                }
                catch (Exception ex)
                { throw ex; };
            }
        }
    }
}
