using System.IO;
using TodoApp.Services;

namespace TodoApp.Droid
{
    public class DbPath : IDbPath
    {
        public string GetDbPath(string fileName)
        {
            string documentsPath = 
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            return path;
        }
    }
}