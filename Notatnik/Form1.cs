using System;
using System.IO;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notatnik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void nowyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        private void otwórzToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Dokumenty tekstowe(*.txt)|*.txt|Wszystkie pliki(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
            this.Text = op.FileName;
        }

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Dokumenty tekstowe(*.txt)|*.txt|Wszystkie pliki(*.*)|*.*";
            if (sv.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(sv.FileName, RichTextBoxStreamType.PlainText);
              this.Text = sv.FileName;
        }

        private void zakończToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cofnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
            
        }

        private void wytnijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void kopiujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void wklejToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void czcionkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richTextBox1.Font;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fd.Font;
            }
        }

        private void zmianaKoloruTłaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cr = new ColorDialog();
            if (cr.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = cr.Color;
            }
        }

        private void drukujToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                StringReader reader = new StringReader(richTextBox1.Text);
                printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringReader reader = new StringReader(richTextBox1.Text);
            float YPosition = 0;
            float LeftMargin = e.MarginBounds.Left;
            float TopMargin = e.MarginBounds.Top;
            string Line = null;
            SolidBrush PrintBrush = new SolidBrush(Color.Black);
            
            float LinesPerPage = e.MarginBounds.Height / richTextBox1.Font.GetHeight(e.Graphics);

            for (int count = 0; count < LinesPerPage && ((Line = reader.ReadLine()) != null); count ++)
                {
                YPosition = TopMargin + (count * richTextBox1.Font.GetHeight(e.Graphics));
                e.Graphics.DrawString(Line, richTextBox1.Font, PrintBrush, LeftMargin, YPosition, new StringFormat()); 
            }
            if (Line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            PrintBrush.Dispose();
        }

        private void godzinaDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += DateTime.Now.ToString("HH:mm") + " " + DateTime.Now.ToString("dd.MM.yyyy");
        }
    }
    }

