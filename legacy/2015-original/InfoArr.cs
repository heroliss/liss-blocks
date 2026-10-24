using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class InfoArr
    {
        private ArrayList info = new ArrayList();
        private int _length = 0;
        public int Length
        {
            get
            {
                return _length;
            }
        }
        public BlockInfo this[int index]
        {
            get
            {
                return (BlockInfo)info[index];
            }
        }
        public string this[string id]
        {
            set
            {
                if (value=="")
                {
                    return;
                }
                for (int i = 0; i < info.Count; i++)
                {
                    if (((BlockInfo)info[i]).GetIdStr() == id)
                    {
                        try
                        {
                            ((BlockInfo)info[i]).BColor = System.Drawing.Color.FromArgb(Convert.ToInt32(value));
                        }
                        catch (System.FormatException)
                        {
                            System.Windows.Forms.MessageBox.Show("颜色信息错误！请删除BlockSet.xml文件，并重新启动程序", "错误信息",
                                System.Windows.Forms.MessageBoxButtons.OK, 
                                System.Windows.Forms.MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 把字符串转为BitArray
        /// </summary>
        /// <param name="id">1，0字符串</param>
        /// <returns>BitArray</returns>
        private BitArray strToBit(string id)
        {
            if (id.Length!=25)
            {
                throw new FormatException("砖块样式信息不合法！请删除BlockSet.xml文件，并重新启动程序");
            }
            BitArray ba = new BitArray(25);
            for (int i = 0; i < 25; i++)
            {
                ba[i] = (id[i] == '0') ? false : true;
            }
            return ba;
        }

        public void Add(BitArray id,Color bColor)
        {
            if (id.Length != 25)
            {
                throw new System.FormatException("砖块样式信息不合法！请删除BlockSet.xml文件，并重新启动程序");
            }
            info.Add(new BlockInfo(id, bColor));
            _length++;
        }

        public void Add(string id,string bColor)
        {
            Color temp;
            if (!(bColor == ""))
            {
                temp = Color.FromArgb(Convert.ToInt32(bColor));
            }
            else
            {
                temp = Color.Empty;
            }
            info.Add(new BlockInfo(strToBit(id), temp));
            _length++;
        }
    }
}
