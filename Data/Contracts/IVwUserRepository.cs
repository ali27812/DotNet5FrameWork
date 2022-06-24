using Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contracts
{
    public interface IVwUserRepository : IVwRepository<vwUser>
    {
        void GetStoreProce();
    }
}
