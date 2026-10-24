namespace Liss.Blocks.App;
internal static class Program
{
    [STAThread] static void Main(string[] args){ApplicationConfiguration.Initialize();Application.Run(new GameForm(args.Contains("--showcase")));}
}
