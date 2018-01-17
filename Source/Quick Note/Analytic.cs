using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quick_Note
{
   

    public partial class Analytic : Form
    {
        List<Note> listNote;
        List<Node> listAnalytic = new List<Node>();
        List<double> perAnalytic = new List<double>();
        public Analytic()
        {
            InitializeComponent();
        }

        public Analytic(List<Note> listNote)
        {
            InitializeComponent();
            this.listNote = listNote;
            AnalyticsNote();
        }

        void AnalyticsNote()
        {
            listAnalytic.Clear();
            foreach (var note in listNote)
            {
                foreach (var tag in note.Tags)
                {
                    Node nodeFind = listAnalytic.Find(item => item.name == tag.name);
                    if (nodeFind == null)
                    {
                        Node node = new Node()
                        {
                            name = tag.name,
                            num = 1
                        };
                        listAnalytic.Add(node);
                    }
                    else
                    {
                        nodeFind.num++;
                    }
                }
            }

            listAnalytic = listAnalytic.OrderByDescending(o => o.num).ToList();
            int Sum = listAnalytic.Sum(o => o.num);

            List<Node> temp = listAnalytic.GetRange(0, listAnalytic.Count < 5 ? listAnalytic.Count : 5 );

            if (listAnalytic.Count > 5) {
                List<Node> temp2 = listAnalytic.GetRange(5, listAnalytic.Count - 5);
                int sum = temp2.Sum(o => o.num);
                Node node = new Node() { name = "Other", num = sum };
                temp.Add(node);
            }

            listAnalytic = temp;

            double tempSum = 0;
            perAnalytic.Clear();
            for (int i = 0; i < temp.Count - 1; ++i){
                perAnalytic.Add(temp[i].num*100.0/Sum);
                tempSum += temp[i].num * 100.0 / Sum;
            }
            perAnalytic.Add(100 - tempSum);
        }


        public void DrawPieChart(double[] myPiePerecents, Color[] myPieColors, Graphics myPieGraphic, Point myPieLocation, Size myPieSize)
        {

            double PiePercentTotal = 0;
            for (int PiePercents = 0; PiePercents < myPiePerecents.Length; PiePercents++)
            {
                using (SolidBrush brush = new SolidBrush(myPieColors[PiePercents]))
                {
                    myPieGraphic.FillPie(brush, new Rectangle(new Point(10, 10), myPieSize), Convert.ToSingle(PiePercentTotal * 360 / 100), Convert.ToSingle(myPiePerecents[PiePercents] * 360 / 100));
                }

                PiePercentTotal += myPiePerecents[PiePercents];
            }
            return;
        }


        private void Analytic_Paint(object sender, PaintEventArgs e)
        {

            if (perAnalytic.Count == 1 && perAnalytic[0] == 100) return;



            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            double[] myPiePercent = perAnalytic.ToArray();

            Color[] myPieColors = { Color.Red, Color.Black, Color.Blue, Color.Green, Color.Maroon, Color.Aqua };

            using (Graphics myPieGraphic = this.CreateGraphics())
            {
                Point myPieLocation = new Point(10, 10);

                Size myPieSize = new Size(200, 200);

                DrawPieChart(myPiePercent, myPieColors, myPieGraphic, myPieLocation, myPieSize);

                for (int i = 0; i < perAnalytic.Count; ++i)
                {
                    SolidBrush myBrush = new System.Drawing.SolidBrush(myPieColors[i]);
                    myPieGraphic.FillRectangle(myBrush, new Rectangle(250, 10 + i*55, 50, 25));
                    string text = listAnalytic[i].name;
                    text += "(" + listAnalytic[i].num.ToString() + " - " + ((int)Math.Floor(perAnalytic[i] + 0.5)).ToString() + "%)";
                    myPieGraphic.DrawString(text, this.Font, Brushes.Black, 310, 15 + i * 55);
                }
            }
        }
    }
}
