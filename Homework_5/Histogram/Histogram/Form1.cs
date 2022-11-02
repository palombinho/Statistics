using Microsoft.VisualBasic.FileIO;
using System;

namespace Histogram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Pen p1 = new Pen(Brushes.Black, 5);
        Pen p2 = new Pen(Brushes.Black, 3);
        private void button1_Click(object sender, EventArgs e)
        {
            int num = -1;
           

            Dictionary<string, int> Age = new Dictionary<string, int>();

            using (TextFieldParser parser = new TextFieldParser("C:/Users/franc/Desktop/Statistics/Homework_5/Histogram/Statistics_students_dataset.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                while (!parser.EndOfData)
                {
                    
                    num += 1;
                    string[] fields = parser.ReadFields();
                    int i = 0;      


                    foreach (string field in fields)
                    {
                        

                        if (i == 6)  
                        {

                            if (Age.ContainsKey(field))
                            {
                                Age[field] += 1;
                            }
                            else
                            {
                                Age.Add(field, 1);
                            }
                        }
                        i += 1;
                    }
                }

            }

            Age.Remove("Age");

            Bitmap b1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g1 = Graphics.FromImage(b1);

            Bitmap b2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics g2 = Graphics.FromImage(b2);


            drawVerticalChart(b1, g1, pictureBox1, Age, num);
            drawHorizontalChart(b2, g2, pictureBox2, Age, num);

        }

        private double fromRealToVirtualX(double x, double minX, double maxX, double width)
        {
            return (x - minX) / (maxX - minX) * width;
        }

        private double fromRealToVirtualY(double y, double minY, double maxY, double height)
        {
            return height - ((y - minY) / (maxY - minY)) * height;
        }

        private void drawVerticalChart(Bitmap b, Graphics g, PictureBox pictureBox, Dictionary<string, int> distr, int num)
        {

            int j = 0;
            int step = pictureBox.Width / distr.Count;
            

            g.DrawRectangle(p1, 0, 0, pictureBox.Width - 1, pictureBox.Height - 1);

            foreach (var item in distr)
            {
                double virtualX = fromRealToVirtualX(item.Value, 0, num, pictureBox.Height);
                Rectangle r = new Rectangle(j + 1, pictureBox.Height - (int)virtualX - 1, step, (int)virtualX);
                g.DrawRectangle(p2, j + 1, pictureBox.Height - (int)virtualX - 1, step, (int)virtualX);
                g.FillRectangle(new SolidBrush(Color.Orange), r);
                
               
                g.DrawString(item.Key, new Font("Arial", 8), new SolidBrush(Color.Black), j, pictureBox.Height - 20);
                j += step;
            }

            pictureBox.Image = b;
        }

        private void drawHorizontalChart(Bitmap b, Graphics g, PictureBox pictureBox, Dictionary<string, int> distr, int num)
        {
            int j = 0;
            int step = pictureBox.Height / distr.Count;
            g.DrawRectangle(p1, 0, 0, pictureBox.Width - 1, pictureBox.Height - 1);

            foreach (var item in distr)
            {
                double virtualX = fromRealToVirtualX(item.Value, 0, num, pictureBox.Width);
                Rectangle r = new Rectangle(0, j, (int)virtualX, step);
                g.DrawRectangle(p2, 0, j, (int)virtualX, step);
                g.FillRectangle(new SolidBrush(Color.Green), r);
                j += step;
            }

            pictureBox.Image = b;
        }
    }
}