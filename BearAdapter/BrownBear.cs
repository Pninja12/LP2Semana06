using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearAdapter
{
    public class BrownBear: IBear
    {
        private readonly Random random;
        public bool Hibernating { get; set; }

        public BrownBear()
        {
            random = new Random();
            Hibernating = random.NextDouble() < 0.3;
        }

        public void Roar()
        {
            if(Hibernating)
            {
                Console.WriteLine("Zzz");
            }
            else
            {
                Console.WriteLine("Rauwr");
            }
            
        }
        public void LookAt(object objectToLookAt)
        {
            if(Hibernating)
            {
                Console.WriteLine("Bro is sleeping");
            }
            else
            {
                Console.WriteLine($"Bear looks at {objectToLookAt}");
            }
        }
        public void GoTowards(object objectToWalkTowards)
        {
            if(Hibernating)
            {
                Console.WriteLine("Bro is sleeping");
            }
            else
            {
                Console.WriteLine("Bear walks towards " + objectToWalkTowards);
            }
        }
        public bool TryEat(object objectToEat)
        {
            if(Hibernating)
            {
                Console.WriteLine("Too tired to eat");
                return false;
            }
            else
            {
                if(random.NextDouble() < 0.5)
                {   
                    Console.WriteLine("Eating " + objectToEat);
                    return true;
                }
                else
                {
                    Console.WriteLine("Womp Womp");
                    return false;
                }
                    
            }
        }

        
    }
}