

using System;
using System.Diagnostics.CodeAnalysis;

namespace PlantLib
{
    public class IdNumber
    {
        public int number;
        public IdNumber(int number)
        {
            this.number = number;
        }
        public int Number
        {
            get => number;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                number = value;
            }
        }
        public override string ToString()
        {
            return number.ToString();
        }
    }

    //Базовый класс - растение
    public class Plant: IInit, IComparable, ICloneable
    {

        static string[] NamesArr = { "Белладонна", "Голубика", "Абелия", "Барбарис", "Инжир", "Кактус", "Каладиум", "Каланта", "Магнолия", "Магония", "Майоран", "Мак", "Малина", "Мальва" };
        static string[] ColorArr = { "Зеленый", "Красный", "Желтый", "Белый", "Синий", "Черный", "Оранжевый"};
        

        //Использую private, так как подразуемвается изменение через свойства 
        string name;
        string color;
        public IdNumber id { get; set; }

        //Свойства
        public string Name
        {
            get => name;
            set
            {
                name = value != null ? value : "Не указано";
            }
        }

        public string Color
        {
            get => color;
            set
            {
                color = value != null ? value : "Не указано";
            }
        }

        //Конструктор без параметров
        public Plant()
        {
            Name = "Не указано";
            Color = "Не указано";
            id = new IdNumber(1);
        }

        //Конструктор с параметрами
        public Plant(string name, string color, int number)
        {
            Name = name;
            Color = color;
            Random rnd = new Random();
            id = new IdNumber(rnd.Next(1, 10000));

        }

        //Метод для вывода объектов класса
        public override string ToString()
        {
            return $"Название растения: {Name}, цвет растения: {Color}";
        }
        //Невиртуальный вывод 
        public void Show ()
        {
            Console.WriteLine($"Название: {Name}, цвет: :{Color}");
        }
        //Заполнение объекта вручную

        public virtual void Init()
        {
            Random rnd = new Random();
            Console.WriteLine("Введите название растения:");
            Name = Console.ReadLine();

            Console.WriteLine("Введите цвет растения:");
            Color = Console.ReadLine();

            id.number = rnd.Next(1, 1000);

        }

        //Заполнение объекта через дсч. Вставляются рандомные буквы, но фиксированной длины
        public virtual void RandomInit()
        {
            Random rnd = new Random();
            Name = NamesArr[rnd.Next(NamesArr.Length)];
            Color = ColorArr[rnd.Next(ColorArr.Length)];
            id.number = rnd.Next(1, 1000);
        }

        //Метод для сравнения объектов в тестах 
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Plant) return false;
            return ((Plant)obj).Color == this.Color && 
                ((Plant)obj).Name == this.Name;
        }

        //Метод для сравнения объектов в тестах 
        public override int GetHashCode()
        {
            return HashCode.Combine(Color, Name);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return -1;
            if (obj is not Plant) return -1;
            Plant p = obj as Plant;
            return String.Compare(this.Name, p.Name);
        }



        public virtual object Clone()
        {
            return new Plant(Name, Color, id.Number);
        }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}
