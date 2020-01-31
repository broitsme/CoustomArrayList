using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListNS
{
    class Class2
    {
        public static void Main()
        {
            CoustomArrayList list = new CoustomArrayList();
            Console.WriteLine(list.Add(1));
            Console.WriteLine(list.Add(2));
            Console.WriteLine(list.Add(3));
            Console.WriteLine(list.Add(2));
            Console.WriteLine(list.Add(2));
            Console.WriteLine(list.Add(10));
            Console.WriteLine(list.Search(15)+" "+list.GetSize());

            foreach(int val in list){
                Console.WriteLine(val);
            }
            Console.WriteLine(list.Add(30));
            Console.WriteLine(list.Add(20));
            Console.WriteLine(list.Add(25));
            foreach (int val in list)
            {
                Console.WriteLine(val);
            }
            Console.ReadLine();
        }
    }
}
