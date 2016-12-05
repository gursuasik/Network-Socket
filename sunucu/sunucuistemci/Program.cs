using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;

using System.Text;

namespace sunucuistemci
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
               //IPAddress ip= IPAddress.Parse("localhost");
                while (true)
                {
                    TcpListener tcpl = new TcpListener(8000);
                    tcpl.Start();
                    Socket s = tcpl.AcceptSocket();

                    byte[] veri = new byte[100];
                    int okunan = s.Receive(veri);
                    for (int i = 0; i < okunan; i++)
                        Console.Write(Convert.ToChar(veri[i]));

                    Console.WriteLine();
                    ASCIIEncoding a = new ASCIIEncoding();
                    s.Send(a.GetBytes("Appeared...\n"));
                    s.Close();
                    tcpl.Stop();
                }
                


            }
            catch (Exception e)
            {

                Console.WriteLine("hata oldu :"+e.StackTrace);
            
            
            }

           




        }
    }
}
