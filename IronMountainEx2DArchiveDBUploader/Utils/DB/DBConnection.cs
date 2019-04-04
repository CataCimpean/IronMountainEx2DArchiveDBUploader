using IronMountainEx2DArchiveDBUploader.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace IronMountainEx2DArchiveDBUploader.Utils.DB
{
    public class DBConnection
    {
        public static string GetConnDB()
        {
            return ConfigurationManager.AppSettings["IronAccessDB"].ToString();
        }

        public static void InsertDataDB(List<MetadataDTO> metadataList)
        {
            using (OleDbConnection connection = new OleDbConnection(GetConnDB()))
            {
                OleDbCommand command = new OleDbCommand();
                // Set the Connection to the new OleDbConnection.
                command.Connection = connection;
                
                try
                {
                    if(metadataList !=null && metadataList.Count > 0)
                    {
                        string insertQuery = "INSERT INTO IronImagesDB ([ID],[CreationDate],[ImageRoute]) values (?,?,?)";
                        command.CommandText = insertQuery;

                        connection.Open();
                        foreach (MetadataDTO metadataObj in metadataList)
                        {
                            command.Parameters.Clear();
                            command.Parameters.Add(new OleDbParameter("ID",metadataObj.ID));
                            command.Parameters.Add(new OleDbParameter("CreationDate", metadataObj.CreationDate));
                            command.Parameters.Add(new OleDbParameter("ImageRoute", metadataObj.ImageRoute));

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch(OleDbException ex){
                    //try to insert duplicate key
                    if(ex.ErrorCode == -2147467259)
                    {
                        throw new Exception("Cannot insert duplicate key.. Please change ID in .meta file ");
                    }
                }
                catch(Exception ex)
                { throw ex;  };
            }
        }



        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
    }
}
