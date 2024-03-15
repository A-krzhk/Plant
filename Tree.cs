using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlantLib
{
    public class Tree : Plant
    {


        Random rnd = new Random();
        protected double height;
        public int number;
        public double Height
        {
            get => height;
            set
            {
                if (value <= 0)
                {
                    this.height = 1;
                }
                else
                {
                    this.height = value;
                }
            }
        }
        public Plant GetBase
        {
            get => new Plant(Name, Color, rnd.Next(1, 1000));//возвращает объект базового класса
        }

        public Tree() : base()
        {
            Height = 0;
        }
        public Tree(string name, string color, int idNumber, double height) : base(name, color, idNumber)
        {
            Height = height;
        }

        public override string ToString()
        {
            return base.ToString() + $", высота: {Height}";
        }

        //Функция с ручным вводом

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите высоту дерева (если ввод будет некорректным, по умолчанию присвоится 0):");
            try
            {
                Height = double.Parse(Console.ReadLine());
            }
            catch
            {
                Height = 0;
            }
        }

        //Заполнение высоты рандомным числом до 50, с округлением до 2 знаков
        public override void RandomInit()
        {
            base.RandomInit();
            Random random = new Random();
            Height = Math.Round(random.NextDouble() * 50, 2);
        }

        public int CompareTo([AllowNull] Tree other)
        {
            return Name.CompareTo(other.Name);
        }

        //Метод для сравнения объектов в тестах 
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public override object Clone()
        {
            return new Tree(Name, Color, id.Number, Height);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Tree) return false;
            return ((Tree)obj).Color == this.Color && 
                ((Tree)obj).Name == this.Name && 
                ((Tree)obj).Height == this.Height;
        }
    }
}
