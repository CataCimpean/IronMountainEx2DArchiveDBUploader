using IronMountainEx2DArchiveDBUploader.DTO;
using IronMountainEx2DArchiveDBUploader.Utils.Components;
using IronMountainEx2DArchiveDBUploader.Utils.Parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IronMountainEx2DArchiveDBUploader.Controller
{
    public class MetaDataInfoController
    {
        private Form1 form1;
        public List<MetadataDTO> listMetaData;
        public MetaDataInfoController(Form1 form1)
        {
            this.form1 = form1;
        }

        public void ParseMetaDataInfo()
        {
            try
            {
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\tStep2:Parse content from .meta file", Color.Blue, true);
                listMetaData = ParserUtil.ParseMetaContent(form1.metaDataExtractedPath, form1.delimterMeta);
                ComponentsUtil.AppendTextToRichTextBox(form1.GetRichTextBoxInfo(), "\t\tOK...", Color.Blue, true);
            }
            catch (Exception ex) { throw ex; };
        }
    }
}
