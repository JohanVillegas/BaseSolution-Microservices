using System;
using System.Collections.Generic;
using System.Text;

namespace Item.Domain.SeedWork.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
