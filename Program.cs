using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PracticTask6
{
    class Program
    {
        static void Main(string[] args)
        {
            //OutputOfInformationAboutUserActions();
            List<Employee> listOfEmployee = new List<Employee>();
            

            var employee = EnteringEmployeeInformation();
            Console.WriteLine($"employee.FirstName - {employee.FirstName}");
            Console.WriteLine($"employee.SecondName - {employee.SecondName}");
            Console.WriteLine(employee.ID);

            //Console.WriteLine($"employee.ThirdName - {employee.ThirdName}");
            //Console.WriteLine($"employee.Age - {employee.Age}");



            //Employee employee = new Employee();

            //Console.WriteLine("Введите имя сотрудника:");
            //employee.FirstName = Console.ReadLine();

            //Console.WriteLine("Введите фамилию сотрудника:");
            //employee.SecondName = Console.ReadLine();

            //Console.WriteLine("Введите отчество сотрудника");
            //employee.ThirdName = Console.ReadLine();

            //Console.WriteLine("Введите возраст сотрудника:");
            //employee.Age = Convert.ToInt32(Console.ReadLine());
            Console.ReadKey();
        }
        
        private static void OutputOfInformationAboutUserActions()
        {
            Console.WriteLine(@"**************************************************************");
            Console.WriteLine(@"* Введите 1 - Вывод данных о сотрудниках на экран            *");
            Console.WriteLine(@"* Введите 2 - Добавить информацию о новом сотруднике в файл  *");
            Console.WriteLine(@"* Введите 3 - Удалить информацию о сотруднике по его ID      *");
            Console.WriteLine(@"**************************************************************");
        }
        public static void Update()
        {
            ConsoleKeyInfo key;
            do
            {
                OutputOfInformationAboutUserActions();
                key = Console.ReadKey();
                switch (key)
                {
                    case '2':


                }




            }
            while (key.Key != ConsoleKey.Escape);
        }
        public static void CreatingFile()
        {

        }
        public static Employee EnteringEmployeeInformation()
        {
            using (StreamWriter stramWriter = new StreamWriter("EmployeeLog.txt", true, Encoding.Unicode))
            {
                bool dataIsCorrectly = false;

                string answerUser = string.Empty;

                Employee employee = new Employee();

                string note;
                do
                {
                    note = string.Empty;

                    note += employee.SetIDValue();
                    Console.WriteLine($"ID вашего сотрудника - {note}");
                    Console.WriteLine();
                    note += "#";

                    employee.DateTimeNote = DateTime.Now;
                    Console.Write($"Время записи - {employee.DateTimeNote.ToString()}");
                    Console.WriteLine();
                    note += employee.DateTimeNote.ToString();
                    note += "#";

                    Console.Write("Введите имя вашего сотрудника - ");
                    employee.FirstName = Console.ReadLine();
                    Console.WriteLine();
                    note += employee.FirstName;
                    note += "#";

                    Console.Write("Введите фамилию вашего сотрудника - ");
                    employee.SecondName = Console.ReadLine();
                    Console.WriteLine();
                    note += employee.SecondName;
                    note += "#";

                    Console.Write("Введите отчество вашего сотрудника - ");
                    employee.ThirdName = Console.ReadLine();
                    Console.WriteLine();
                    note += employee.ThirdName;
                    note += "#";

                    Console.Write("Введите дату рождения сотрудника - ");
                    string dateOfBitrh = Console.ReadLine();
                    Console.WriteLine();
                    note += dateOfBitrh;
                    note += "#";

                    Console.Write("Введите мество рожения сотрудника - ");
                    string placeOfBirth = Console.ReadLine();
                    Console.WriteLine();
                    note += placeOfBirth;

                    Console.WriteLine("Введите ДА, если вы уверены в правильности набора данных, иначе введите НЕТ и ввод данных начнется заново.");
                    Console.WriteLine();

                    answerUser = Console.ReadLine();
                    if (answerUser == "ДА")
                    {
                        dataIsCorrectly = true;
                    }
                    else if (!String.IsNullOrEmpty(answerUser))
                    {
                        throw new ArgumentException($"Ошибка! Ответ не может быть пустой строкой!");
                    }
                    else
                    {
                        continue;
                    }
                }
                while (dataIsCorrectly == false);


            }
        }

        /// <summary>
        /// Предоставляет строковый набор данных каждого сотрудника
        /// </summary>
        /// <returns>Список строк о каждом сотруднике, записанных в файл</returns>
        private List<string> EmployeeDataPresentation()
        {
            List<string> data = new List<string>();
            
            string firstName, secondName, thirdName;

            string answerUser = string.Empty;
            bool isCorrectData = false;

            while (isCorrectData == false)
            {
                Console.Write("Ввведите имя сотрудника - ");
                firstName = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Введите фамилию сотрудника - ");
                secondName = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Введите отчество сотрудника - ");
                thirdName = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Проверьте правильность введенных данных. Введите ДА, если все верно, или НЕТ, если где-то были допущены ошибки:");
                answerUser = Console.ReadLine();
                Console.WriteLine();

                if(answerUser == "ДА")
                {
                    isCorrectData = true;
                }
                else
                {
                    continue;
                }
            }
            

            using(StreamReader streamReader = new StreamReader(@"D:\source\Проекты SkillBox\PracticTask6\bin\Debug\EmployeeLog.txt", Encoding.Unicode))
            {
                string line;

                while((line = streamReader.ReadLine()) != null)
                {
                    data.Add(line);
                }
            }
            return data;
        }

        private void OutputDataAboutAllEmployees(List<string> dataAboutAllEmployees)
        {
            List<Employee> listOfemployees = new List<Employee>();

            foreach(var line in dataAboutAllEmployees)
            {
                foreach(var employee in line)
                {

                }


            }
        }
    }
}
