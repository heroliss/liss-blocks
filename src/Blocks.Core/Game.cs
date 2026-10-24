namespace Liss.Blocks;
public enum Piece { I,J,L,O,S,T,Z }
public readonly record struct Cell(int X,int Y);
public sealed class Game
{
    public const int Width=10,Height=22,HiddenRows=2;
    readonly int[,] board=new int[Width,Height];readonly Queue<Piece> queue=new();Random random=new();
    public Piece Current {get;private set;}public int X{get;private set;}public int Y{get;private set;}public int Rotation{get;private set;}public Piece? Held{get;private set;}
    public bool HoldUsed{get;private set;}public bool Over{get;private set;}public bool Paused{get;private set;}public bool PracticeActive{get;private set;}public long Score{get;private set;}public int Lines{get;private set;}public int Pieces{get;private set;}public int LastClear{get;private set;}public int Level=>1+Lines/10;
    public int GravityMilliseconds=>Math.Max(65,760-(Level-1)*58);
    public IEnumerable<Piece> Next=>queue.Take(5);public int this[int x,int y]=>board[x,y];
    public static Cell[] Shape(Piece piece,int rotation)
    {
        Cell[] cells=piece switch{Piece.I=>[new(0,1),new(1,1),new(2,1),new(3,1)],Piece.J=>[new(0,0),new(0,1),new(1,1),new(2,1)],Piece.L=>[new(2,0),new(0,1),new(1,1),new(2,1)],Piece.O=>[new(1,0),new(2,0),new(1,1),new(2,1)],Piece.S=>[new(1,0),new(2,0),new(0,1),new(1,1)],Piece.T=>[new(1,0),new(0,1),new(1,1),new(2,1)],_=>[new(0,0),new(1,0),new(1,1),new(2,1)]};
        if(piece==Piece.O)return cells;
        var size=piece==Piece.I?4:3;
        for(int i=0;i<((rotation%4)+4)%4;i++)for(int j=0;j<cells.Length;j++)cells[j]=new(size-1-cells[j].Y,cells[j].X);
        return cells;
    }
    public IEnumerable<Cell> Cells(int? atY=null)=>Shape(Current,Rotation).Select(c=>new Cell(c.X+X,c.Y+(atY??Y)));
    public bool Fits(Piece p,int r,int x,int y)=>Shape(p,r).All(c=>c.X+x>=0&&c.X+x<Width&&c.Y+y>=0&&c.Y+y<Height&&board[c.X+x,c.Y+y]==0);
    public int GhostY {get{var y=Y;while(Fits(Current,Rotation,X,y+1))y++;return y;}}
    public Game(int seed=0)=>Reset(seed);
    public void Reset(int seed=0){Array.Clear(board);queue.Clear();random=seed==0?new Random():new Random(seed);Score=0;Lines=0;Pieces=0;LastClear=0;Held=null;HoldUsed=false;Over=false;Paused=false;PracticeActive=false;FillBag();Spawn();}
    void FillBag(){while(queue.Count<8){var bag=Enum.GetValues<Piece>();for(int i=bag.Length-1;i>0;i--){int j=random.Next(i+1);(bag[i],bag[j])=(bag[j],bag[i]);}foreach(var p in bag)queue.Enqueue(p);}}
    void Spawn(){FillBag();Current=queue.Dequeue();X=3;Y=1;Rotation=0;HoldUsed=false;if(!Fits(Current,Rotation,X,Y))Over=true;}
    public bool Move(int dx){if(Over||Paused||!Fits(Current,Rotation,X+dx,Y))return false;X+=dx;return true;}
    public bool Rotate(int direction=1)
    {
        if(Over||Paused)return false;var r=((Rotation+direction)%4+4)%4;
        Cell[] kicks=[new(0,0),new(-1,0),new(1,0),new(-2,0),new(2,0),new(0,-1),new(-1,-1),new(1,-1),new(0,-2)];
        foreach(var k in kicks)if(Fits(Current,r,X+k.X,Y+k.Y)){Rotation=r;X+=k.X;Y+=k.Y;return true;}return false;
    }
    public bool Step(bool soft=false){if(Over||Paused)return false;if(Fits(Current,Rotation,X,Y+1)){Y++;if(soft)Score++;return true;}Lock();return false;}
    public int HardDrop(){if(Over||Paused)return 0;int d=GhostY-Y;Y+=d;Score+=d*2;Lock();return d;}
    public bool Hold(){if(Over||Paused||HoldUsed)return false;var old=Current;if(Held is Piece p){Current=p;X=3;Y=1;Rotation=0;if(!Fits(Current,Rotation,X,Y))Over=true;}else Spawn();Held=old;HoldUsed=true;return true;}
    public void Pause(){if(!Over)Paused=!Paused;}
    void Lock(){foreach(var c in Cells())board[c.X,c.Y]=(int)Current+1;Pieces++;LastClear=ClearFullRows();Score+=(new[]{0,100,300,500,800}[LastClear])*Level;Lines+=LastClear;if(Enumerable.Range(0,Width).Any(x=>board[x,0]!=0||board[x,1]!=0)){Over=true;return;}Spawn();}
    int ClearFullRows(){int cleared=0;for(int y=Height-1;y>=0;y--){if(Enumerable.Range(0,Width).Any(x=>board[x,y]==0))continue;for(int yy=y;yy>0;yy--)for(int x=0;x<Width;x++)board[x,yy]=board[x,yy-1];for(int x=0;x<Width;x++)board[x,0]=0;cleared++;y++;}return cleared;}
    // A user-visible practice board, not a fabricated play result. Every metric starts at zero.
    public void Practice(int seed=2026){Reset(seed);PracticeActive=true;for(int y=Height-7;y<Height;y++)for(int x=0;x<Width;x++){if(x==4||(y<Height-4&&x==5))continue;board[x,y]=1+((x+2*y)%7);}for(int i=0;i<5;i++)Step();Score=0;Lines=0;Pieces=0;LastClear=0;}
    public int[,] Snapshot()=>(int[,])board.Clone();
    public static int ClearRowsForTest(int[,] input)
    {
        if(input.GetLength(0)!=Width||input.GetLength(1)!=Height)throw new ArgumentException();var g=new Game(1);Array.Copy(input,g.board,input.Length);return g.ClearFullRows();
    }
}
