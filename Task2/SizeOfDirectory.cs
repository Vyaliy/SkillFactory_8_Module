namespace FinalTask
{
    public class SizeOfDirectory
    {
        static void Main(string[] args)
        {
            //"C:\\Users\\Никита\\source\\repos\\SkillFactory_8_Module"
            string path;
            do
            {
                Console.Write("Путь к папке для подсчета занимаемой памяти: ");
                path = Console.ReadLine();
            } while (!Directory.Exists(path));
            var size = CountMemory(path);
            Console.WriteLine($"{size} bytes");
            Console.ReadKey();
        }

        public static long CountMemory(string path)
        {
            long size = 0;
            DirectoryInfo dir = new DirectoryInfo(path);
            var subdirs = dir.GetDirectories();
            if (subdirs.Length > 0)
                foreach (var subdir in subdirs)
                    size += CountMemory(subdir.FullName);
            var subfiles = dir.GetFiles();
            if (subfiles.Length > 0)
                foreach (var subfile in subfiles)
                    size += subfile.Length;
            return size;
        }

    }
}