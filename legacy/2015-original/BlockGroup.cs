using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class BlockGroup
    {
        private InfoArr info;
        private Color disapperColor;//背景色
        private int rectPix;//单元格像素

        public BlockGroup()
        {
            Config config = new Config();
            config.LoadFromXmlFile();
            info = new InfoArr();
            info = config.Info;
            disapperColor = config.BackColor;
            rectPix = config.RectPix;
        }
        public Block GetABlock()
        {
            Random rd = new Random();
            int keyOrder = rd.Next(0, info.Length);//不包括最大值
            BitArray ba = info[keyOrder].ID;
            int struNum = 0;
            foreach(bool b in ba) //确定该砖块样式中点亮的砖块个数
            {
                if (b)
                {
                    struNum++;
                }
            }
            Point[] structArr = new Point[struNum];
            int k = 0;
            for (int j = 0; j < ba.Length; j++)
            {
                if (ba[j])
                {
                    structArr[k].X = j / 5 - 2;
                    structArr[k].Y = 2 - j % 5;
                    k++;
                }
            }
            return new Block(structArr, info[keyOrder].BColor, disapperColor, rectPix);
        }
    }
}
