using System;
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
            fd.Font = richTextBox1.SelectionFont;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fd.Font;
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
    }
}
