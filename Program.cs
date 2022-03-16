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
        /// <summary>
        /// Список всех сотрудников компании
        /// </summary>
        public static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
           
            Update();


            Console.ReadKey();
        }

        /// <summary>
        /// Вывод в консоль действий, оперирующих с данными сотрудников
        /// </summary>
        private static void OutputOfInformationAboutUserActions()
        {
            Console.WriteLine(@"**************************************************************************************");
            Console.WriteLine(@"**   Введите 1 - Вывод данных о сотруднике на экран по его ID                       **");
            Console.WriteLine(@"**   Введите 2 - Добавить информацию о новом сотруднике в файл                      **");
            Console.WriteLine(@"**   Введите 3 - Удалить информацию о сотруднике по его имени, фамилии и отчеству   **");
            Console.WriteLine(@"**   Введите клавишу Esc, если хотите покинуть приложение                           **");
            Console.WriteLine(@"**************************************************************************************");
        }

        /// <summary>
        ///Обновление файла. Запись, удаление, вывод информации о сотрудниках
        /// </summary>
        public static void Update()
        {
            char key;
            do
            {
                OutputOfInformationAboutUserActions();  //Вывод информационных значений для взаимодействия пользователя и приложения
                key = Console.ReadKey().KeyChar;        //Считываение символа с консоли
                
                if (char.IsLetter(key))                 //Проверка на правильность
                {
                    throw new ArgumentException($"Ошибка! Нельзя вводить символы кроме тех, которые предоставляют нужную функциональность.");
                }
                else
                {
                    Console.WriteLine();
                    switch (key)
                    {
                        case '1':
                            ClearingDataFromList();                                 //Очистка списка сотрудников
                            EnteringInformationIntoStringListToEmployeeList();      //Перевод информации о сотрудниках из файла в List
                            OutputInformationAboutEmployeeInConsole();              //Вывод информации о сотруднике по его ID
                                                                                    
                            break;

                        case '2':
                            EnteringEmployeeInformation();                          //Ввод информации о сотруднике
                            OutputOfEmployeesDataToFile();                          //Добавление в файл о сотруднике
                            ClearingDataFromList();                                 //Очистка списка


                            break;

                        case '3':
                            ClearingDataFromList();                                 //Очистка списка сотрудников
                            EnteringInformationIntoStringListToEmployeeList();      //Перевод информации о сотрудниках из файла в List
                            RemovingEmployeeFromList();                             //Удаление сотрудника по его имени, фамилии и отчеству из списка
                            UpdatingEmployeeListFile();                             //Перезапись из списка сотрудников List в файл

                            break;
                    }

                }
            } while (key != (char)ConsoleKey.Escape);

            Console.WriteLine("Всего доброго! По всем вопросам обращаться по почте:");
            Console.Write("savelij_plus2003 @gmail.com");
        }

        /// <summary>
        /// Запись информации о сотрудниках в список
        /// </summary>
        public static void EnteringEmployeeInformation()
        {
            bool dataIsCorrectly = false;   //Флаг проверки корректности введненных данных

            string answerUser = string.Empty;   //Ответ пользователя о правильности введенных данных

            Employee employee = new Employee(); //Создание нового объекта класса Employee

            do
            {
                Console.WriteLine();
                Console.WriteLine($"ID вашего сотрудника - {employee.SetIDValue()}");   //Вывод сгенерированного ID 
                Console.WriteLine();

                employee.DateTimeNote = DateTime.Now;
                Console.Write($"Время записи - {employee.DateTimeNote.ToString()}");    //Вывод даты и времени записи
                Console.WriteLine('\n');

                Console.Write("Введите имя вашего сотрудника - ");                      //Ввод имени сотрудника
                employee.FirstName = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Введите фамилию вашего сотрудника - ");                  //Ввод фамилии сотрудника
                employee.SecondName = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Введите отчество вашего сотрудника - ");                 //Ввод отчества сотрудника
                employee.ThirdName = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Введите возраст вашего сотрудника - ");                  //Ввод возраста сотрудника
                string age = Console.ReadLine();
                int Age = new int();
                if (int.TryParse(age, out Age) == true)                                 //Проверка на правильность введенного возраста
                {
                    employee.Age = Age;
                }
                else
                {
                    throw new ArgumentException($"Ошибка! Нельзя представить число в таком формате.");
                }
                Console.WriteLine();

                Console.Write("Введите дату рождения сотрудника - ");                   //Ввод даты рождения сотрудника
                string dateOfBitrh = Console.ReadLine();
                DateTime DateOfBirth;
                if (DateTime.TryParse(dateOfBitrh, out DateOfBirth))                    //Проверка на праильность введенной даты рождения
                {
                    employee.DateOfBirth = DateOfBirth;
                }
                else
                {
                    throw new ArgumentException($"Ошибка! Неправильно введена дата рождения сотрудника.");
                }
                Console.WriteLine();

                Console.Write("Введите место рождения сотрудника - ");                  //Ввод места рождения сотрудника
                employee.PlaceOfBirth = Console.ReadLine();
                Console.WriteLine();

                Console.WriteLine("Введите ДА, если вы уверены в правильности набора данных, иначе введите НЕТ и ввод данных начнется заново."); 
                Console.WriteLine();                                                                                                             

                answerUser = Console.ReadLine();
                if (answerUser == "ДА")                                                 //Проверка на првильность введнных пользователем данных 
                {
                    dataIsCorrectly = true;
                }

                else
                {
                    continue;
                }
            }
            while (dataIsCorrectly == false);

            employees.Add(employee);                                                   //В случае корректной информации добавление в список сотрудников типа Employee
                
        }
        /// <summary>
        /// Очистка данных из списка сотрудников после добавления
        /// </summary>
        private static void ClearingDataFromList()
        {
            employees.Clear();
        }


        /// <summary>
        /// Вывод информации о сотруднике из списка в файл, добавление в конец нового сотрудника
        /// </summary>
        private static void OutputOfEmployeesDataToFile()
        {
            using (StreamWriter streamWriter = new StreamWriter("EmployeeLog.txt", true, Encoding.Unicode))     //Создание потока StreamWriter для записи в файл
            {
                string note = string.Empty;                                     //Строка, куда будет идти запись информации

                foreach (var emp in employees)
                {   
                    string id = emp.ID.ToString();                              

                    string dateTimeNote = emp.DateTimeNote.ToString();

                    string firstName = emp.FirstName;

                    string secondName = emp.SecondName;

                    string thirdName = emp.ThirdName;

                    string age = emp.Age.ToString();

                    string dateOfBirth = emp.DateOfBirth.ToString("d");

                    string placeOfBirth = emp.PlaceOfBirth;

                    streamWriter.WriteLineAsync($"{id,10}   |   { dateTimeNote,10}  |   {firstName,-20}  |   {secondName,-20}   |" +    //Форматированная строка для 
                                                $"   {thirdName,-20}   |   {age,3}   |   {dateOfBirth,10}  |   {placeOfBirth,-30}");    //текстового файла

                }

            }
        }

        /// <summary>
        /// Удаление сотрудника из списка по имени, фамилии и отчеству и перезапись файла с учетом удаления сотрудника
        /// </summary>
        private static void RemovingEmployeeFromList()
        {
            bool isHaveEmployee = false;                                                //Флаг проверки наличия сотрудника в базе

            Console.WriteLine("Введите имя сотрудника:");
            string _firstName = Console.ReadLine();                                     //Ввод имени и проверка на корректность
            if (string.IsNullOrWhiteSpace(_firstName))
            {
                throw new ArgumentException($"Ошибка! Ввод некорректного имени.");
            }

            Console.WriteLine("Введите фамилию сотрудника:");
            string _secondName = Console.ReadLine();                                    //Ввод фамилии и проверка на коррекстность
            if (string.IsNullOrWhiteSpace(_secondName))
            {
                throw new ArgumentException($"Ошибка! Ввод некорректной фамилии.");
            }

            Console.WriteLine("Введите отчество сотрудника:");                          //Ввод отчества и проверка на корректность
            string _thirdName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(_thirdName))
            {
                throw new ArgumentException($"Ошибка! Ввод некорректного отчества.");
            }

            foreach (var emp in employees)
            {
                if ((emp.FirstName == _firstName) && (emp.SecondName == _secondName) && (emp.ThirdName == _thirdName) && isHaveEmployee == false)//Если Ф.И.О. совпадают со списком
                {                                                                                                                                //удаляем из списка
                    employees.Remove(emp);
                    isHaveEmployee = true;
                    break;
                }
      
            }
            if(isHaveEmployee == false)
            {
                Console.WriteLine($"К сожалению, но сотрудника {_firstName} {_secondName} {_thirdName} нет в базе." +
                                  $" Попробуйте ввести данные заново, выбрав соответствующий пункт в меню");
            }

            Console.WriteLine($"Обновление списка сотрудников");

        }

        /// <summary>
        /// Обновление записи в файл из списка
        /// </summary>
        private static void UpdatingEmployeeListFile()
        {
            using (StreamWriter streamWriter = new StreamWriter("EmployeeLog.txt", false, Encoding.Unicode))    //Создание потока StreamWriter для перезаписи файла
            {
                string note = string.Empty;

                foreach (var emp in employees)
                {
                    string id = emp.ID.ToString();

                    string dateTimeNote = emp.DateTimeNote.ToString();

                    string firstName = emp.FirstName;

                    string secondName = emp.SecondName;

                    string thirdName = emp.ThirdName;

                    string age = emp.Age.ToString();

                    string dateOfBirth = emp.DateOfBirth.ToString("d");

                    string placeOfBirth = emp.PlaceOfBirth;

                    streamWriter.WriteLineAsync($"{id,10}   |   { dateTimeNote,10}  |   {firstName,-20}  |   {secondName,-20}   |" +
                                                $"   {thirdName,-20}   |   {age,3}   |   {dateOfBirth,10}  |   {placeOfBirth,-30}");

                }

            }

        }

        /// <summary>
        /// Дополнительный метод для перевода из файла в строковый список информации о каждом сотруднике
        /// </summary>
        /// <returns>Список строк из каждого сотрудника</returns>
        private static List<string> ReadingEmployeeInformationFromfile()
        {
            List<string> linesInFile = new List<string>();  //Список строк для всех сотрудников, который извлекаем из текстового файла построчно

            

            using (StreamReader streamReader = new StreamReader(@"D:\source\Проекты SkillBox\PracticTask6\bin\Debug\EmployeeLog.txt", Encoding.Unicode))
            {
                string informationAboutEmolouyee = string.Empty;

                while (!streamReader.EndOfStream)
                {
                    informationAboutEmolouyee = streamReader.ReadLine();
                    linesInFile.Add(informationAboutEmolouyee);
                }
            }

            return linesInFile;

        }

        /// <summary>
        /// Перевод из строкового списка информации о сотруднике в список Employee типа
        /// </summary>
        private static void EnteringInformationIntoStringListToEmployeeList()
        {
            List<string> informationAboutEmployees = ReadingEmployeeInformationFromfile();  //Список для информации о каждом сотруднике
              
            foreach(var item in informationAboutEmployees)
            {
                string[] infAboutEmployee = item.Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries); //Запись информации о конкретном сотруднике, удаляя пробелы
                                                                                                                        //и знаки разделения '|'
                int id = Convert.ToInt32(infAboutEmployee[0]);  //Конвертирование ID

                DateTime dateTimeNote = DateTime.Parse(infAboutEmployee[1]);    //Конвертирование даты записи

                TimeSpan timeNote = TimeSpan.Parse(infAboutEmployee[2]);        //Ковертирование времени записи

                string firstName = infAboutEmployee[3];                         //Перевод имени 

                string secondName = infAboutEmployee[4];                        //Перевод фамилии

                string thirdName = infAboutEmployee[5];                         //Перевод отчества

                int age = Convert.ToInt32(infAboutEmployee[6]);                 //Перевод возраста

                DateTime dateOfBirth = DateTime.Parse(infAboutEmployee[7]);     //Перевод даты рождения

                string placeOfBirth = string.Empty;                             //Перевод места рождения

                for (int i = 8; i < infAboutEmployee.Length; i++)
                {
                    placeOfBirth += infAboutEmployee[i];
                }

                

                employees.Add(new Employee(id, dateTimeNote + timeNote, age, firstName, secondName, thirdName, dateOfBirth, placeOfBirth)); //Добавление в список информации
                                                                                                                                            //о конкретном сотруднике
            }


        }

        /// <summary>
        /// Вывод информации о сотруднике по его ID в консоль
        /// </summary>
        private static void OutputInformationAboutEmployeeInConsole()
        {
            bool isFinding = false; //Флаг нахождения сотрудника в базе


            Console.WriteLine("Введите ID сотрудника, чтобы узнать информацию о нем:");
            string inputID = Console.ReadLine();                                            //Считывание ID пользователя
            int id;
            if(int.TryParse(inputID, out int ID))                                           //Проверка на правильность введенных данных
            {
                id = ID;
            }
            else
            {
                throw new ArgumentException("Ошибка! Невозможно преобразовать данное значение в строку.");
            }
           
            
            for (int i = 0; i < employees.Count; i++)                                       //Поиск введенного ID в списке Employee сотрудников
            {

                if(employees[i].ID == id && isFinding == false)
                {
                    Console.WriteLine($"ID - {employees[i].ID}");
                    Console.WriteLine($"Дата  и время записи информации - {employees[i].DateTimeNote}");
                    Console.WriteLine($"Имя - {employees[i].FirstName}");
                    Console.WriteLine($"Фамилия - {employees[i].SecondName}");
                    Console.WriteLine($"Отчество - {employees[i].ThirdName}");
                    Console.WriteLine($"Возраст - {employees[i].Age}");
                    Console.WriteLine($"Дата рождения - {employees[i].DateOfBirth.ToString("d")}");
                    Console.WriteLine($"Место рождения - {employees[i].PlaceOfBirth}");
                    Console.WriteLine();
                    isFinding = true;
                }
            }
            if (isFinding == false)                                                         //Проверка на нахождение сотрудника в базе по его ID
            {
                Console.WriteLine("К сожалению, такого сотрудника нет в базе.");
            }

            
        }


    }
}

