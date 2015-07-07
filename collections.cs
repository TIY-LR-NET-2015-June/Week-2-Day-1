using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Day1Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {   

            //FiFO, first in first out
            Stack<int> numbers = new Stack<int>();
            numbers.Push(5);
            numbers.Push(9);
            numbers.Push(100);
            numbers.Push(3);

            var number = numbers.Pop();  //returns 3
            var number2 = numbers.Pop(); //returns 100

            //LIFO last in, first out
            Queue<int> numberqueue = new Queue<int>();
            numberqueue.Enqueue(5);
            numberqueue.Enqueue(9);
            numberqueue.Enqueue(100);
            numberqueue.Enqueue(3);

            number = numberqueue.Dequeue(); //returns 5;
            number2 = numberqueue.Dequeue(); // returns 9

            HashSet<int> ourSet = new HashSet<int>();
            ourSet.Add(5);
            ourSet.Add(9);
            ourSet.Add(100);
            ourSet.Add(53);
            var result = ourSet.Add(5); // returns false and doesn't add element to hashset


            Dictionary<string, Car> dict = new Dictionary<string, Car>();
            dict.Add("Honda", new Car());
            dict.Add("Civic", new Car());


            //Demonstrating overridding Car.Equals() function
            // only compares cars on make, model, year...doesn't care about owner
            Car car1 = new Car();
            car1.Make = "Honda";
            car1.Owner = "Daniel";

            Car car2 = new Car();
            car2.Make = "Honda";
            car2.Owner = "Scott";

      
            if (car1.Equals(car2) )
            {
                Console.WriteLine("Same cars! Even though Different Owners");
            }
            else
            {
                Console.WriteLine("Different cars!");
            }

            Console.WriteLine("{0}", car1);

            //Demonstrating having GetPeoples return SIMPLEST possible interface that is need to work. List<> implements IEnumerable and
            //also ICollection. If you only are going to loop, use IEnumerable, if you need to count them use collection. If you need to add remove items 
            //use IList

            var peoples = GetPeoples();
            peoples.Add("Test Person");

            foreach (var p in peoples)
            {
                Console.WriteLine("Name: {0}", p);
            }
            
            Console.WriteLine("Number of Peoples: {0}", peoples.Count);

            Console.ReadLine();


        }

        private static IList GetPeoples()
        {
            return new []{ "Daniel", "Brandon", "Scott", "Jason", "Aaron","David", "Mike"};
        }
    }

    public class Car : Object
    {
        public Car()
        {
            Model = "";
            Year = 0;
        }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Owner { get; set; }

        //We can make 2 cars equal to each other when comparing them if make, model, year is same. 
        public override bool Equals(object obj)
        {
            if (!(obj is Car))
                return false;

            Car car2 = (Car)obj;

            if (this.Make == car2.Make && this.Model == car2.Model && this.Year == car2.Year)
                return true;

            return false;


        }

        //Pretty Print when someone tries to explicit call Car.ToString() or if Console.WriteLine needs a nice view.
        public override string ToString()
        {
            return string.Format("This car is a {0} and is owned by {1}", this.Make, this.Owner);
        }

        //Generate a unique id for this object instance.
        public override int GetHashCode()
        {
            return Make.GetHashCode() + Model.GetHashCode() + Year.GetHashCode();
        }

    }
}
