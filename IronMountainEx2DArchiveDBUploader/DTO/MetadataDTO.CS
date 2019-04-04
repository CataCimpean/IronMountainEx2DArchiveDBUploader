using System;

namespace IronMountainEx2DArchiveDBUploader.DTO
{

    /// <summary>
    /// Object used for transport Data from .meta file
    /// </summary>
    public class MetadataDTO
    {
        public double ID {get;set;}
        public DateTime CreationDate { get; set; }
        public string ImageRoute { get; set; }
    }
}
