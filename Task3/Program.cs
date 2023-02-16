namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Deleter.AskPath();
            long preSize = SizeOfDirectory.CountMemory(path);
            Console.WriteLine($"Исходный размер папки: {preSize} байт");
            Deleter.DeleteSubDirectories(path);
            long postSize = SizeOfDirectory.CountMemory(path);
            Console.WriteLine($"Освобождено: {preSize - postSize} байт");
            Console.WriteLine($"Текущий размер папки: {postSize} байт");
            Console.ReadKey();
        }
    }
}