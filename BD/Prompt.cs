using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD
{
    public class Prompt : IDisposable
    {
        Font SmallFont = new Font("Arial", 8);
        Font MediumFont = new Font("Arial", 10);
        Font LargeFont = new Font("Arial", 12);

        private Form prompt { get; set; }
        public string Result { get; }

        public Prompt(string text, string caption)
        {
            Result = ShowDialog(text, caption);
        }
        //use a using statement
        private string ShowDialog(string text, string caption)
        {
            prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true,
                MinimizeBox = false,
                MaximizeBox = false,
                Font = MediumFont
            };

            Label textLabel = new Label() { Left = 100, Top = 20, Width = 400, Height = 50, Font = MediumFont, Text = text, Dock = DockStyle.Top, TextAlign = ContentAlignment.TopLeft, AutoSize=false};
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 , Font = MediumFont};
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public void Dispose()
        {
            //See Marcus comment
            if (prompt != null)
            {
                prompt.Dispose();
            }
        }
    }
}
