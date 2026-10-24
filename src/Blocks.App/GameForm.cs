using System.Diagnostics;
using System.Drawing.Drawing2D;
using Liss.Blocks;
namespace Liss.Blocks.App;
public sealed class GameForm:Form
{
    readonly Game game=new();readonly BoardView view;readonly System.Windows.Forms.Timer timer=new(){Interval=16};readonly Stopwatch clock=Stopwatch.StartNew();readonly HashSet<Keys> held=[];
    readonly Button pause=new(),restart=new(),practice=new();long lastGravity,lastRepeat;int direction;bool repeating;
    public GameForm(bool showcase)
    {
        Text="Liss Blocks · 方块之间";ClientSize=new(1240,880);MinimumSize=new(1060,840);StartPosition=FormStartPosition.CenterScreen;AutoScaleMode=AutoScaleMode.Dpi;BackColor=BoardView.Bg;Font=new("Microsoft YaHei UI",10);KeyPreview=true;ImeMode=ImeMode.Disable;
        if(showcase){game.Practice();game.Pause();}view=new(game){Dock=DockStyle.Fill,TabStop=true};Controls.Add(view);
        var actions=new FlowLayoutPanel{Dock=DockStyle.Bottom,Height=66,Padding=new(32,10,0,0),BackColor=BoardView.Bg};Controls.Add(actions);actions.BringToFront();Make(pause,"暂停 / P",(_,_)=>TogglePause());Make(restart,"新的一局 / R",(_,_)=>Restart(false));Make(practice,"练习局",(_,_)=>Restart(true));actions.Controls.AddRange([pause,restart,practice]);
        var hint=new Label{Text="方向键移动   ·   ↑ / X 旋转   ·   空格硬降   ·   C 暂存",AutoSize=true,ForeColor=BoardView.Muted,Margin=new(24,10,0,0)};actions.Controls.Add(hint);
        KeyUp+=(_,e)=>held.Remove(e.KeyCode);view.MouseDown+=(_,_)=>view.Focus();Deactivate+=(_,_)=>{held.Clear();direction=0;if(!game.Paused&&!game.Over){game.Pause();UpdateStatus();}};
        Shown+=(_,_)=>{view.Focus();lastGravity=clock.ElapsedMilliseconds;timer.Start();};FormClosed+=(_,_)=>timer.Dispose();timer.Tick+=(_,_)=>TickFrame();
        UpdateStatus();
    }
    static void Make(Button b,string text,EventHandler action){b.Text=text;b.Size=new(144,40);b.Margin=new(0,0,10,0);b.FlatStyle=FlatStyle.Flat;b.FlatAppearance.BorderColor=BoardView.Line;b.BackColor=BoardView.Panel;b.ForeColor=BoardView.Ink;b.Cursor=Cursors.Hand;b.Click+=action;}
    void Restart(bool p){if(game.Pieces>0&&!game.Over&&MessageBox.Show(this,"开始新的一局？当前进度将被重置。","Liss Blocks",MessageBoxButtons.YesNo,MessageBoxIcon.Question)!=DialogResult.Yes)return;if(p)game.Practice();else game.Reset();lastGravity=clock.ElapsedMilliseconds;held.Clear();UpdateStatus();view.Focus();}
    void TogglePause(){game.Pause();held.Clear();lastGravity=clock.ElapsedMilliseconds;UpdateStatus();view.Focus();}
    void UpdateStatus(){pause.Text=game.Paused?"继续 / P":"暂停 / P";pause.Enabled=!game.Over;view.Invalidate();}
    protected override bool ProcessCmdKey(ref Message msg,Keys keyData)
    {
        var key=keyData&Keys.KeyCode;
        if(key is Keys.Left or Keys.Right or Keys.Down or Keys.Up or Keys.X or Keys.Z or Keys.C or Keys.Space or Keys.P or Keys.R or Keys.Escape)
        {
            if(!held.Add(key))return true;
            switch(key){case Keys.Left:game.Move(-1);direction=-1;lastRepeat=clock.ElapsedMilliseconds;repeating=false;break;case Keys.Right:game.Move(1);direction=1;lastRepeat=clock.ElapsedMilliseconds;repeating=false;break;case Keys.Down:game.Step(true);break;case Keys.Up:case Keys.X:game.Rotate();break;case Keys.Z:game.Rotate(-1);break;case Keys.C:game.Hold();lastGravity=clock.ElapsedMilliseconds;break;case Keys.Space:game.HardDrop();lastGravity=clock.ElapsedMilliseconds;break;case Keys.P:case Keys.Escape:TogglePause();break;case Keys.R:Restart(false);break;}
            if(key is Keys.P or Keys.Escape or Keys.R)held.Add(key);UpdateStatus();return true;
        }
        return base.ProcessCmdKey(ref msg,keyData);
    }
    void TickFrame()
    {
        var now=clock.ElapsedMilliseconds;
        if(!game.Paused&&!game.Over)
        {
            var want=held.Contains(Keys.Left)?-1:held.Contains(Keys.Right)?1:0;if(want==0)direction=0;
            if(want!=0&&want==direction&&now-lastRepeat>=(repeating?50:150)){game.Move(want);repeating=true;lastRepeat=now;}
            var interval=held.Contains(Keys.Down)?32:game.GravityMilliseconds;
            if(now-lastGravity>=interval){game.Step(held.Contains(Keys.Down));lastGravity=now;}
        }
        UpdateStatus();
    }
}
public sealed class BoardView:Control
{
    public static readonly Color Bg=Color.FromArgb(10,17,28),Panel=Color.FromArgb(17,28,44),Line=Color.FromArgb(42,61,81),Ink=Color.FromArgb(237,244,253),Muted=Color.FromArgb(164,185,207),Accent=Color.FromArgb(107,231,219);
    static readonly Color[] Colors=[Color.Empty,Color.FromArgb(75,210,230),Color.FromArgb(103,143,243),Color.FromArgb(255,175,91),Color.FromArgb(244,217,101),Color.FromArgb(104,221,157),Color.FromArgb(185,143,247),Color.FromArgb(244,116,147)];
    readonly Game game;public BoardView(Game g){game=g;DoubleBuffered=true;BackColor=Bg;ImeMode=ImeMode.Disable;AccessibleName="方块游戏棋盘";AccessibleDescription="方向键移动，上或 X 顺时针旋转，Z 逆时针，空格硬降，C 暂存，P 暂停。";}
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);var g=e.Graphics;g.SmoothingMode=SmoothingMode.AntiAlias;g.TextRenderingHint=System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
        DrawText(g,"LISS",34,23,12,Accent,FontStyle.Bold);DrawText(g,"BLOCKS",33,44,34,Ink,FontStyle.Bold);DrawText(g,"方块之间",274,49,14,Muted);DrawText(g,"SEVEN PIECES. ENDLESS POSSIBILITIES.",Width-418,44,9,Muted);
        using(var pen=new Pen(Line))g.DrawLine(pen,34,103,Width-34,103);
        int cell=Math.Min((Height-139)/20,32);int bw=cell*Game.Width,bh=cell*20,bx=(Width-bw)/2,by=125;
        DrawText(g,"HOLD / 暂存",42,137,10,Muted);Card(g,38,168,Math.Max(200,bx-82),125);if(game.Held is Piece h)Mini(g,h,80,196,22);else DrawText(g,"按 C 暂存当前方块",60,212,10,Muted);
        DrawText(g,game.HoldUsed?"本回合已暂存":"每个方块可暂存一次",46,309,9,Muted);
        DrawText(g,"操作",43,382,12,Ink,FontStyle.Bold);string[] controls=["←  →     左右移动","↓           加速下落","↑ / X     顺时针旋转","Z           逆时针旋转","SPACE   直接落地","C           暂存 / 交换","P / ESC  暂停 / 继续","R           重新开始"];
        for(int i=0;i<controls.Length;i++)DrawText(g,controls[i],44,426+i*34,10,Muted);
        DrawText(g,"7-BAG 随机袋 · 落点预览",43,Height-50,9,Accent);
        using(var brush=new SolidBrush(Color.FromArgb(12,23,37)))g.FillRectangle(brush,bx-8,by-8,bw+16,bh+16);
        using(var line=new Pen(Color.FromArgb(27,42,59))){for(int x=0;x<=Game.Width;x++)g.DrawLine(line,bx+x*cell,by,bx+x*cell,by+bh);for(int y=0;y<=20;y++)g.DrawLine(line,bx,by+y*cell,bx+bw,by+y*cell);}
        for(int y=Game.HiddenRows;y<Game.Height;y++)for(int x=0;x<Game.Width;x++)if(game[x,y]!=0)Block(g,bx+x*cell,by+(y-Game.HiddenRows)*cell,cell,Colors[game[x,y]],false);
        if(!game.Over){foreach(var c in game.Cells(game.GhostY))if(c.Y>=Game.HiddenRows)Block(g,bx+c.X*cell,by+(c.Y-Game.HiddenRows)*cell,cell,Colors[(int)game.Current+1],true);foreach(var c in game.Cells())if(c.Y>=Game.HiddenRows)Block(g,bx+c.X*cell,by+(c.Y-Game.HiddenRows)*cell,cell,Colors[(int)game.Current+1],false);}
        var rx=bx+bw+44;var rw=Width-rx-38;
        DrawText(g,"SCORE / 得分",rx,137,10,Muted);DrawText(g,game.Score.ToString("N0"),rx,166,34,Ink,FontStyle.Bold);Card(g,rx,234,rw,105);DrawText(g,"等级",rx+16,247,9,Muted);DrawText(g,game.Level.ToString("00"),rx+16,274,22,Accent,FontStyle.Bold);DrawText(g,"消除行数",rx+rw/2,247,9,Muted);DrawText(g,game.Lines.ToString("00"),rx+rw/2,274,22,Ink,FontStyle.Bold);
        DrawText(g,"NEXT / 接下来",rx,370,10,Muted);int n=0;foreach(var p in game.Next){Mini(g,p,rx+28,410+n*66,19);DrawText(g,$"{++n:00}",rx+rw-38,412+(n-1)*66,9,Muted);}
        if(game.Paused||game.Over){using var scrim=new SolidBrush(Color.FromArgb(215,Bg));g.FillRectangle(scrim,bx,by,bw,bh);var text=game.Over?"本局结束":"已暂停";DrawText(g,text,bx+64,by+bh/2-45,27,Ink,FontStyle.Bold);DrawText(g,game.Over?"按 R 开始新的一局":"按 P 继续游戏",bx+67,by+bh/2+7,11,Accent);}
        DrawText(g,$"{(game.PracticeActive?"练习局":"标准局")}  ·  落块 {game.Pieces}   /   {(game.Over?"GAME OVER":game.Paused?"PAUSED":"PLAYING")}",bx,by+bh+18,9,Muted);
    }
    static void Card(Graphics g,int x,int y,int w,int h){using var b=new SolidBrush(Panel);g.FillRectangle(b,x,y,w,h);using var p=new Pen(Line);g.DrawRectangle(p,x,y,w,h);}
    static void DrawText(Graphics g,string s,float x,float y,float size,Color color,FontStyle style=FontStyle.Regular){using var f=new Font("Microsoft YaHei UI",size,style);using var b=new SolidBrush(color);g.DrawString(s,f,b,x,y);}
    static void Mini(Graphics g,Piece p,int x,int y,int size){foreach(var c in Game.Shape(p,0))Block(g,x+c.X*size,y+c.Y*size,size,Colors[(int)p+1],false);}
    static void Block(Graphics g,int x,int y,int size,Color color,bool ghost)
    {
        var rect=new Rectangle(x+2,y+2,size-4,size-4);
        if(ghost){using var p=new Pen(Color.FromArgb(145,color),2);g.DrawRectangle(p,rect);return;}
        using var brush=new SolidBrush(color);g.FillRectangle(brush,rect);using var top=new Pen(Color.FromArgb(100,Color.White));g.DrawLine(top,rect.Left+1,rect.Top+1,rect.Right-1,rect.Top+1);using var shade=new SolidBrush(Color.FromArgb(35,Color.Black));g.FillRectangle(shade,rect.X,rect.Bottom-5,rect.Width,5);
    }
}

