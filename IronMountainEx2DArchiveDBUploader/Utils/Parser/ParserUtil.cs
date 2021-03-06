﻿using IronMountainEx2DArchiveDBUploader.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace IronMountainEx2DArchiveDBUploader.Utils.Parser
{
    public class ParserUtil
    {
        /// <summary>
        /// Method used for translate content of .meta file into List of MedatadaDTO objects
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="delimter"></param>
        /// <returns></returns>
        public static List<MetadataDTO> ParseMetaContent(string filePath,string delimter)
        {
            try
            {
                List<MetadataDTO> listMetadata = null;
                if (File.Exists(filePath))
                {
                    listMetadata = new List<MetadataDTO>();
                    using (StreamReader sr = File.OpenText(filePath))
                    {
                        string line;
                        int index = 0;
                        while ((line = sr.ReadLine()) != null && line!=string.Empty)
                        {
                            //skip first line from .meta (because is header)
                            if (index == 0) { index++; continue; }

                            //obtain elements when split current line by delimiter.
                            string[] elements = line.Split(new[] { delimter }, StringSplitOptions.RemoveEmptyEntries);

                            //add new element MetadataDTO to list
                            listMetadata.Add(new MetadataDTO
                            {
                                ID = Convert.ToDouble(elements[0]),
                                CreationDate = DateTime.ParseExact(elements[1], "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture),
                                ImageRoute = elements[2]
                            });
                        }
                    }
                }
                return listMetadata;
            }
            catch(Exception ex) { throw ex; };
        }
    }
}
