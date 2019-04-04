using IronMountainEx2DArchiveDBUploader.DAL;
using IronMountainEx2DArchiveDBUploader.DTO;
using System;
using System.Collections.Generic;

namespace IronMountainEx2DArchiveDBUploader.BLL
{
    public class AccessBLL
    {
        public static void InsertDataDB(List<MetadataDTO> metadataList)
        {
            try {
                AccessDAL.InsertDataDB(metadataList);
            }catch(Exception ex) { throw ex; };
        }
    }
}
