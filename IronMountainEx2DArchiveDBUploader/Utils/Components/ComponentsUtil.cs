using System;
using System.Drawing;
using System.Windows.Forms;

namespace IronMountainEx2DArchiveDBUploader.Utils.Components
{
    public static class ComponentsUtil
    {
        /// <summary>
        /// Utils for add content for components of type RichTextBox
        /// </summary>
        /// <param name="box"></param>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="AddNewLine"></param>
        public static void AppendTextToRichTextBox(this RichTextBox box, string text, Color color, bool AddNewLine = false)
        {
            if (AddNewLine)
            {
                text += Environment.NewLine;
            }
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            box.Refresh();
        }

        public static void SetButtonVisibility(Button button, bool invisible = false)
        {
            if (invisible) button.Hide();
            else button.Visible = true;
        }
    }
}
