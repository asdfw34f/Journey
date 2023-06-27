
namespace Journey.Security
{
    internal class LogPath
    {
        protected string _filelog = System.Reflection.Assembly
            .GetExecutingAssembly().Location + "user.melog";

        internal string FileLogPath
        {
            get => _filelog;
        }

        internal LogPath()
        { }
    }
}