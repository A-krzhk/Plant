using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlantLib
{
    public class Runner : IInit
    {
        double speed;
        double distance;

        double time;
        static int count;

        public double Speed
        {
            get => speed;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Скорость не можеть быть меньше нуля");
                }
                else
                {
                    speed = value;
                }
            }
        }

        public double Distance
        {
            get => distance;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Дистанция не может быть меньше нуля");
                }
                else
                {
                    distance = value;
                }
            }
        }

        public double Time
        {
            get => time;
            set
            {
                if (value < 0)
                {
                    throw new Exception("Время не может быть меньше нуля");
                }
                else
                {
                    time = value;
                }
            }
        }

        //Конструктор с параметром
        public Runner(double speed, double distance)
        {
            Speed = speed;
            Distance = distance;
            count++;
        }

        //Конструктор без параметра
        public Runner()
        {
            Speed = 10;
            Distance = 15;
            count++;
        }

        //Конструктор копирования
        public Runner(Runner r)
        {
            Speed = r.speed;
            Distance = r.distance;
            count++;
        }

        //Метод класса
        public void KmPerHour(string runnerName)
        {
            Time = Distance / Speed;
            Console.WriteLine($"Время преодоления дистанции в часах для {runnerName} составляет: {Math.Round(Time, 2)}");
        }

        //Статическая функция
        public static void KmPerHour(Runner r)
        {
            r.Time = r.Distance / r.Speed;
            Console.WriteLine($"Время преодоления дистанции в часах составляет: {Math.Round(r.Time, 2)}");

        }

        //Подсчет кол-ва объектов
        public static int Counter => count;


        //********************************************************************************
        //2 часть задания

        //Перегруженные унарные операции

        //Увеличение дистанции на 0.1
        public static Runner operator ++(Runner r)
        {
            r.Distance += 0.1;
            return r;
        }

        //Уменьшение скорости на 0.05
        public static Runner operator --(Runner r)
        {
            r.Speed -= 0.05;
            return r;
        }

        //Операции приведения типа

        //На сколько нужно увеличить скорость, чтобы сократить время на 5%
        public static explicit operator double(Runner r)
        {
            return Math.Abs(Math.Round(1.0 / 19 * r.Speed, 2));
        }

        //Сколько времени нужно на преодоление дистанции в формате ЧЧ:ММ:СС
        public static implicit operator string(Runner r)
        {
            double timeSec = (r.Distance / r.Speed) * 3600;

            return $"{TimeSpan.FromSeconds(timeSec).Hours} ч. " +
                $"{TimeSpan.FromSeconds(timeSec).Minutes} мин. " +
                $"{TimeSpan.FromSeconds(timeSec).Seconds} сек. ";
        }

        //Бинарные операции

        //Расстояние, на котором бегуны встретятся
        public static double operator -(Runner r1, Runner r2)
        {
            double temp = 15 * r1.Speed / (r1.Speed + r2.Speed);
            return temp > 0 && r1.Distance >= 15 && r2.Distance >= 15 ? temp : -1;
        }

        //Создание нового объекта бегуна, чья скорость увеличена на указанное число
        public static Runner operator ^(Runner r1, double sp)
        {
            Runner temp = new Runner(r1);
            temp.Speed += sp;

            return temp;
        }
        public static Runner operator ^(double sp, Runner r1)
        {
            Runner temp = new Runner(r1);
            temp.Speed += sp;
            return temp;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Runner) return false;
            return ((Runner)obj).Speed == this.Speed && ((Runner)obj).Distance == this.Distance && ((Runner)obj).Time == this.Time;
        }

        //Перегруженная функция для сравнения значений объектов
        public static bool operator >(Runner r1, Runner r2)
        {
            if (r1.Distance > r2.Distance) return true;
            else if (r1.Distance == r2.Distance)
            {
                if (r1.Time > r2.Time)
                {
                    return true;
                }
                return false;
            }
            else return false;
        }

        public static bool operator <(Runner r1, Runner r2)
        {
            if (r1.Distance < r2.Distance) return true;
            else if (r1.Distance == r2.Distance)
            {
                if (r1.Time < r2.Time)
                {
                    return true;
                }
                return false;
            }
            else return false;
        }

        //Метод ручного заполнения
        public virtual void Init()
        {
            Console.WriteLine("Введите скорость");
            try
            {
                Speed = double.Parse(Console.ReadLine());
            }
            catch
            {
                Speed = 0;
            }

            Console.WriteLine("Введите дистанцию");
            try
            {
                Distance = double.Parse(Console.ReadLine());
            }
            catch
            {
                Distance = 0;
            }
        }

        //Метод рандомного заполнения
        public virtual void RandomInit()
        {
            Random rnd = new Random();
            Speed = Math.Round(rnd.NextDouble() * 30, 2);
            Distance = Math.Round(rnd.NextDouble() * 100, 2);
        }

        //Метод для вывода объектов класса
        public override string ToString()
        {
            return $"Скорость бегуна: {Speed}, дистанция бегуна: {Distance}";
        }

    }
}
