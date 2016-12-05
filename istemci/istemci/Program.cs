using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace istemci
{
    class Program
    {
        static void Main(string[] args)
        {

            try 
            
            {
                while (true)
                {
                    TcpClient tc = new TcpClient();
                    //tc.Connect("10.37.35.65", 8000);
                    tc.Connect(IPAddress.Loopback, 8000);
                    
                    String str = Console.ReadLine();
                    NetworkStream stm = tc.GetStream();
                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] gon = asen.GetBytes(str);
                    //Console.WriteLine("Transmitting");

                    stm.Write(gon, 0, gon.Length); // veri gönder
                    byte[] okunan = new byte[100];
                    int ok = stm.Read(okunan, 0, 100);

                    for (int i = 0; i < ok; i++)
                        Console.Write(Convert.ToChar(okunan[i]));

                    tc.Close();
                }
            
            }
            catch (Exception e)
            {
                Console.WriteLine("hata oldu" + e.StackTrace);
            
            }

            Console.Read();





        }
    }
}
