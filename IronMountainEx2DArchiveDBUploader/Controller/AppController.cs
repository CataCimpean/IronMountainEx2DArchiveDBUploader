using IronMountainEx2DArchiveDBUploader.DTO;
using IronMountainEx2DArchiveDBUploader.Utils.Components;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace IronMountainEx2DArchiveDBUploader.Controller
{
    public class AppController
    {
        private Form1 form1;

        public AppController(Form1 form1)
        {
            this.form1 = form1;
        }

        /// <summary>
        /// This method call ArchiveController which extract data from specific archive file
        /// </summary>
        public void StartExtractDataFromArchive()
        {
            try
            {
                ArchiveController archiveCtrl = new ArchiveController(form1);
                archiveCtrl.ExtractFiles();
            }
            catch(Exception ex)
            {
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), String.Format("\t\tError: {0}",ex.Message), Color.Red, true);
            }
        }

        /// <summary>
        /// This method call controller which insert records in DB based on List of objects
        /// </summary>
        /// <param name="form1"></param>
        /// <param name="listMetadata"></param>
        public void StartLoadDataInAccessDB(Form1 form1,List<MetadataDTO> listMetadata)
        {
            try
            {
                AccessDBController accesDBCtrl = new AccessDBController(form1,listMetadata);
                accesDBCtrl.InsertMetadataInAccessDB();
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "Succesfully inserted...", Color.Green, true);
            }
            catch (Exception ex)
            {
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), String.Format("\t\tError: {0}", ex.Message), Color.Red, true);
            }
        }

        /// <summary>
        ///  This method call controller which parse content from .meta file
        /// </summary>
        public void StartParseMetaDataInfo()
        {
            try
            {
                MetaDataInfoController metadataCtrl = new MetaDataInfoController(form1);
                metadataCtrl.ParseMetaDataInfo();

                //if not null send data to AccessDBController 
                if (metadataCtrl.listMetaData != null) StartLoadDataInAccessDB(form1, metadataCtrl.listMetaData);

            }catch(Exception ex)
            {
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), String.Format("\t\tError: {0}", ex.Message), Color.Red, true);
            }
        }
    }
}
