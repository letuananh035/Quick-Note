namespace Quick_Note
{
    partial class Item
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbDate = new System.Windows.Forms.Label();
            this.lbText = new System.Windows.Forms.Label();
            this.lbTags = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbData = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.BackColor = System.Drawing.Color.Transparent;
            this.lbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.Location = new System.Drawing.Point(117, 50);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(99, 20);
            this.lbDate.TabIndex = 0;
            this.lbDate.Text = "15/12/2017";
            this.lbDate.Click += new System.EventHandler(this.YourButton_Click);
            // 
            // lbText
            // 
            this.lbText.BackColor = System.Drawing.Color.Transparent;
            this.lbText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbText.Location = new System.Drawing.Point(7, 74);
            this.lbText.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lbText.Name = "lbText";
            this.lbText.Padding = new System.Windows.Forms.Padding(5, 14, 0, 0);
            this.lbText.Size = new System.Drawing.Size(218, 35);
            this.lbText.TabIndex = 1;
            this.lbText.Text = "ádasd\\ndsdf";
            this.lbText.Click += new System.EventHandler(this.YourButton_Click);
            // 
            // lbTags
            // 
            this.lbTags.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTags.Location = new System.Drawing.Point(4, 189);
            this.lbTags.Name = "lbTags";
            this.lbTags.Size = new System.Drawing.Size(221, 23);
            this.lbTags.TabIndex = 2;
            this.lbTags.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbTags.Click += new System.EventHandler(this.YourButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbData);
            this.panel1.Controls.Add(this.lbDate);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(7, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(218, 209);
            this.panel1.TabIndex = 3;
            this.panel1.Click += new System.EventHandler(this.YourButton_Click);
            // 
            // lbData
            // 
            this.lbData.BackColor = System.Drawing.Color.Transparent;
            this.lbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbData.Location = new System.Drawing.Point(0, 108);
            this.lbData.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lbData.Name = "lbData";
            this.lbData.Padding = new System.Windows.Forms.Padding(5, 14, 0, 0);
            this.lbData.Size = new System.Drawing.Size(218, 78);
            this.lbData.TabIndex = 4;
            this.lbData.Text = "ádasd\\ndsdf";
            this.lbData.Click += new System.EventHandler(this.YourButton_Click);
            // 
            // Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Quick_Note.Properties.Resources.noteItem;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lbTags);
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Name = "Item";
            this.Size = new System.Drawing.Size(233, 219);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.Label lbTags;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbData;
    }
}
