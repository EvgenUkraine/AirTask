using System;
using System.Collections.Generic;
using System.Text;

namespace AirTek.Database.Interfaces.Base {
    public interface IRepositoryService<T> {
        IEnumerable<T> GetAll();
    }
}
