using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
namespace Quick_Note
{
    public partial class Form1 : Form
    {
        List<Note> listNote = new List<Note>();
        List<string> listFind = new List<string>();
        Hook _keyboardHook;
        public Form1()
        {
            InitializeComponent();
            if (File.Exists(@"data.json"))
            {
                listNote = JsonConvert.DeserializeObject<List<Note>>(File.ReadAllText(@"data.json"));
            }
            if (listNote.Count > 0)
            {
                MakeItemWihListNode();
            }

            _keyboardHook = new Hook();
            _keyboardHook.Install();

            _keyboardHook.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Space && (Keyboard.IsKeyDown(Key.LWin) || Keyboard.IsKeyDown(Key.RWin)))
                {
                     if (this.WindowState == FormWindowState.Minimized)
                    {
                        //this.Show();
                        //this.WindowState = FormWindowState.Normal;
                        Note item = new Note();
                        new AddNote(item).ShowDialog();
                        if (item.isDelete == true) return;
                        listNote.Add(item);
                        ClearNote();
                        MakeItemWihListNode();
                        SaveData();
                    }
                }
            };


        }




        void UpdateTag()
        {
            string data = tbFindTag.Text;
            if (data == "")
            {
                this.ClearNote();
                this.Update();
                MakeItemWihListNode();
                return;
            }
            string[] listString = data.Split(',');

            listFind = new List<string>(listString);

            if (listNote.Count != 0)
            {
                this.ClearNote();
                this.Update();
            }
            if (listFind.Count == 0) MakeItemWihListNode();
            int lengthNote = listNote.Count;
            for (int i = 0; i < lengthNote; ++i)
            {
                int lengthTags = listNote[i].Tags.Count;
                bool isAddNote = false;
                for (int j = 0; j < lengthTags; ++j)
                {
                    if (listFind.Any(item => item != "" && item.Trim() == listNote[i].Tags[j].name))
                    {
                        isAddNote = true;
                    }
                }
                if (isAddNote)
                {
                    this.AddItemToPanel(MakeItem(listNote[i]));
                    this.Update();
                }
            }
        }

        public void MakeItemWihListNode()
        {
            int lengthNote = listNote.Count;
            for (int i = lengthNote - 1; i >= 0; --i)
            {
                this.AddItemToPanel(MakeItem(listNote[i]));
            }
        }

        private void item_Click(object sender, EventArgs e)
        {
            Item item = (Item)sender;
            Note note = (Note)item.Tag;
            new EditNote(note).ShowDialog();
            if (note.isDelete)
            {
                listNote.Remove(note);
                flowLayoutPanel1.Controls.Remove(item);
            }
            item.ReMake(note);
            SaveData();
        }

        public void AddItemToPanel(Item item)
        {
            flowLayoutPanel1.Controls.Add(item);
            item.Parent = flowLayoutPanel1;
            item.BackColor = Color.Transparent;
            item.InnerButtonClick += item_Click;
        }

        public Item MakeItem(Note note)
        {
            Item item = new Item(note);
            item.Tag = note;
            return item;
        }

        public void ClearNote()
        {
            flowLayoutPanel1.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Note item = new Note();
            new AddNote(item).ShowDialog();
            if (item.isDelete == true) return;
            listNote.Add(item);
            ClearNote();
            MakeItemWihListNode();
            SaveData();
        }

        public void SaveData()
        {
            File.WriteAllText(@"data.json", JsonConvert.SerializeObject(listNote));
        }

        private void tbFindTag_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UpdateTag();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.ClearNote();
            this.Update();
            MakeItemWihListNode();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Analytic(listNote).ShowDialog();
        }

        private void viewStaticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Analytic(listNote).ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void viewNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Setting_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }


    }
}
