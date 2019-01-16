using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObj
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("===============LinqBegin5================");
            ResolveLinqBegin5();
            Console.WriteLine("===============LinqBegin18===============");
            SolveLinqBegin18();
            Console.WriteLine("===============LinqBegin40===============");
            SolveLinqBegin40();
            Console.WriteLine("===============LinqBegin56===============");
            SolveLinqBegin56();
            Console.WriteLine("===============LinqObj1===============");
            SolveLinqObj1();
            Console.WriteLine("===============LinqObj2===============");
            SolveLinqObj2();*/
            Console.WriteLine("===============LinqObj55===============");
            ResolveLinqObj55();
        }

        // Количество элементов А, которые содержат более одного символа
        // и при этом начинаются т оканчиваются символом С
        static void ResolveLinqBegin5()
        {
            char C = 'c';
            string[] A = { "asdfv", "ccBVG", "dsfvghtd", "cccc", "certc", "ccccddgc", "c", "fkjkjhf" };
            var elementCount = A
                .Where(e => (e.First() & e.Last()) == C && e.Count() > 1)
                .Count();
            Console.WriteLine($"Count: {elementCount}");
            Console.ReadLine();
        }

        // Все четные отрицательные числа, поменяв порядок извлеченных чисел на обратный
        static void SolveLinqBegin18()
        {
            int[] a = { 1, -4, 5, 7, -1, 7, -3, 5, -5, -6, -2 };
            var number = a
                .Where(e => (e < 0) && (e % 2 == 0));
            foreach (var i in number.Reverse())
                Console.WriteLine($"{i}");
            Console.ReadLine();
        }

        // Получить последовательность символов, содержающую символы всех строк из А, имеющих длину,
        // меньшую или равную К (символы могут повторяться), поменять порядок элементов на обратный
        static void SolveLinqBegin40()
        {
            int K = 12;
            string[] A = { "vd", "67", "213235", "1235436", "12", "0", "21", "434212", "232312354", "33", "1" };
            var str = A
                .Where(e => e.Length <= K);

            foreach (var i in str.Reverse())
                Console.WriteLine($"{i}");

            Console.ReadLine();
        }

        // Сгруппировать элементы последовательности А, оканчивающиеся одной и той же цифрой, на основе
        // этой группировки получить последовательность строк вида "D:S", где D -ключ группировки
        // т.е. некоторая цифра, которой оканчивается хотя бы одно из чисел последовательности А
        // S - сумма всех чисел из А, которые оканчиваются цифрой D, полученную последовательность 
        // упорядочить по возрастанию ключей
        static void SolveLinqBegin56()
        {
            int[] A = { 41, -445, 455, 677, -10078, 76789, -3685, 56758, -5456, -63, -28, 20, 10, -30 };
            var group = A
                .GroupBy(e => e.ToString().Last())
                .Select(e => e.Key + ":" + e.Sum(c => c))
                .OrderBy(e => e.Split(':').First());

            foreach (var i in group)
                Console.WriteLine($"{i}");

            Console.ReadLine();
        }

        // Найти элемент последовательности с минимальной продолжительностью занятий
        // Вывести эту продолжительность, а также соответствующий ей год и номер месяца
        // Если имеется несколько элементов с минимальной продолжительностью, то вывести ту,
        // которая является последним в исходной последовательности
        static void SolveLinqObj1()
        {
            try
            {
                var minDuration = File.ReadLines("Source/file.txt", Encoding.Default)
                    .Select(e =>
                    {
                        String[] s = e.Split(' ');
                        return new
                        {
                            duration = int.Parse(s[3]),
                            year = int.Parse(s[1]),
                            month = int.Parse(s[2])
                        };
                    })
                    .OrderByDescending(e => e.duration)
                    .LastOrDefault();

                foreach (var a in File.ReadLines("Source/file.txt", Encoding.Default))
                    Console.WriteLine($"Items: {a}");

                Console.WriteLine();

                Console.WriteLine($"Min Duration: {minDuration}");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File not found, {e.FileName},\n{e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Console.ReadLine();
        }

        // Найти элемент последовательности с максимальной продолжительностью занятий
        // Вывести эту продолжительность, а также соответствующий ей год и номер месяца
        // Если имеется несколько элементов с минимальной продолжительностью, то вывести
        // c самой поздней дате
        static void SolveLinqObj2()
        {
            try
            {
                var maxDuration = File.ReadLines("Source/file.txt", Encoding.Default)
                    .Select(e =>
                    {
                        String[] s = e.Split(' ');
                        return new
                        {
                            duration = int.Parse(s[3]),
                            year = int.Parse(s[1]),
                            month = int.Parse(s[2])
                        };
                    })
                    .OrderBy(e => e.duration)
                    .ThenBy(e => e.year)
                    .ThenBy(e => e.month)
                    .Last();

                foreach (var a in File.ReadLines("Source/file.txt", Encoding.Default))
                    Console.WriteLine($"Items: {a}");

                Console.WriteLine();

                Console.WriteLine($"Max Duration: {maxDuration}");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File not found, {e.FileName},\n{e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        static void ResolveLinqObj55()
        {
            try
            {
                var students = File.ReadLines("Source/file1.txt", Encoding.Default)
                    .Select(e =>
                    {
                        String[] s = e.Split(' ');
                        return new
                        {
                            LastName = s[3],
                            Initial = s[4],
                            NumberOfSchool = int.Parse(s[5]),
                            Subject_1 = int.Parse(s[0]),
                            Subject_2 = int.Parse(s[1]),
                            Subject_3 = int.Parse(s[2])
                        };
                    })
                    .Where(e => (e.Subject_1 & e.Subject_2 & e.Subject_3) >= 50)
                    .Select(e => e)
                    .OrderBy(e => e.LastName)
                    .ThenBy(e => e.Initial);
                        
                

                foreach (var a in File.ReadLines("Source/file1.txt", Encoding.Default))
                    Console.WriteLine($"Items: {a}");

                //Console.WriteLine(students);

                foreach(var b in students)
                    Console.WriteLine($"Items: {students}");

                Console.WriteLine();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File not found, {e.FileName},\n{e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            Console.ReadLine();
        }
    }
    
    /// <summary>
    /// Содержит сведения об учащихся, таких как результаты ЕГЭ по математике, русскому языку и
    /// информатике, фамилия, инициалы и номер школы учащегося   
    /// </summary>
    class PersonInfo
    {
        // Баллы ЕГЭ, состоит из 3 отметок
        public byte[] Point { get; set; }
        // Фамилия
        public string LastName { get; set; }
        // Инициалы
        public string Initial { get; set; }
        // Номер школы
        public int NumberOfSchool { get; set; }

        public PersonInfo() { }
        public PersonInfo(byte[] point, string lastName, string initial, int numberSchool)
        {
            Point = point;
            LastName = lastName;
            Initial = initial;
            NumberOfSchool = numberSchool;
        }
    }
}
