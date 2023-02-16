using System.IO;

namespace FinalTask
{
    public class Deleter
    {
        static void Main(string[] args)
        {
            //C:\Users\Никита\source\repos\SkillFactory_8_Module\SkillFactory_8_Module\ForTask1
            string path = AskPath();
            DeleteSubDirectories(path);
            Console.ReadKey();
        }
        public static string AskPath()
        {
            string path;
            do
            {
                Console.Write("Путь до папки: ");
                path = Console.ReadLine();
            } while (!Directory.Exists(path));
            return path;
        }
        public static void DeleteSubDirectories(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var subdir in dir.GetFileSystemInfos())
                if ((DateTime.Now - subdir.LastAccessTime) > TimeSpan.FromMinutes(30))
                    DeleteFileOrDirectory(subdir);
        }
        public static void DeleteFileOrDirectory(FileSystemInfo fileOrDirectory)
        {
            try
            {
                switch (fileOrDirectory)
                {
                    case DirectoryInfo:
                        ((DirectoryInfo)fileOrDirectory).Delete(true);
                        break;
                    case FileInfo:
                        fileOrDirectory.Delete();
                        break;
                    default: 
                        throw new Exception("Переданное в метод значение недопустимо");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}