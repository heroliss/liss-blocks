using Liss.Blocks;
using System.Text.Json;
var checks=new List<string>();void Check(bool ok,string n){if(!ok)throw new Exception(n);checks.Add(n);}
foreach(var p in Enum.GetValues<Piece>())for(int r=0;r<4;r++){var cells=Game.Shape(p,r);Check(cells.Length==4&&cells.Distinct().Count()==4,$"{p} rotation {r} has four distinct cells");}
var a=new Game(42);var b=new Game(42);Check(a.Current==b.Current&&a.Next.SequenceEqual(b.Next),"seed reproducibility");
var bag=new HashSet<Piece>();for(int i=0;i<7;i++){bag.Add(a.Current);a.HardDrop();}Check(bag.Count==7,"first seven pieces form one complete bag");
a.Reset(23);var start=a.Cells().OrderBy(c=>c.X).ThenBy(c=>c.Y).ToArray();for(int i=0;i<4;i++)a.Rotate();Check(start.SequenceEqual(a.Cells().OrderBy(c=>c.X).ThenBy(c=>c.Y)),"four clockwise rotations restore shape");
a.Rotate();a.Rotate(-1);Check(start.SequenceEqual(a.Cells().OrderBy(c=>c.X).ThenBy(c=>c.Y)),"clockwise and counterclockwise cancel");
var x=a.X;for(int i=0;i<25;i++)a.Move(-1);Check(a.Cells().All(c=>c.X>=0),"left wall collision");for(int i=0;i<25;i++)a.Move(1);Check(a.Cells().All(c=>c.X<Game.Width),"right wall collision");Check(a.Fits(a.Current,a.Rotation,a.X,a.GhostY)&&!a.Fits(a.Current,a.Rotation,a.X,a.GhostY+1),"ghost marks exact landing row");
var old=a.Current;Check(a.Hold()&&a.Held==old,"hold stores current piece");Check(!a.Hold(),"second hold before lock rejected");a.HardDrop();Check(!a.HoldUsed&&a.Hold(),"hold enabled after lock");
a.Pause();var state=(a.X,a.Y,a.Rotation,a.Score,a.Pieces,a.Current);a.Move(-1);a.Rotate();a.HardDrop();a.Step();a.Hold();Check(state==(a.X,a.Y,a.Rotation,a.Score,a.Pieces,a.Current),"all gameplay blocked while paused");a.Pause();Check(!a.Paused,"pause resumes");
var full=new int[Game.Width,Game.Height];for(int y=Game.Height-4;y<Game.Height;y++)for(int xx=0;xx<Game.Width;xx++)full[xx,y]=1;Check(Game.ClearRowsForTest(full)==4,"four consecutive full rows clear");full[2,Game.Height-1]=0;Check(Game.ClearRowsForTest(full)==3,"incomplete row retained");Check(Game.ClearRowsForTest(new int[Game.Width,Game.Height])==0,"empty board clears no rows");
a.Reset(7);var drop=a.GhostY-a.Y;var d=a.HardDrop();Check(d==drop&&a.Score==drop*2&&a.Pieces==1,"hard drop locks and scores distance");
a.Reset(7);Check(a.Step(true)&&a.Score==1,"soft drop scores one point");var snapshot=a.Snapshot();snapshot[0,21]=7;Check(a[0,21]==0,"board snapshots are isolated copies");
a.Practice();Check(a.Score==0&&a.Lines==0&&a.Pieces==0&&a.Snapshot().Cast<int>().Any(v=>v!=0),"practice board has no fabricated play metrics");a.Reset(3);Check(a.Score==0&&a.Pieces==0&&a.Held is null&&a.Snapshot().Cast<int>().All(v=>v==0),"restart clears entire session");
a.Practice();a.Hold();a.Rotate();a.Move(-1);a.HardDrop();Check(a.Lines==4&&a.LastClear==4&&a.Score>=800,"practice well supports real four-line clear");
var random=new Random(732);int iterations=0,over=0;
for(int trial=0;trial<300;trial++){a.Reset(trial+1);for(int i=0;i<2500&&!a.Over;i++){switch(random.Next(7)){case 0:a.Move(-1);break;case 1:a.Move(1);break;case 2:a.Rotate();break;case 3:a.Rotate(-1);break;case 4:a.Step(true);break;case 5:a.Hold();break;default:a.HardDrop();break;}if(!a.Over&&(!a.Fits(a.Current,a.Rotation,a.X,a.Y)||a.Cells().Distinct().Count()!=4))throw new Exception("simulation invariant");iterations++;}if(a.Over)over++;}
Check(over==300,"300 random games terminate without invalid board writes");Check(iterations>10000,"random action stress coverage");
Console.WriteLine(JsonSerializer.Serialize(new{passed=true,count=checks.Count,randomActions=iterations,checks},new JsonSerializerOptions{WriteIndented=true}));
