namespace Tetris
{
    partial class form_setting
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.配置 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbEnvironmentSet = new System.Windows.Forms.GroupBox();
            this.lblBackColor = new System.Windows.Forms.Label();
            this.txtRectPix = new System.Windows.Forms.TextBox();
            this.txtCoorHeight = new System.Windows.Forms.TextBox();
            this.txtCoorWidth = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbKeySet = new System.Windows.Forms.GroupBox();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.txtDeasil = new System.Windows.Forms.TextBox();
            this.txtDrop = new System.Windows.Forms.TextBox();
            this.txtDown = new System.Windows.Forms.TextBox();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.label_antiClockwise = new System.Windows.Forms.Label();
            this.label_deasil = new System.Windows.Forms.Label();
            this.label_drop = new System.Windows.Forms.Label();
            this.label_down = new System.Windows.Forms.Label();
            this.label_right = new System.Windows.Forms.Label();
            this.label_left = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lsvBlockSet = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.配置.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbEnvironmentSet.SuspendLayout();
            this.gbKeySet.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // 配置
            // 
            this.配置.Controls.Add(this.tabPage1);
            this.配置.Controls.Add(this.tabPage2);
            this.配置.Dock = System.Windows.Forms.DockStyle.Top;
            this.配置.Location = new System.Drawing.Point(0, 0);
            this.配置.Name = "配置";
            this.配置.SelectedIndex = 0;
            this.配置.Size = new System.Drawing.Size(537, 338);
            this.配置.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.gbEnvironmentSet);
            this.tabPage1.Controls.Add(this.gbKeySet);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(529, 312);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "参数配置";
            // 
            // gbEnvironmentSet
            // 
            this.gbEnvironmentSet.Controls.Add(this.lblBackColor);
            this.gbEnvironmentSet.Controls.Add(this.txtRectPix);
            this.gbEnvironmentSet.Controls.Add(this.txtCoorHeight);
            this.gbEnvironmentSet.Controls.Add(this.txtCoorWidth);
            this.gbEnvironmentSet.Controls.Add(this.label6);
            this.gbEnvironmentSet.Controls.Add(this.label5);
            this.gbEnvironmentSet.Controls.Add(this.label4);
            this.gbEnvironmentSet.Controls.Add(this.label3);
            this.gbEnvironmentSet.Location = new System.Drawing.Point(286, 35);
            this.gbEnvironmentSet.Name = "gbEnvironmentSet";
            this.gbEnvironmentSet.Size = new System.Drawing.Size(214, 258);
            this.gbEnvironmentSet.TabIndex = 1;
            this.gbEnvironmentSet.TabStop = false;
            this.gbEnvironmentSet.Text = "环境设置";
            // 
            // lblBackColor
            // 
            this.lblBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBackColor.Location = new System.Drawing.Point(94, 139);
            this.lblBackColor.Name = "lblBackColor";
            this.lblBackColor.Size = new System.Drawing.Size(100, 23);
            this.lblBackColor.TabIndex = 2;
            this.lblBackColor.Click += new System.EventHandler(this.lblBackColor_Click);
            // 
            // txtRectPix
            // 
            this.txtRectPix.Location = new System.Drawing.Point(94, 96);
            this.txtRectPix.Name = "txtRectPix";
            this.txtRectPix.Size = new System.Drawing.Size(100, 21);
            this.txtRectPix.TabIndex = 1;
            // 
            // txtCoorHeight
            // 
            this.txtCoorHeight.Location = new System.Drawing.Point(94, 61);
            this.txtCoorHeight.Name = "txtCoorHeight";
            this.txtCoorHeight.Size = new System.Drawing.Size(100, 21);
            this.txtCoorHeight.TabIndex = 1;
            // 
            // txtCoorWidth
            // 
            this.txtCoorWidth.Location = new System.Drawing.Point(94, 26);
            this.txtCoorWidth.Name = "txtCoorWidth";
            this.txtCoorWidth.Size = new System.Drawing.Size(100, 21);
            this.txtCoorWidth.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "背景色";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "格子像素";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "垂直格子数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "水平格子数";
            // 
            // gbKeySet
            // 
            this.gbKeySet.Controls.Add(this.txtContra);
            this.gbKeySet.Controls.Add(this.txtDeasil);
            this.gbKeySet.Controls.Add(this.txtDrop);
            this.gbKeySet.Controls.Add(this.txtDown);
            this.gbKeySet.Controls.Add(this.txtRight);
            this.gbKeySet.Controls.Add(this.txtLeft);
            this.gbKeySet.Controls.Add(this.label_antiClockwise);
            this.gbKeySet.Controls.Add(this.label_deasil);
            this.gbKeySet.Controls.Add(this.label_drop);
            this.gbKeySet.Controls.Add(this.label_down);
            this.gbKeySet.Controls.Add(this.label_right);
            this.gbKeySet.Controls.Add(this.label_left);
            this.gbKeySet.Location = new System.Drawing.Point(30, 35);
            this.gbKeySet.Name = "gbKeySet";
            this.gbKeySet.Size = new System.Drawing.Size(214, 258);
            this.gbKeySet.TabIndex = 0;
            this.gbKeySet.TabStop = false;
            this.gbKeySet.Text = "键盘设置";
            // 
            // txtContra
            // 
            this.txtContra.Location = new System.Drawing.Point(91, 201);
            this.txtContra.Name = "txtContra";
            this.txtContra.ReadOnly = true;
            this.txtContra.Size = new System.Drawing.Size(75, 21);
            this.txtContra.TabIndex = 1;
            this.txtContra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContra_KeyDown);
            // 
            // txtDeasil
            // 
            this.txtDeasil.Location = new System.Drawing.Point(91, 166);
            this.txtDeasil.Name = "txtDeasil";
            this.txtDeasil.ReadOnly = true;
            this.txtDeasil.Size = new System.Drawing.Size(75, 21);
            this.txtDeasil.TabIndex = 1;
            this.txtDeasil.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContra_KeyDown);
            // 
            // txtDrop
            // 
            this.txtDrop.Location = new System.Drawing.Point(91, 131);
            this.txtDrop.Name = "txtDrop";
            this.txtDrop.ReadOnly = true;
            this.txtDrop.Size = new System.Drawing.Size(75, 21);
            this.txtDrop.TabIndex = 1;
            this.txtDrop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContra_KeyDown);
            // 
            // txtDown
            // 
            this.txtDown.Location = new System.Drawing.Point(91, 96);
            this.txtDown.Name = "txtDown";
            this.txtDown.ReadOnly = true;
            this.txtDown.Size = new System.Drawing.Size(75, 21);
            this.txtDown.TabIndex = 1;
            this.txtDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContra_KeyDown);
            // 
            // txtRight
            // 
            this.txtRight.Location = new System.Drawing.Point(91, 61);
            this.txtRight.Name = "txtRight";
            this.txtRight.ReadOnly = true;
            this.txtRight.Size = new System.Drawing.Size(75, 21);
            this.txtRight.TabIndex = 1;
            this.txtRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContra_KeyDown);
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(91, 26);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.ReadOnly = true;
            this.txtLeft.Size = new System.Drawing.Size(75, 21);
            this.txtLeft.TabIndex = 1;
            this.txtLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContra_KeyDown);
            // 
            // label_antiClockwise
            // 
            this.label_antiClockwise.AutoSize = true;
            this.label_antiClockwise.Location = new System.Drawing.Point(15, 204);
            this.label_antiClockwise.Name = "label_antiClockwise";
            this.label_antiClockwise.Size = new System.Drawing.Size(65, 12);
            this.label_antiClockwise.TabIndex = 0;
            this.label_antiClockwise.Text = "逆时针旋转";
            // 
            // label_deasil
            // 
            this.label_deasil.AutoSize = true;
            this.label_deasil.Location = new System.Drawing.Point(15, 169);
            this.label_deasil.Name = "label_deasil";
            this.label_deasil.Size = new System.Drawing.Size(65, 12);
            this.label_deasil.TabIndex = 0;
            this.label_deasil.Text = "顺时针旋转";
            // 
            // label_drop
            // 
            this.label_drop.AutoSize = true;
            this.label_drop.Location = new System.Drawing.Point(15, 134);
            this.label_drop.Name = "label_drop";
            this.label_drop.Size = new System.Drawing.Size(29, 12);
            this.label_drop.TabIndex = 0;
            this.label_drop.Text = "丢下";
            // 
            // label_down
            // 
            this.label_down.AutoSize = true;
            this.label_down.Location = new System.Drawing.Point(15, 99);
            this.label_down.Name = "label_down";
            this.label_down.Size = new System.Drawing.Size(29, 12);
            this.label_down.TabIndex = 0;
            this.label_down.Text = "向下";
            // 
            // label_right
            // 
            this.label_right.AutoSize = true;
            this.label_right.Location = new System.Drawing.Point(15, 64);
            this.label_right.Name = "label_right";
            this.label_right.Size = new System.Drawing.Size(29, 12);
            this.label_right.TabIndex = 0;
            this.label_right.Text = "向右";
            // 
            // label_left
            // 
            this.label_left.AutoSize = true;
            this.label_left.Location = new System.Drawing.Point(15, 29);
            this.label_left.Name = "label_left";
            this.label_left.Size = new System.Drawing.Size(29, 12);
            this.label_left.TabIndex = 0;
            this.label_left.Text = "向左";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.btnUpdate);
            this.tabPage2.Controls.Add(this.btnClear);
            this.tabPage2.Controls.Add(this.btnDel);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.lsvBlockSet);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(529, 312);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "砖块样式配置";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(9, 241);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(88, 241);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(88, 212);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 212);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lsvBlockSet
            // 
            this.lsvBlockSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvBlockSet.Font = new System.Drawing.Font("宋体", 10F);
            this.lsvBlockSet.FullRowSelect = true;
            this.lsvBlockSet.GridLines = true;
            this.lsvBlockSet.Location = new System.Drawing.Point(169, 6);
            this.lsvBlockSet.MultiSelect = false;
            this.lsvBlockSet.Name = "lsvBlockSet";
            this.lsvBlockSet.Size = new System.Drawing.Size(355, 333);
            this.lsvBlockSet.TabIndex = 2;
            this.lsvBlockSet.UseCompatibleStateImageBehavior = false;
            this.lsvBlockSet.View = System.Windows.Forms.View.Details;
            this.lsvBlockSet.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lsvBlockSet_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编码";
            this.columnHeader1.Width = 237;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "颜色";
            this.columnHeader2.Width = 112;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(9, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "修改颜色";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 156);
            this.label1.TabIndex = 0;
            this.label1.Paint += new System.Windows.Forms.PaintEventHandler(this.label1_Paint);
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.label1_MouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(173, 344);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(290, 344);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "退出";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // form_setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 402);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.配置);
            this.Name = "form_setting";
            this.Text = "配置";
            this.Load += new System.EventHandler(this.form_setting_Load);
            this.配置.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gbEnvironmentSet.ResumeLayout(false);
            this.gbEnvironmentSet.PerformLayout();
            this.gbKeySet.ResumeLayout(false);
            this.gbKeySet.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl 配置;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lsvBlockSet;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox gbEnvironmentSet;
        private System.Windows.Forms.GroupBox gbKeySet;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.TextBox txtDeasil;
        private System.Windows.Forms.TextBox txtDrop;
        private System.Windows.Forms.TextBox txtDown;
        private System.Windows.Forms.TextBox txtRight;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.Label label_antiClockwise;
        private System.Windows.Forms.Label label_deasil;
        private System.Windows.Forms.Label label_drop;
        private System.Windows.Forms.Label label_down;
        private System.Windows.Forms.Label label_right;
        private System.Windows.Forms.Label label_left;
        private System.Windows.Forms.Label lblBackColor;
        private System.Windows.Forms.TextBox txtRectPix;
        private System.Windows.Forms.TextBox txtCoorHeight;
        private System.Windows.Forms.TextBox txtCoorWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
    }
}

