using System;
using CsvHelper;
using System.IO;
using System.Globalization;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using System.Xml.Schema;

namespace Ex_2_and_3
{
    public partial class Form1 : Form
    {
        String csvPath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private class Foo
        {
            public string Name { get; set; }
            public string Sex { get; set; }
            public string Weight { get; set; }
            public string Height { get; set; }
            public string Hair_color { get; set; }
            public string Eye_color { get; set; }
            public string Age { get; set; }
            public string Shoe_size { get; set; }
            public string Siblings { get; set; }
            public string Cars { get; set; }
            public string Hobby { get; set; }
            public string Smoker { get; set; }
            public string Work { get; set; }
            public string Pets { get; set; }
            public string Favorite_number { get; set; }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Open CSV File",
                Filter = "csv files (*.csv)|*.csv",
                CheckFileExists = true,
                CheckPathExists = true,
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(openFileDialog.FileName);
                csvPath = openFileDialog.FileName;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (csvPath == "")
            {
                richTextBox1.AppendText("Open csv file first!" + "\n");
                return;
            }
            IEnumerable<Foo> records = null;
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<Foo>();
                //this.richTextBox1.AppendText("Total Recored : " + records.Count().ToString() + "\n");
                foreach (Foo record in records)
                {
                    this.richTextBox1.AppendText(record.Name + " " + record.Sex + " " + record.Weight + " " + record.Height + " " + record.Hair_color + " " + record.Eye_color + " " + record.Age + " " + record.Shoe_size + " " + record.Siblings + " " + record.Cars + " " + record.Hobby + " " + record.Smoker + " " + record.Pets + " " + record.Work + " " + record.Favorite_number + "\n");
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();

        }
        string[] array1 = { "brown", "black", "green", "blue"};
        int[] array2 = { 0, 0, 0, 0, 0, 0, 0 };

        private void button4_Click(object sender, EventArgs e)
        {
            this.richTextBox2.AppendText("Calculating the univariate distribution of the students' eye color: \n");
            using (TextFieldParser parser = new TextFieldParser("C:/Users/franc/Desktop/Statistics_students_dataset.csv"))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                string[] header = parser.ReadFields();
                int index = 0;
                for (int i = 0; i < header.Length; i++)
                {
                    if (header[i] == "Eye_color")
                    {
                        index = i;
                    }
                }
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    for (int i = 0; i < array1.Length; i++)
                    {
                        if (array1[i] == fields[index].ToLower())
                        {
                            array2[i]++;
                        }
                    }
                }
            }
            int totale = 0;
            for (int i =0; i< array2.Length; i++)
            {
                totale = totale + array2[i];
            }
            for (int i = 0; i < array1.Length; i++)
            {
                string colore = array1[i];
                int numero = array2[i];
                float x1 = numero;
                float x2 = totale;
                float x = x1 / x2;
                this.richTextBox2.AppendText(colore + ": " + numero.ToString() +"  " + "percentage frequency: " + x*100+"%" + "\n");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.richTextBox2.Clear();
        }
    }
}