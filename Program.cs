using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Лр6_З1
{
    class Telephone
    {
        public event Action Event1;//подія, в якій телефон дзвонить
        public void Call()//робить дзвінок
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Дзвонить  телефон");
            Event1.Invoke();
        }
    }
    class Subscriber //клас який викликає подію Event2 або Event3
    {
        public event Action Event2;//подія коли слухавку не зняли
        public event Action Event3;//подія коли слухавку зняли
        public void Event1()
        {
            Random o = new Random();
            bool variant = o.Next(2)== 0;

            if (variant)// виникає, якщо слухавку зняли.
            {
                Event3.Invoke();
            }
            else// виникає, якщо слухавку не зняли.
            {
                Event2.Invoke();
            }
        }
    }

    class Answerphone //виникає коли слухавку не зняли
    {
        public void Event2()
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Не знiмаю слухавку. Автовiдповiдач: введiть повiдомлення:");//пишемо повідомнення 
            Console.ForegroundColor = ConsoleColor.White;
            string message = Console.ReadLine();//тут знаходиться залишене повідомлення 
            Console.WriteLine("Повiдомлення збережено: " + message);//виводимо залишене повідомлення на екран
        }
    }
    class Talk //вииконується коли слухавку зняли
    {
        public void Event3()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Знiмаю слухавку. Алло?");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //робимо посилання
            Telephone telephone = new Telephone();
            Subscriber subscriber = new Subscriber();
            Answerphone answerphone = new Answerphone();
            Talk talk = new Talk();
            //з'єднуємо відповідні частини 
            telephone.Event1 += subscriber.Event1;
            subscriber.Event2 += answerphone.Event2;
            subscriber.Event3 += talk.Event3;
            //робимо цикл для 5ти дзвінків
            for (int i = 0; i < 5; i++)
            {
                telephone.Call();
            }
        }
    }

}


