using RESProjekat.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RESProjekat
{
    class Program
    {
        public static Object obj = new Object();
        static void Main(string[] args)
        {
            Logger l = new Logger();
            Podatak p = new Podatak();
            Writer w = new Writer();
            ReplicatorSender rs = new ReplicatorSender();
            ReplicatorReceiver rr = new ReplicatorReceiver();
            ReaderCACD rCACD = new ReaderCACD();
            ReaderCCCL rCCCL = new ReaderCCCL();
            ReaderCCCS rCCCS = new ReaderCCCS();
            ReaderCSCM rCSCM = new ReaderCSCM();
            Thread t1;

            t1 = new Thread(() =>
            {
                while (true)
                {
                    lock (obj)
                    {
                        Array values = Enum.GetValues(typeof(Code.CodeSpisak));
                        Random random = new Random();
                        Code.CodeSpisak randomCode = (Code.CodeSpisak)values.GetValue(random.Next(values.Length));
                        p.Code = randomCode;
                        p.Value = random.Next(0, 1000);
                        w.P = p;
                        w.Prosledi(rs, l);
                        rs.Prosledi(rr, l);
                        rr.Razvrstaj(l);
                        rr.Prosledi(rCACD, rCCCL, rCSCM, rCCCS, l);
                        rCACD.UpisiUBazu(l);
                        rCCCL.Deadband(l);
                        rCCCL.UpisiUBazu(l);
                        rCSCM.Deadband(l);
                        rCSCM.UpisiUBazu(l);
                        rCCCS.Deadband(l);
                        rCCCS.UpisiUBazu(l);
                        Thread.Sleep(2000);
                    }
                }
            });
            t1.IsBackground = true;
            t1.Start();
            //t2 = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        rs.Prosledi(rr, l);
            //    }
            //});
            //t3 = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        rr.Razvrstaj(l);
            //    }
            //});
            //t4 = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        rr.Prosledi(rCACD, rCCCL, rCSCM, rCCCS, l);
            //    }
            //});
            //t5 = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        rCACD.UpisiUBazu(l);
            //    }
            //});
            //t6 = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        rCCCL.UpisiUBazu(l);
            //    }
            //});
            //t7 = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        rCSCM.UpisiUBazu(l);
            //    }
            //});
            //t8 = new Thread(() =>
            //{
            //    while (true)
            //    {
            //        rCCCS.UpisiUBazu(l);
            //    }
            //});
            //t1.Start();
            //t2.Start();
            //t3.Start();
            //t4.Start();
            //t5.Start();
            //t6.Start();
            //t7.Start();
            //t8.Start();
            while (true)
            {
                Console.WriteLine("1. Unesite vrednost");
                Console.WriteLine("2. Iscitaj iz baze");
                Console.WriteLine("3. Exit");
                string str = Console.ReadLine();
                if (str == "1")
                {

                    lock (obj)
                    {
                        Console.WriteLine("Unesite vrednost:");
                        string a = Console.ReadLine();

                        p.Value = Convert.ToInt32(a);

                        Console.WriteLine("Izaberi code: \n");
                        Console.WriteLine("1. CODE_ANALOG\n");
                        Console.WriteLine("2. CODE_DIGITAL\n");
                        Console.WriteLine("3. CODE_CUSTOM\n");
                        Console.WriteLine("4. CODE_LIMITSET\n");
                        Console.WriteLine("5. CODE_SINGLENOE\n");
                        Console.WriteLine("6. CODE_MULTIPLENODE\n");
                        Console.WriteLine("7. CODE_CONSUMER\n");
                        Console.WriteLine("8. CODE_SOURCE\n");
                        Console.WriteLine("Za izlaz pritisni x");
                        a = Console.ReadLine();

                        switch (a)
                        {
                            case "1":
                                p.Code = Code.CodeSpisak.CODE_ANALOG;
                                break;
                            case "2":
                                p.Code = Code.CodeSpisak.CODE_DIGITAL;
                                break;
                            case "3":
                                p.Code = Code.CodeSpisak.CODE_CUSTOM;
                                break;
                            case "4":
                                p.Code = Code.CodeSpisak.CODE_LIMITSET;
                                break;
                            case "5":
                                p.Code = Code.CodeSpisak.CODE_SINGLENOE;
                                break;
                            case "6":
                                p.Code = Code.CodeSpisak.CODE_MULTIPLENODE;
                                break;
                            case "7":
                                p.Code = Code.CodeSpisak.CODE_CONSUMER;
                                break;
                            case "8":
                                p.Code = Code.CodeSpisak.CODE_SOURCE;
                                break;
                            case "x":
                                return;
                            default:
                                break;
                        }
                        w.P = p;
                        w.Prosledi(rs, l);
                        rs.Prosledi(rr, l);
                        rr.Razvrstaj(l);
                        rr.Prosledi(rCACD, rCCCL, rCSCM, rCCCS, l);
                        rCACD.UpisiUBazu(l);
                        rCCCL.Deadband(l);
                        rCCCL.UpisiUBazu(l);
                        rCSCM.Deadband(l);
                        rCSCM.UpisiUBazu(l);
                        rCCCS.Deadband(l);
                        rCCCS.UpisiUBazu(l);
                    }

                }
                else if (str == "2")
                {
                    lock (obj)
                    {
                        rCACD.IscitajIzBaze(l);
                        rCCCL.IscitajIzBaze(l);
                        rCSCM.IscitajIzBaze(l);
                        rCCCS.IscitajIzBaze(l);
                    }
                }
                else if (str == "3")
                {
                    lock (obj)
                    {
                        return;
                    }
                }
            }
        }
    }
}