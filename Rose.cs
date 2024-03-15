using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantLib
{
    public class Rose : Flower
    {
        protected bool thorns;
        public bool Thorns
        {
            get => thorns;
            set
            {
                try
                {
                    thorns = value;
                } catch
                {
                    thorns = false;
                }
            }
        }
        public Rose() : base()
        {
            Thorns = false;
        }
        public Rose(string name, string color, int idNumber, string smell, bool thorns) : base(name, color, idNumber, smell)
        {
            Thorns = thorns;
        }

        public override string ToString()
        {
            return base.ToString() + $", Шипы: {(Thorns == true ? "Есть" : "Нет")}";
        }

        // Функция с ручным вводом

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите наличие шипов (да или нет):");
            string buf = Console.ReadLine();
            Thorns = buf == "да" ? true : false;
        }

        // Заполнение шипов рандомным значением
        public override void RandomInit()
        {
            base.RandomInit();
            Random random = new Random();
            int temp = random.Next(0, 2);
            Thorns = temp == 1 ? true : false;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Rose) return false;
            return ((Rose)obj).Color == this.Color && 
                ((Rose)obj).Name == this.Name && 
                ((Rose)obj).Smell == this.Smell && 
                ((Rose)obj).Thorns == this.Thorns;
        }
    }
}
