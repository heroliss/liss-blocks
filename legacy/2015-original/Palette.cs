using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tetris
{
    class Palette
    {
        private int _width = 15;
        private int _height = 25;
        private Color[,] coorArr;//固定砖块数组
        private Color disapperColor;//背景色
        private Graphics gpPalette;//砖块活动画板
        private Graphics gpReady;//下一个砖块样式画板
        private BlockGroup bGroup;//砖块生产机
        private Block runBlock;//正在活动的砖块
        private Block readyBlock;//下一个砖块
        private int rectPix;

        private System.Timers.Timer timerBlock;
        private int timeSpan = 800;

        public int TimeSpan
        {
            get
            {
                return timeSpan;
            }

            set
            {
                timeSpan = value;
            }
        }
        private void OnTimeEvent(object source,System.Timers.ElapsedEventArgs e)
        {
            CheckAndOverBlock();
            Down();
        }
        public Palette(int x,int y,int pix,Color dColor,Graphics gp,Graphics gr)
        {
            _width = x;
            _height = y;
            coorArr = new Color[_width, _height];
            disapperColor = dColor;
            gpPalette = gp;
            gpReady = gr;
            rectPix = pix;
        }
        public void Start()
        {
            bGroup = new BlockGroup();
            runBlock = bGroup.GetABlock();
            runBlock.XPos = _width / 2;
            /*runBlock.YPos = 2;*/
            int y = 0;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (runBlock[i].Y>y)
                {
                    y = runBlock[i].Y;
                }
            }
            runBlock.YPos = y;

            gpPalette.Clear(disapperColor);
            runBlock.Paint(gpPalette);

            Thread.Sleep(20);
            readyBlock = bGroup.GetABlock();
            readyBlock.YPos = 2;
            readyBlock.XPos = 2;

            gpReady.Clear(disapperColor);
            readyBlock.Paint(gpReady);

            timerBlock = new System.Timers.Timer(TimeSpan);
            timerBlock.Elapsed += new System.Timers.ElapsedEventHandler(OnTimeEvent);
            timerBlock.AutoReset = true; //每次时间间隔后重新执行委托方法
            timerBlock.Start();

        }
        public bool Down()
        {
            int xPos = runBlock.XPos;
            int yPos = runBlock.YPos+1;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (yPos-runBlock[i].Y>_height-1)
                {
                    return false;
                }
                if (!coorArr[xPos+runBlock[i].X,yPos-runBlock[i].Y].IsEmpty)
                {
                    return false;
                }
            }
            runBlock.erase(gpPalette);
            runBlock.YPos++;
            runBlock.Paint(gpPalette);
            return true;
        }
        public void Drop()
        {
            timerBlock.Stop();
            while (Down());
            timerBlock.Start();
        }
        public void MoveLeft()
        {
            int xPos = runBlock.XPos-1;
            int yPos = runBlock.YPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (yPos + runBlock[i].X <0)
                {
                    return;
                }
                try
                {
                    if (!(coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty))
                    {
                        return;
                    }
                }
                catch (Exception) { return; }
            }
            runBlock.erase(gpPalette);
            runBlock.XPos--;
            runBlock.Paint(gpPalette);
            return;
        }
        public void MoveRight()
        {
            int xPos = runBlock.XPos + 1;
            int yPos = runBlock.YPos;
            for (int i = 0; i < runBlock.Length; i++)
            {
                if (yPos + runBlock[i].X < _width - 1)
                {
                    return;
                }
                try
                {
                    if (!coorArr[xPos + runBlock[i].X, yPos - runBlock[i].Y].IsEmpty)
                    {
                        return;
                    }
                }
                catch (Exception) { return; }
            }
            runBlock.erase(gpPalette);
            runBlock.XPos++;
            runBlock.Paint(gpPalette);
            return;
        }
        public void DeasilRotate()
        {
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock.XPos + runBlock[i].Y;
                int y = runBlock.YPos + runBlock[i].X;
                if (x<0||x>_width-1)
                {
                    return;
                }
                if (y<0||y>_height-1)
                {
                    return;
                }
                if (!coorArr[x,y].IsEmpty)
                {
                    return;
                }
            }
            runBlock.erase(gpPalette);
            runBlock.DeasilRotate();
            runBlock.Paint(gpPalette);
        }
        public void ContraRotate()
        {
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock.XPos - runBlock[i].Y;
                int y = runBlock.YPos - runBlock[i].X;
                if (x < 0 || x > _width - 1)
                {
                    return;
                }
                if (y < 0 || y > _height - 1)
                {
                    return;
                }
                if (!coorArr[x, y].IsEmpty)
                {
                    return;
                }
            }
            runBlock.erase(gpPalette);
            runBlock.DeasilRotate();
            runBlock.Paint(gpPalette);
        }
        private void PaintBackground(Graphics gp)
        {
            gp.Clear(Color.Black);
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (!coorArr[j,i].IsEmpty)
                    {
                        SolidBrush sb = new SolidBrush(coorArr[j, i]);
                        gp.FillRectangle(sb, j * rectPix + 1,
                            i * rectPix + 1,
                            rectPix - 2,
                            rectPix - 2);
                    }
                }
            }
        }
        public void PaintPalette(Graphics gp)
        {
            PaintBackground(gp);
            if (runBlock != null)
            {
                runBlock.Paint(gp);
            }
        }
        public void paintReady(Graphics gp)
        {
            if (readyBlock != null)
            {
                readyBlock.Paint(gp);
            }
        }
        /// <summary>
        /// 检查到底
        /// </summary>
        public void CheckAndOverBlock()
        {
            bool over = false;
            for (int i = 0; i < runBlock.Length; i++)
            {
                int x = runBlock.XPos + runBlock[i].X;
                int y = runBlock.YPos - runBlock[i].Y;
                if (y == _height - 1)
                {
                    over = true;
                    break;
                }
                try { 
                if (!coorArr[x, y + 1].IsEmpty)
                {
                    over = true;
                    break;
                }
                }
                catch (Exception) {
                    over = true;
                    break;
                }
            }

            
            if (over)
            {
                for (int i = 0; i < runBlock.Length; i++)
                {
                    coorArr[runBlock.XPos + runBlock[i].X, runBlock.YPos - runBlock[i].Y] = runBlock.BlockColor;
                }
                CheckAndDelFullRow();
                runBlock = readyBlock;
                runBlock.XPos = _width / 2;
                int y = 0;
                for (int i = 0; i < runBlock.Length; i++)
                {
                    if (runBlock[i].Y>y)
                    {
                        y = runBlock[i].Y;
                    }
                }
                runBlock.YPos = y;

                for (int i = 0; i < runBlock.Length; i++)
                {
                    if (!coorArr[runBlock.XPos+runBlock[i].X,runBlock.YPos-runBlock[i].Y].IsEmpty)
                    {   //游戏结束
                        StringFormat drawFormat = new StringFormat();
                        drawFormat.Alignment = StringAlignment.Center;
                        gpPalette.DrawString("GAME OVER",
                            new Font("Arial Black", 25f),
                            new SolidBrush(Color.White),
                            new RectangleF(0, _height * rectPix / 2 - 100, _width * rectPix, 100),
                            drawFormat);
                        timerBlock.Stop();//关闭定时器
                        return;
                    }
                }

                runBlock.Paint(gpPalette);

                readyBlock = bGroup.GetABlock();
                readyBlock.XPos = 2;
                readyBlock.YPos = 2;
                gpReady.Clear(Color.Black);
                readyBlock.Paint(gpReady);
            }
        }
        private void CheckAndDelFullRow()
        {
            int lowRow = runBlock.YPos - runBlock[0].Y;
            int highRow = lowRow;
            for (int i = 0; i < runBlock.Length; i++)
            {
                int y = runBlock.YPos - runBlock[i].Y;
                if (y<lowRow)
                {
                    lowRow = y;
                }
                if (y>highRow)
                {
                    highRow = y;
                }
            }
            bool repaint = false;
            for (int i = lowRow; i <=highRow; i++)
            {
                bool rowFull = true;
                for (int j = 0; j < _width; j++)
                {
                    if (coorArr[j,i].IsEmpty)
                    {
                        rowFull = false;
                        break;
                    }
                }
                if (rowFull)
                {
                    repaint = true;
                    for (int k = i; k > 0; k--)
                    {
                        for (int j = 0; j < _width; j++)
                        {
                            coorArr[j, k] = coorArr[j, k - 1];
                        }
                    }
                    for (int j = 0; j < _width; j++)
                    {
                        coorArr[j, 0] = Color.Empty;
                    }
                }
            }
            if (repaint)
            {
                PaintBackground(gpPalette);
            }
        }
        public void Pause()
        {
            if (timerBlock.Enabled==true)
            {
                timerBlock.Enabled = false;
            }
        }
        public void EndPause()
        {
            if (timerBlock.Enabled==false)
            {
                timerBlock.Enabled = true;
            }
        }
        public void Close()
        {
            timerBlock.Close();
            gpPalette.Dispose();
            gpReady.Dispose();
        }
    }
}
