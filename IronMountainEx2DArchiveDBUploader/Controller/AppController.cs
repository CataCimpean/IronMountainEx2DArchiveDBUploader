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
