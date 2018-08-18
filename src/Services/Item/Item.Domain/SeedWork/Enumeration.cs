using System;


namespace Item.Domain.SeedWork
{
    /// <summary>
    /// Enumeration base class
    /// Implement: In object Enumeration
    /// </summary>
    public abstract class Enumeration: IComparable
    {
        public string Name { get; private set; }

        public int Id { get; private set; }

        protected Enumeration() { }

        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;

        public int CompareTo(object other)
        {
            return Id.CompareTo(((Enumeration)other).Id);
        }
    }
}
