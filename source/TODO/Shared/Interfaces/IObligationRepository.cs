using Shared.Models;
using System.Collections.Generic;

namespace Shared.Interfaces
{
    public interface IObligationRepository
    {
        List<Obligation> GetAllObligations();
        int InsertObligation(Obligation obligation);
    }
}
