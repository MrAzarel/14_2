using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _14_2
{
    class ProductionLine
    {
        int A = 0;
        int B = 0;
        int C = 0;
        int D = 0;
        int E = 0;
        public void LineWithBuf()
        {
            ThreadPool.SetMaxThreads(5, 5);
            while (true)
            {
                ThreadPool.QueueUserWorkItem(AProd);
                ThreadPool.QueueUserWorkItem(BProd);
                ThreadPool.QueueUserWorkItem(CProd);
                ThreadPool.QueueUserWorkItem(DProd);
                ThreadPool.QueueUserWorkItem(EProd);
            }          
        }

        void AProd(object obj)
        {
            Thread.Sleep(800);
            A++;
            Console.WriteLine($"A: {0}" + A);
        }

        void BProd(object obj)
        {
            Thread.Sleep(1500);
            B++;
            Console.WriteLine($"B: {0}" + B);
        }

        void CProd(object obj)
        {
            Thread.Sleep(3300);
            C++;
            Console.WriteLine($"C: {0}" + C);
        }

        void DProd(object obj)
        {
            if (A > 30 && B > 30)
            {
                Thread.Sleep(2500);
                D++;
                A--;
                B--;
                Console.WriteLine($"D: {0}" + D);
            }          
        }

        void EProd(object obj)
        {
            if (C > 30 && D > 10)
            {
                Thread.Sleep(4500);
                E++;
                C--;
                D--;
                Console.WriteLine($"E: {0}" + E);
            }           
        }
    }

    class ProductionLine2
    {
        int A = 0;
        int B = 0;
        int C = 0;
        int D = 0;
        int E = 0;
        public void LineWithoutBuf()
        {
            ThreadPool.SetMaxThreads(5, 5);
            while (true)
            {
                ThreadPool.QueueUserWorkItem(AProd);
                ThreadPool.QueueUserWorkItem(BProd);
                ThreadPool.QueueUserWorkItem(CProd);
                ThreadPool.QueueUserWorkItem(DProd);
                ThreadPool.QueueUserWorkItem(EProd);
            }
        }

        void AProd(object obj)
        {
            Thread.Sleep(800);
            A++;
            Console.WriteLine($"A: {0}" + A);
        }

        void BProd(object obj)
        {
            Thread.Sleep(1500);
            B++;
            Console.WriteLine($"B: {0}" + B);
        }

        void CProd(object obj)
        {
            Thread.Sleep(3300);
            C++;
            Console.WriteLine($"C: {0}" + C);
        }

        void DProd(object obj)
        {
            if (A > 0 && B > 0)
            {
                Thread.Sleep(2500);
                D++;
                A--;
                B--;
                Console.WriteLine($"D: {0}" + D);
            }
        }

        void EProd(object obj)
        {
            if (C > 0 && D > 0)
            {
                Thread.Sleep(4500);
                E++;
                C--;
                B--;
                Console.WriteLine($"E: {0}" + E);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductionLine productionLine = new ProductionLine();
            ProductionLine2 productionLine2= new ProductionLine2();
            productionLine.LineWithBuf();
            //productionLine2.LineWithoutBuf();
        }
    }
}
