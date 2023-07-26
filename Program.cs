using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OSL_Assignment2
{
    internal class Program
    {
        static List<Student> studs = new List<Student>();
        public static void ReadFile()
        {
            string path = @"D:\Raven\Practice Exercise\C#\OSL_Assignment2\Student.txt";
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string[] datas = line.Split(',');
                if (datas.Length == 2)
                {
                    Student student = new Student { Name = datas[0].Trim(), Class = datas[1].Trim() };
                    studs.Add(student);
                }
            }
        }
        public static void DisplayAll()
        {
            int index = 1;
            foreach (Student st in studs)
            {
                Console.WriteLine($"{index++}. {st.Name}\t\t Class : {st.Class}");
            }
        }
        public static void SortAll()
        {
            studs.Sort((s1,s2)=>string.Compare(s1.Name,s2.Name,StringComparison.Ordinal));
            DisplayAll();
        }
        public static List<string> Search(string name)
        {
            List<string> result = new List<string>();
            foreach(Student st in studs)
            {
                if (st.Name.Equals(name))
                    result.Add(($"{st.Name},{st.Class}"));
            }
            return result;
        }
        static void Main(string[] args)
        {
            repeat:
            try
            {
                studs.Clear();
                ReadFile();
                Console.WriteLine("Available Function to Perform");
                Console.WriteLine("1. Display All Data\n2. Sort and Display All Data\n3. Search Certain Data");
                Console.WriteLine();
                Console.WriteLine("Enter the Function Number");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        {
                            DisplayAll();
                            break;
                        }
                    case 2:
                        {
                            SortAll();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter the Student name to Search");
                            string name = Console.ReadLine();
                            List<string> result = Search(name);
                            if(result.Count==0)
                                Console.WriteLine($"\n{name} is not present in the file");
                            else
                            {
                                Console.WriteLine("\nThe Students are");
                                int i = 1;
                                foreach (string list in result)
                                    Console.WriteLine($"{i++}. "+list);
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Enter The Right Option....!!!!\n");
                            goto repeat;
                        }
                }
                Console.WriteLine("\nWould you like to perform another function? \nIf Yes Press 1");
                int again = int.Parse(Console.ReadLine());
                if (again == 1)
                    goto repeat;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
