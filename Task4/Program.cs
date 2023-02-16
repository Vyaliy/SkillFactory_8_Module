#pragma warning disable SYSLIB0011
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    internal class DbStudents
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fs = new FileStream("Students.dat", FileMode.Open))
            {
                do
                {
                    var a = formatter.Deserialize(fs);
                    students.Add((Student)a);
                } while(fs.Length > 0);
            }
            string path = Directory.GetCurrentDirectory() + "\\Students";
            DirectoryInfo dir = new DirectoryInfo(path);
            if (!Directory.Exists(path))
                dir.Create();

        }
    }
    [Serializable]
    class Student
    {
        public string Name;
        public string Group;
        public DateTime DateOfBirth;
    }
}