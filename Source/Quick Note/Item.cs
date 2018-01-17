using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_Note
{
    public partial class Item : UserControl
    {
        public event UserControlClickHandler InnerButtonClick;
        public delegate void UserControlClickHandler(object sender, EventArgs e);
        public Item()
        {
            InitializeComponent();
        }
        public Item(Note note)
        {
            InitializeComponent();
            ReMake(note);
        }

        public void ReMake(Note note)
        {
            this.lbDate.Text = note.Date.ToString("dd-MM-yyy");
            this.lbText.Text = note.Tile;
            this.lbData.Text = note.Data;
            this.lbTags.Text = "";
            int length = note.Tags.Count;
            int count = 0;
            foreach (var tag in note.Tags)
            {
                if (count < length - 1)
                {
                    lbTags.Text = lbTags.Text + tag.name + ", ";
                }
                else
                {
                    lbTags.Text = lbTags.Text + tag.name;
                }
                count++;
            }
        }

        public void YourButton_Click(object sender, EventArgs e)
        {
            if (this.InnerButtonClick != null)
            {
                this.InnerButtonClick(this, e);
            }
        }

        
    }
}
