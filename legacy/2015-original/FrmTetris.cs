using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class FrmTetris : Form
    {
        public FrmTetris()
        {
            InitializeComponent();
        }
        private Keys _downKey;
        private Keys _dropKey;
        private Keys _MoveLeftKey;
        private Keys _MoveRightKey;
        private Keys _deasilRotateKey;
        private Keys _contraRotateKey;
        private int paletteWidth;
        private int paletteHeight;
        private int rectPix;
        private Color paletteColor;
        private Palette p;

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (p!=null)
            {
                p.Close();
            }
            p = new Palette(paletteWidth, paletteHeight, rectPix, paletteColor,
                Graphics.FromHwnd(pbRun.Handle),
                Graphics.FromHwnd(lblReady.Handle));
            p.Start();
        }

        private void pbRun_Paint(object sender, PaintEventArgs e)
        {
            if (p!=null)
            {
                p.PaintPalette(e.Graphics);
            }
        }

        private void lblReady_Paint(object sender, PaintEventArgs e)
        {
            if (p != null)
            {
                p.paintReady(e.Graphics);
            }
        }

        private void FrmTetris_Load(object sender, EventArgs e)
        {
            Config config = new Config();
            config.LoadFromXmlFile();
            _downKey = config.DownKey;
            _dropKey = config.DropKey;
            _MoveLeftKey = config.MoveLeftKey;
            _MoveRightKey = config.MoveRightKey;
            _deasilRotateKey = config.DeasilRotateKey;
            _contraRotateKey = config.ContraRotateKey;
            paletteWidth = config.CoorWidth;
            paletteHeight = config.CoorHeight;
            paletteColor = config.BackColor;
            rectPix = config.RectPix;

            this.Width = paletteWidth * rectPix + 134;
            this.Height = paletteHeight * rectPix + 58;
            pbRun.Width = paletteWidth * rectPix;
            pbRun.Height = paletteHeight * rectPix;
        }

        private void FrmTetris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue==32) //频屏回车
            {
                e.Handled = true;
            }
            if (e.KeyCode==_downKey)
            {
                p.Down();
            }
            else if (e.KeyCode ==_dropKey)
            {
                p.Drop();
            }
            else if (e.KeyCode ==_MoveLeftKey)
            {
                p.MoveLeft();
            }
            else if (e.KeyCode ==_MoveRightKey)
            {
                p.MoveRight();
            }
            else if (e.KeyCode ==_deasilRotateKey)
            {
                p.DeasilRotate();
            }
            else if (e.KeyCode ==_contraRotateKey)
            {
                p.ContraRotate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (p==null)
            {
                return;
            }
            if (btnPause.Text == "暂停")
            {
                p.Pause();
                btnPause.Text = "继续";
            }
            else
            {
                p.EndPause();
                btnPause.Text = "暂停";
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            if (btnPause.Text=="暂停")
            {
                btnPause.PerformClick();
            }
            using (form_setting frmConfig = new form_setting())
            {
                frmConfig.ShowDialog();
            }
        }

        private void FrmTetris_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (p != null)
            {
                p.Close();
            }
        }
    }
}
