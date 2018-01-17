using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_Note
{
    public partial class EditNote : Form
    {
        public Note item;

        public EditNote()
        {
            InitializeComponent();

        }

        public EditNote(Note item)
        {
            InitializeComponent();
            this.item = item;
            tbData.Text = item.Data;
            tbTile.Text = item.Tile;

            int length = item.Tags.Count;
            int count = 0;
            foreach (var tag in item.Tags)
            {
                if (count < length - 1)
                {
                    tbTags.Text = tbTags.Text + tag.name + ", ";
                }
                else
                {
                    tbTags.Text = tbTags.Text + tag.name;
                }
                count++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            item.Data = tbData.Text;
            item.Tile = tbTile.Text;
            item.Date = DateTime.Now;

            string data = tbTags.Text;
            string[] listTag = data.Split(',');

            List<Tag> Tags = new List<Tag>();

            int length = listTag.Length;

            for (int i = 0; i < length; ++i)
            {
                string temp = listTag[i].Trim();
                bool trungTen = false;
                foreach (var tag in Tags)
                {
                    if (tag.name == temp)
                    {
                        trungTen = true;
                        break;

                    }
                }
                if (trungTen || temp == "") continue;
                Tags.Add(new Tag() { name = temp });
            }
            item.Tags = Tags;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            item.isDelete = true;
            this.Close();
        }
    }
}
