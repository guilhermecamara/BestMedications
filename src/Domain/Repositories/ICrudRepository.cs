using System;
using System.Collections.Generic;

namespace Domain.Repositories
{
    public interface ICrudRepository<Entity>
    {
        IEnumerable<Entity> GetAll();

        Entity Get(Guid id);

        Entity Create(Entity comment);

        Entity Update(Entity comment);

        bool Delete(Guid id);
    }
}