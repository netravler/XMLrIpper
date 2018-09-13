using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;



namespace XMLrIpper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }

        }

        // xml parse junk here!

        public void Read(string fileName)
        {
            XDocument doc = XDocument.Load(fileName);

            foreach (XElement el in doc.Root.Elements())
            {
                Console.WriteLine("{0} {1}", el.Name, el.Attribute("id").Value);
                Console.WriteLine("  Attributes:");
                foreach (XAttribute attr in el.Attributes())
                    Console.WriteLine("    {0}", attr);
                Console.WriteLine("  Elements:");

                foreach (XElement element in el.Elements())
                    Console.WriteLine("    {0}: {1}", element.Name, element.Value);
            }
        }

        private void tbXMLOutput_Click(object sender, EventArgs e)
        {
            Read(@textBox1.Text);
        }
    }
}
