using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareableComparerEquatable
{
    class Run
    {
        public static void Main(String[] args)
        {

            Aera a1 = new Aera("Kndhiwali",101);
            Aera a2 = new Aera("Antophil", 101);
            Console.WriteLine(a1.Equals(a2));
            Car c1 = new Car("tata", 500);
            Car c2 = new Car("ferrari", 400);
            Car c3 = new Car("ford", 450);
            Car c4 = new Car("tesla", 400);

            Car[] CarArr = { c2, c1, c3, c4 };


            for (int i = 0; i < CarArr.Length; i++)
            {
                Console.Write(CarArr[i].Name + " " + CarArr[i].MaxSpeed + "   ");
            }
            Console.WriteLine();
            Array.Sort(CarArr);
            for (int i = 0; i < CarArr.Length; i++)
            {
                Console.Write(CarArr[i].Name + " " + CarArr[i].MaxSpeed + "   ");
            }
            Console.WriteLine();

            CarComparer carComparer = new CarComparer();
            carComparer.compareField = CarComparer.SortBy.Name;
            Array.Sort(CarArr, carComparer);
            for (int i = 0; i < CarArr.Length; i++)
            {
                Console.Write(CarArr[i].Name + " " + CarArr[i].MaxSpeed + "   ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
    class Car : IComparable
    {
        public Car(String Name, int MaxSpeed)
        {
            this.Name = Name;
            this.MaxSpeed = MaxSpeed;
        }
        public String Name;
        public int MaxSpeed;
        /// <summary>
        /// Caompares car based on the speed
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> >0 if this.MaxSpeed > obj.MaxSpeed, =0 if this.MaxSpeed = obj.MaxSpeed, < 0 if this.MaxSpeed < obj.MaxSpeed </returns>
        public int CompareTo(object obj)
        {
          
            if (!(obj is Car))
            {
                throw new ArgumentException("Need a car object");
            }
            Console.WriteLine(this.MaxSpeed.CompareTo(((Car)obj).MaxSpeed));
            Car GivenCar = obj as Car;
            return this.MaxSpeed.CompareTo(GivenCar.MaxSpeed);
        }
    }
    class CarComparer : IComparer<Car>
    {
        public enum SortBy
        {
            Name,
            MaxSpeed
        }
        public SortBy compareField;
        public int Compare(Car x, Car y)
        {
            switch (compareField)
            {
                case SortBy.Name:
                    return x.Name.CompareTo(y.Name);
                case SortBy.MaxSpeed:
                    return x.MaxSpeed.CompareTo(x.MaxSpeed);
                
            }
            return x.Name.CompareTo(y.Name);
        }
    }

    internal class Aera : IEquatable<Aera>
    {
        String Name;
        int Pincode;
        public Aera(String Name, int Pincode)
        {
            this.Name = Name;
            this.Pincode = Pincode;
        }
        public bool Equals(Aera other)
        {
            if(this.Pincode == other.Pincode)
            {
                return true;
            }
            return false;
        }
    }
}
