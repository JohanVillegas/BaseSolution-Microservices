using System;
using System.Collections.Generic;
using System.Text;

namespace Item.Domain.SeedWork
{
    /// <summary>
    /// Entity base class, where you can place code that can be used the same way by any domain entity.
    /// Implement: In object of type entity
    /// </summary>
    public abstract class Entity
    {
        Guid _Id;
        public virtual Guid Id
        {
            get => _Id;
            protected set => _Id = value;
        }

    }
}
