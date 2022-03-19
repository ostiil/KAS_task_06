using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAS_Task_06
{
    class Program
    {
        public static int choice = 0;public static int n = 1; 
        public static string[] Fio = new string[n]; public static string[] post = new string[n];
        
        static void Main()
        {
            Console.Write("\t Меню: \n 1. Добавить досье \n 2. Вывести все досье \n 3. Удалить досье \n" +
                " 4. Поиск по фамилии \n 5. Выход \n Выберите пункт меню: ");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка! Введите цифру.");
                Main();
            }
            

            switch (choice)
            {
                case 1:
                    Add(ref Fio, ref post, ref n);
                    break;
                case 2:
                    Show(ref Fio, ref post);
                    break;
                case 3:
                    Remove(ref Fio, ref post);
                    break;
                case 4:
                    Find(ref Fio, ref post);
                    break;
                case 5:
                    Exit();
                    break;
                default:
                    Console.WriteLine("Такого пункта меню нет."); Main();
                    break;
            }
            Console.ReadKey();
        }


         public static void Add(ref string[] Fio,ref string[] post,ref int n)
        {
            n++; 
            Console.WriteLine("Добавление досье: ");
            Console.Write("Введите фамилию:");
            string surname =Console.ReadLine();
            Console.Write("Введите имя:");
            string name = Console.ReadLine();
            Console.Write("Введите отчество:");
            string Secondname = Console.ReadLine();
            
            Console.Write("Введите должность: ");
            var dolz = Console.ReadLine();
            for (int i = 0; i < Fio.Length; i++)
            {
                Fio[0] = "";
            }
            string str = $"{surname} {name} {Secondname}";
            Array.Resize(ref Fio, Fio.Length + 1);
            Fio[Fio.Length - 1] = str;
            string str2 = $"- {dolz}";
            Array.Resize(ref post, post.Length + 1);
            post[post.Length - 1] = str2;
            Console.WriteLine("Досье добавлено.");
            Console.WriteLine("Нажмите enter, чтобы вернуться к меню. ");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Main();
            }
        }
         public static void Show(ref string[] Fio, ref string[] post)
        {
            Console.Write($"Досье: \n ");
            for (int i =1; i<Fio.Length; i++)
            {
                Console.WriteLine($"{i}. {string.Join(" ", Fio[i])} {string.Join(" ", post[i])}");
            }    
            Console.WriteLine("Нажмите enter, чтобы вернуться к меню.");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Main();
            }
        }
        public static void Remove(ref string[] Fio, ref string[] post)
        {
            Console.Write("Введите номер досье, которое хотите удалить: ");
            var num = Convert.ToInt32(Console.ReadLine());
            
            if ((Fio.Length < num )|| num < 0)
            {
                Console.WriteLine("Такого досье нет.");
                Remove(ref Fio, ref post);
            }
            var a = Fio.ToList();
            a.RemoveAt(num);
            Fio = a.ToArray();
            Console.WriteLine($"{string.Join("\n", Fio)}");
            Console.WriteLine("Успешно удалено.");
            Console.WriteLine("Нажмите enter, чтобы вернуться к меню.");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Main();
            }
        }
        public static void Find(ref string[] Fio, ref string[] post)
        {
            Console.Write("Введите фамилию, которую хотите найти: ");
            string value = Console.ReadLine();
            string[] element = new string[3]; string surname = "";  bool check = false; string a = "";
            for (int i = 1; i < Fio.Length; i++)
            {
                element = Fio[i].Split(' ');
                surname = element[0];

                if (value == surname)
                {
                    Console.WriteLine($"Досье: \n {Fio[i]} {post[i]}");
                    check = true;

                }

            }

            if (check)
            {

            }
            else
            {
                Console.WriteLine("Такого досье нет.");
            }


            Console.WriteLine("enter");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Main();
            }
        }
        public static void Exit()
        {
            Environment.Exit(0);
        }
    }

}
