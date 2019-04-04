using IronMountainEx2DArchiveDBUploader.Utils;
using IronMountainEx2DArchiveDBUploader.Utils.Archive;
using IronMountainEx2DArchiveDBUploader.Utils.Components;
using System;
using System.Drawing;

namespace IronMountainEx2DArchiveDBUploader.Controller
{
    public class ArchiveController
    {
        public Form1 form1;
        private string archivePath;
        private string archiveName;
        private string dataExtractedPath;
        
        public ArchiveController(Form1 form1)
        {
            this.form1 = form1;
        }

        public void ExtractFiles()
        {
            try
            {
                 archivePath = form1.archivePath;
                 archiveName = FileUtil.GetFileNameWithoutExtensionByFilePath(archivePath);

                if (FileUtil.FileSize(archivePath) > 0)
                {
                    ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\tStep1:Extract archive files", Color.Blue, true);
                    //obtain desired dataExtractedPath 
                    dataExtractedPath = FileUtil.GetPathExtractedArchive(archiveName);

                    //start extract data to specified location
                    ArchiveUtil.UnzipFile(archivePath, dataExtractedPath);

                    //set path to relevant Info from .meta file
                    form1.metaDataExtractedPath = FileUtil.GetPathOfExtractedMetaFile(dataExtractedPath);
                    ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\t\tOK...", Color.Blue, true);

                    //activate button of Load DB
                    ComponentsUtil.SetButtonVisibility(form1.GetLoadButton());
                }
                else
                {
                    ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "Archive size is 0", Color.Red, true);
                }
            } catch (Exception ex) { throw ex; };
        }
    }
}
