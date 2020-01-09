using BL.Repositories;
using System;

namespace BL.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        TestRepository testRepository { get; }
        UserRepository UserRepository { get; }
       



        int Save();

    }
}
