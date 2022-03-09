using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticTask6
{
    class Employee
    {
        private int id;
        /// <summary>
        /// ID сотрудника компании
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime dateTimeNote;
        /// <summary>
        /// Дата и время записи сотрудника
        /// </summary>
        public DateTime DateTimeNote
        {
            get { return dateTimeNote; }
            set { dateTimeNote = value; }
        }

        private int age;
        /// <summary>
        /// Возраст сотрудника
        /// </summary>
        public int Age
        {
            get { return age; }
            set
            {
                if(age > 120 && age < 18)
                {
                    throw new ArgumentException($"Ошибка! Возраст {nameof(age)} не может быть меньше 18 лет и больше 120 лет.");
                }
                else
                {
                    age = value;
                }
            }
        }

        private string firstName;
        /// <summary>
        /// Имя сотрудника
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if(String.IsNullOrEmpty(value) || value.Length >= 30)
                {
                    throw new ArgumentException($"Ошибка! Поле имени {nameof(firstName)} сотрудника не может быть пустым или содержать в себе больше 30 символов.");
                }
                else if(IsAllLetters(value) == false)
                {
                    throw new ArgumentException($"Ошибка! Поле имени {nameof(firstName)} сотрудника может содержать только буквы.");
                }
                else
                {
                    firstName = value;
                }
            }
        }

        private string secondName;

        /// <summary>
        /// Фамилия сотрудника
        /// </summary>
        public string SecondName
        {
            get { return secondName; }
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length >= 30)
                {
                    throw new ArgumentException($"Ошибка! Поле фамилии {nameof(secondName)} сотрудника не может быть пустым или содержать в себе больше 30 символов.");
                }
                else if (IsAllLetters(value) == false)
                {
                    throw new ArgumentException($"Ошибка! Поле фамилии {nameof(secondName)} сотрудника может содержать только буквы.");
                }
                else
                {
                    secondName = value;
                }

            }
        }

        private string thirdName;

        /// <summary>
        /// Отчество сотрудника
        /// </summary>
        public string ThirdName
        {
            get { return thirdName; }
            set
            {
                if (String.IsNullOrEmpty(value) || value.Length >= 30)
                {
                    throw new ArgumentException($"Ошибка! Поле отчества {nameof(thirdName)} сотрудника не может быть пустым или содержать в себе больше 30 символов.");
                }
                else if (IsAllLetters(value) == false)
                {
                    throw new ArgumentException($"Ошибка! Поле отчества {nameof(thirdName)} сотрудника может содержать только буквы.");
                }
                else
                {
                    thirdName = value;
                }

            }
        }

        private DateTime dateOfBirth;
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }

        }

        private string placeOfBirth;
        /// <summary>
        /// Место рождения сотрудника
        /// </summary>
        public string PlaceOfBirth
        {
            get { return placeOfBirth; }
            set { placeOfBirth = value; }
        }





        public static bool IsAllLetters(string str)
        {
            foreach(char symbol in str)
            {
                if (!char.IsLetter(symbol))
                {
                    return false;
                }
                
            }
            return true;
        }


        public int SetIDValue()
        {
            Random rand = new Random();
            this.ID = rand.Next(1, 10000);
            return this.ID;
        }

    }

    
}
