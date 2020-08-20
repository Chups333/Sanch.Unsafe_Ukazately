using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.Unsafe_Code.Ukazately
{
    class Program
    {
        static void Main(string[] args)
        {
            //указатели для передачи ссылки памяти
            //надо в свойствах проекта разрешить выполняться небезопасному коду
            unsafe //область небезопастного кода (для значимых переменных ). Ссылочные и так можно
            {
                int i = 30;
                int* address = &i; //указатель адресса переменной i в памяти
                Console.WriteLine(*address); //вывод указателя(получили значение)
                Console.WriteLine((long)address); //получили адресс той ячейки памяти (его номер)(адресс первой ячейки, но она может занимать еще ячейки)

                int a = 5;
                int b = 7;

                

                Calc(a, &b);
                Console.WriteLine(a);
                Console.WriteLine(b);

                //переход от одного участка памяти к другому
                int* address2 = address + 4;//интовая переменная 4 байта( 1 байт это одна ячейка памяти) 
                *address2 = 777;
                Console.WriteLine(*address2); //показало 777
                //unsafe - небезопастная работа с памятью

                //указетель на указатель
                int** adr= &address;
                Console.WriteLine((long)adr);
                Console.WriteLine((long)*adr);//разименновать
                Console.WriteLine(**adr);//разименновать полностью


                Console.ReadKey();
            }

        }
        static unsafe void Calc(int i, int* j) //небезопасный метод
        {
            i = 500;//значения не поменяли (значимое )
            *j = 700; //ссылка поменялась( небезопасный код )
        }

        static void Calc(int i, ref int j) //безопасный код (эквевалентно вверхнему методу)
        {

        }
    }
}
