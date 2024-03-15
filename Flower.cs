using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantLib
{
    public class Flower : Plant
    {
        static string[] smellArr = { "Отсутствует", "Терпкий", "Сладкий", "Легкий"};

        protected string smell;
        public string Smell
        {
            get => smell;
            set
            {
                smell = value != null ? value : "Не указано";
            }
        }
        public Flower() : base()
        {
            Smell = "Отсутствует";
        }
        public Flower(string name, string color, int idNumber, string smell) : base(name, color, idNumber)
        {
            Smell = smell;
        }

        public override string ToString()
        {
            return base.ToString() + $", Запах: {Smell}";
        }

        //Функция с ручным вводом

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите запах:");
            Smell = Console.ReadLine();
        }

        //Заполнение запаха рандомной строкой
        public override void RandomInit()
        {
            Random rnd = new Random();
            base.RandomInit();
            Smell = smellArr[rnd.Next(smellArr.Length)];
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Flower) return false;
            return ((Flower)obj).Color == this.Color && 
                ((Flower)obj).Name == this.Name && 
                ((Flower)obj).Smell == this.Smell;
        }

    }
}
