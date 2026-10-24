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
    public partial class form_setting : Form
    {
        public form_setting()
        {
            InitializeComponent();
        }

        bool[,] struArr = new bool[5, 5];
        private Color blockColor = Color.Red;
        private Config config = new Config();

        private void label1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gp = e.Graphics;
            gp.Clear(Color.Black);
            Pen p = new Pen(Color.White);
            const int length = 155;
            for (int i = 31; i <= length; i+=31)
            {
                gp.DrawLine(p, 1, i, length, i);
            }
            for (int i = 31; i < length; i+=31)
            {
                gp.DrawLine(p, i, 1, i, length);
            }
            SolidBrush s = new SolidBrush(blockColor);
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (struArr[x,y])
                    {
                        gp.FillRectangle(s, 31 * x + 1, 31 * y + 1, 30, 30);
                    }
                }
            }
        }



        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            int xPos, yPos;
            xPos = e.X / 31;
            yPos = e.Y / 31;
            struArr[xPos, yPos] = !struArr[xPos, yPos];
            bool b = struArr[xPos, yPos];
            Graphics gp = label1.CreateGraphics();//得到label的绘图图面
            SolidBrush s = new SolidBrush(b ? blockColor : Color.Black);
            gp.FillRectangle(s, 31 * xPos + 1, 31 * yPos + 1, 30, 30);
            gp.Dispose();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            blockColor = colorDialog1.Color;
            label2.BackColor = blockColor;
            label1.Invalidate();//重绘(触发paint事件)
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool isDrawed = false;
            foreach (bool i in struArr)
            {
                if (i)
                {
                    isDrawed = true;
                    break;
                }
            }
            if (!isDrawed)
            {
                MessageBox.Show("图案为空，请用鼠标点击左边窗口绘制图案！", "提示窗口",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            StringBuilder sb = new StringBuilder(25);
            foreach (bool i in struArr)
            {
                sb.Append(i ? "1" : "0");
            }
            string blockString = sb.ToString();

            foreach (ListViewItem item in lsvBlockSet.Items)
            {
                if (item.SubItems[0].Text==blockString)
                {
                    MessageBox.Show("该图案已经存在！", "提示窗口",
                        MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }
            }

            ListViewItem newItem = new ListViewItem();
            newItem = lsvBlockSet.Items.Add(blockString);
            newItem.SubItems.Add(blockColor.ToArgb().ToString()/*Convert.ToString(blockColor.ToArgb())*/);
            
        }

        private void lsvBlockSet_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                blockColor = Color.FromArgb(int.Parse(e.Item.SubItems[1].Text));
            }
            label2.BackColor = blockColor;
            string s = e.Item.SubItems[0].Text;
            for (int i = 0; i < s.Length; i++)
            {
                struArr[i / 5, i % 5] = (s[i] == '1') ? true : false;
            }
            label1.Invalidate();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lsvBlockSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("请在右边窗口选择一个条目进行删除！", "提示窗口",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            lsvBlockSet.Items.Remove(lsvBlockSet.SelectedItems[0]);
            btnClear.PerformClick();

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    struArr[x, y] = false;
                }
            }
            label1.Invalidate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lsvBlockSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("请在右边窗口选择一个条目进行修改！", "提示窗口",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool isDrawed = false;
            foreach (bool i in struArr)
            {
                if (i)
                {
                    isDrawed = true;
                    break;
                }
            }
            if (!isDrawed)
            {
                MessageBox.Show("图案为空，请用鼠标点击左边窗口绘制图案再进行修改！", "提示窗口",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            StringBuilder sb = new StringBuilder(25);
            foreach (bool i in struArr)
            {
                sb.Append(i ? "1" : "0");
            }
            lsvBlockSet.SelectedItems[0].SubItems[0].Text = sb.ToString();
            lsvBlockSet.SelectedItems[0].SubItems[1].Text = Convert.ToString(blockColor.ToArgb());
        }

        private void txtContra_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue >= 33 && e.KeyValue <= 36) || (e.KeyValue >= 45 && e.KeyValue <= 46) ||
                (e.KeyValue >= 48 && e.KeyValue <= 57) || (e.KeyValue >= 65 && e.KeyValue <= 90) ||
                (e.KeyValue >= 96 && e.KeyValue <= 107) || (e.KeyValue >= 109 && e.KeyValue <= 111) ||
                (e.KeyValue >= 186 && e.KeyValue <= 192) || (e.KeyValue >= 219 && e.KeyValue <= 222))
            {
                foreach (Control c in gbKeySet.Controls)
                {
                    Control c_temp = c as TextBox;
                    if (c_temp != null && ((TextBox)c_temp).Text!="")
                    {
                        if (((int)((TextBox)c_temp).Tag)==e.KeyValue)
                        {
                            ((TextBox)c_temp).Text = "";
                            ((TextBox)c_temp).Tag = Keys.None;
                        }
                    }
                }
                ((TextBox)sender).Text = e.KeyCode.ToString();
                ((TextBox)sender).Tag = (Keys)e.KeyValue;
            }
        }

        private void lblBackColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            lblBackColor.BackColor = blockColor;
        }

        private void form_setting_Load(object sender, EventArgs e)
        {
            config.LoadFromXmlFile();
            InfoArr info = config.Info;

            ListViewItem myItem = new ListViewItem();
            for (int i = 0; i < info.Length; i++)
            {
                myItem = lsvBlockSet.Items.Add(info[i].GetIdStr());
                myItem.SubItems.Add(info[i].GetColorStr());
            }
            
            txtDown.Text = config.DownKey.ToString();
            txtDown.Tag = config.DownKey;
            txtDrop.Text = config.DropKey.ToString();
            txtDrop.Tag = config.DropKey;
            txtLeft.Text = config.MoveLeftKey.ToString();
            txtLeft.Tag = config.MoveLeftKey;
            txtRight.Text = config.MoveRightKey.ToString();
            txtRight.Tag = config.MoveRightKey;
            txtDeasil.Text = config.DeasilRotateKey.ToString();
            txtDeasil.Tag = config.DeasilRotateKey;
            txtContra.Text = config.ContraRotateKey.ToString();
            txtContra.Tag = config.ContraRotateKey;

            txtCoorWidth.Text = config.CoorWidth.ToString();
            txtCoorHeight.Text = config.CoorHeight.ToString();
            txtRectPix.Text = config.RectPix.ToString();
            lblBackColor.BackColor = config.BackColor;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            InfoArr info = new InfoArr();
            foreach (ListViewItem item in lsvBlockSet.Items)
            {
                info.Add(item.SubItems[0].Text, item.SubItems[1].Text);
            }
            config.Info = info;
            config.DownKey = (Keys)txtDown.Tag;
            config.DropKey = (Keys)txtDrop.Tag;
            config.MoveLeftKey = (Keys)txtLeft.Tag;
            config.MoveRightKey = (Keys)txtRight.Tag;
            config.DeasilRotateKey = (Keys)txtDeasil.Tag;
            config.ContraRotateKey = (Keys)txtContra.Tag;
            config.CoorWidth = int.Parse(txtCoorWidth.Text);
            config.CoorHeight = int.Parse(txtCoorHeight.Text);
            config.RectPix = int.Parse(txtRectPix.Text);
            config.BackColor = lblBackColor.BackColor;
            config.SaveToXmlFile();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
