using System;
using System.Data;

namespace AulaLTP6.Infra.Infra
{
    public interface IDB : IDisposable
    {
        IDbConnection GetCon();
    }
}
