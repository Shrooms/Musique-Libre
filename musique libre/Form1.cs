﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace musique_libre
{
    public partial class Form1 : Form
    {
        #region Credit

        /*

     *  Custom rounded edges
     *   ----------------
     *  /   CREATED BY   \
     * /    ILLUMINATI    \
     * --------------------
     * ANDREW JUSTIN SOLESA
     * --------------------
     * GOOMBA SHROOM KASMER
     * --------------------
     * 
     
         */

        #endregion

        #region PInvoke Helpers

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        private const int CS_DROPSHADOW = 0x20000;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int L, int T, int R, int B, int W, int H);

        #endregion

        #region Overrides

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        #endregion

        #region Variables

        Form2 form2 = new Form2();
        Form3 form3 = new Form3();

        #endregion

        #region Form1

        public Form1()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 16, 16));

            contextMenuStrip1.Cursor = Cursors.Hand;

            form2.Show();
            form2.Hide();

            form3.Show();
            form3.Hide();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Cursor.Current = Cursors.Help;

                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (transparentPanel1.Bounds.Contains(e.Location) && !transparentPanel1.Visible)
            {
                transparentPanel1.Show();
            }
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;

            form2.Location = new Point(this.Location.X - 106, this.Location.Y + 173);

            if (form2.Visible)
            {
                form3.Location = new Point(form2.Location.X, form2.Location.Y + 54);
            }
            else
            {
                form3.Location = new Point(this.Location.X - 106, this.Location.Y + 173);
            }
        }

        #endregion

        #region TransparentPanel

        private void transparentPanel1_MouseLeave(object sender, EventArgs e)
        {
            transparentPanel1.Hide();
        }

        #endregion

        #region ContextMenuStrip ToolStripItems

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (downloadToolStripMenuItem.Checked == false)
            {
                form2.Show();

                form3.Location = new Point(form2.Location.X, form2.Location.Y + 54);

                downloadToolStripMenuItem.Checked = true;
            }
            else
            {
                form2.Hide();

                form3.Location = new Point(this.Location.X - 106, this.Location.Y + 173);

                downloadToolStripMenuItem.Checked = false;
            }
        }

        private void libraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (libraryToolStripMenuItem.Checked == false)
            {
                form3.Show();

                libraryToolStripMenuItem.Checked = true;
            }
            else
            {
                form3.Hide();

                libraryToolStripMenuItem.Checked = false;
            }
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.paypal.me/AndrewSolesa");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://pastebin.com/raw.php?i=87kLi1qY");
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}
