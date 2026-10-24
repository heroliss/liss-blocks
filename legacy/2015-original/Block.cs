using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Block
    {
        private Point[] structArr;
        private int _xPos;
        private int _yPos; //砖块中心点所在坐标
        private Color _blockColor;
        private Color disapperColor;//擦除颜色
        private int rectPix;//单元格像素

        public Block()
        { }

        public Block(Point[] sa,Color blockColor,Color disColor,int pix)
        {
            BlockColor = blockColor;
            disapperColor = disColor;
            rectPix = pix;
            structArr = sa;
        }
        /// <summary>
        /// 只读索引，根据索引访问砖块矩阵里砖块的点坐标
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Point</returns>
        public Point this[int index]
        {
            get
            {
                return structArr[index];
            }
        }
        /// <summary>
        /// structArr的长度,配合索引器使用
        /// </summary>
        public int Length
        {
            get
            {
                return structArr.Length;
            }
        }
        #region 成员变量属性
        public int XPos
        {
            get
            {
                return _xPos;
            }

            set
            {
                _xPos = value;
            }
        }

        public int YPos
        {
            get
            {
                return _yPos;
            }

            set
            {
                _yPos = value;
            }
        }

        public Color BlockColor
        {
            get
            {
                return _blockColor;
            }

            set
            {
                _blockColor = value;
            }
        }
        #endregion

        public void DeasilRotate()
        {
            int temp;
            for (int i = 0; i < structArr.Length; i++)
            {
                temp = structArr[i].X;
                structArr[i].X = structArr[i].Y;
                structArr[i].Y = -temp;
            }
        }
        public void ContraRotate()
        {
            int temp;
            for (int i = 0; i < structArr.Length; i++)
            {
                temp = structArr[i].X;
                structArr[i].X = -structArr[i].Y;
                structArr[i].Y = temp;
            }
        }
        private Rectangle PointToRect(Point p) //把一个小方块的坐标转化为画布方块
        {
            return new Rectangle(
                (_xPos + p.X) * rectPix + 1,
                (_yPos - p.Y) * rectPix + 1,
                rectPix - 2,
                rectPix - 2);
        }
        public virtual void Paint(Graphics gp) //在指定画板中绘制方块矩阵
        {
            SolidBrush sb = new SolidBrush(_blockColor);
            foreach (Point p in structArr)
            {
                lock (gp)
                {
                    gp.FillRectangle(sb, PointToRect(p));
                }
            }
        }
        public void erase(Graphics gp) //擦除方块
        {
            SolidBrush sb = new SolidBrush(disapperColor);
            foreach (Point p in structArr)
            {
                lock (gp)
                {
                    gp.FillRectangle(sb, PointToRect(p));
                }
            }
        }
    }
}
