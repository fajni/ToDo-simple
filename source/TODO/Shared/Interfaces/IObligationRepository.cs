using Shared.Models;
using System.Collections.Generic;

namespace Shared.Interfaces
{
    public interface IObligationRepository
    {
        List<Obligation> GetAllObligations();
        int InsertObligation(Obligation obligation);
        int DeleteObligation(int id);
        int UpdateObligation(Obligation obligation);
    }
}
