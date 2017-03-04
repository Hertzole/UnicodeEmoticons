using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicodeEmoticons
{
    public partial class MainForm : Form
    {
        private string[] emoticons = new string[] { "( ͡° ͜ʖ ͡°)", "( ͡~ ͜ʖ ͡°)", "( ͠° ͜ʖ ͡°)", "( ͡o ͜ʖ ͡o)", "( ͠° ͟ʖ ͡°) ", "¯\\_(ツ)_/¯", "¯\\_(°_o)_/¯", "ಠ_ಠ", "ಠ‿ಠ", "◕‿◕", "(⌐■_■)", "(╯°□°）╯︵ ┻━┻", "(ノಠ益ಠ)ノ彡┻━┻", "┻━┻ ︵ヽ(`Д´)ﾉ︵ ┻━┻", "（╯°□°）╯︵(\\ .o.)\\", "┬──┬ ノ( ゜-゜ノ)", "(∩◕ᴥ◕)⊃━☆ﾟ.*", "(∩ಠ‿ಠ)⊃━☆ﾟ.*", "ヽ༼ຈل͜ຈ༽ﾉ", "( ﾟヮﾟ)", "(´・ω・)っ由" };

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < emoticons.Length; i++)
            {
                Button newButton = new Button()
                {
                    MinimumSize = new Size(123, 25),
                    Text = emoticons[i],
                    Font = new Font(FontFamily.GenericSerif, 8),
                };

                newButton.Tag = emoticons[i];
                newButton.Click += ButtonClick;

                buttonPanel.Controls.Add(newButton);
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            string emoji = (sender as Button).Tag.ToString();

            emoji = Convert(emoji);

            Clipboard.SetText(emoji);
        }

        private string Convert(string text)
        {
            bool discordMode = discordBox.Checked;

            if (discordMode)
            {
                text = text.Replace("_", "\\_");
            }

            return text;
        }
    }
}
