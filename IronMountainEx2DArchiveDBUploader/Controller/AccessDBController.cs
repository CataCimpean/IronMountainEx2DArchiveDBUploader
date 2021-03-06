﻿using IronMountainEx2DArchiveDBUploader.BLL;
using IronMountainEx2DArchiveDBUploader.DTO;
using IronMountainEx2DArchiveDBUploader.Utils.Components;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace IronMountainEx2DArchiveDBUploader.Controller
{
    public class AccessDBController
    {

        private Form1 form1;
        private List<MetadataDTO> listMetadata;

        public AccessDBController(Form1 form1, List<MetadataDTO> listMetadata)
        {
            this.form1 = form1;
            this.listMetadata = listMetadata;
        }
        
        public void InsertMetadataInAccessDB()
        {
            try
            {
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\tStep3:Insert data in Access DB", Color.Blue, true);
                AccessBLL.InsertDataDB(listMetadata);
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\t\tOK...", Color.Blue, true);
            }
            catch (Exception ex) { throw ex; };
        }
    }
}
