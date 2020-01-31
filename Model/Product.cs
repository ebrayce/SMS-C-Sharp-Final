using System;

namespace SMS.Model
{
    public class Product
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }

        public virtual int InStock { get; set; }

        public virtual int MinStock { get; set; }

        public virtual double Price { get; set; }

        public virtual bool BelowMinStock { get; set; }



    }
}
