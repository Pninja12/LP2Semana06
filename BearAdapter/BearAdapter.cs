using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearAdapter
{
    public class BearAdapter : IDog
    {
        private readonly IBear bear;
        private readonly Random random;

        public BearAdapter(IBear bear)
        {
            this.bear = bear;
            random = new Random();
        }

        public void Bark()
        {
            bear.Roar();
        }

        public void Fetch(object objectToFetch)
        {
            bear.GoTowards(objectToFetch);
            bear.LookAt(objectToFetch);
            bear.TryEat(objectToFetch);
            if(random.NextDouble() < 0.05)
            {
                bear.Hibernating = !bear.Hibernating;
            }
        }
    }
}