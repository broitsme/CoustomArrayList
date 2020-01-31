using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace EnumeratorsAndEnumrables
{
    class DisplayDifference
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            for(int i = 0; i < 20; i++)
            {
                list.Add(i);
            }
            IEnumerable<int> Lenum = (IEnumerable<int>)list;
            IEnumerator<int> Lenumrator = list.GetEnumerator();
           
            printTill10(Lenum);
            printTill10(Lenumrator);
            Console.ReadLine();
        }
        /********************************IEnumrator*******************************/
        static void printTill10(IEnumerator<int> Lenumrator)
        {
            while (Lenumrator.MoveNext())
            {
                
                Console.WriteLine("printed inside printTill10(IEnumerator) : " + Lenumrator.Current.ToString());
                if (Convert.ToInt32(Lenumrator.Current) == 10)
                {
                    printAfter10(Lenumrator);
                }
            }
        }
        static void printAfter10(IEnumerator<int> Lenumrator)
        {
            while (Lenumrator.MoveNext())
            {
                Console.WriteLine("printed inside printAfter10(IEnumerator) :" + Lenumrator.Current.ToString());
            }
        }
        /********************************IEnumrator*******************************/

        /***********************IEnumrable*****************************************/
        static void printTill10(IEnumerable<int> Lenum)
        {
           foreach (int val in Lenum)
            {

                Console.WriteLine("printed inside printTill10(IEnumerable) : " + val);
                if (val == 10)
                {
                    printAfter10(Lenum);
                }
            }
        }
        static void printAfter10(IEnumerable<int> Lenum)
        {
            foreach (int val in Lenum)
            { 
                Console.WriteLine("printed inside printTill10(IEnumerable) : "+val);
     
            }
        }
        /***********************IEnumrable*****************************************/

    }
}
