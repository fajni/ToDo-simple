using RepositoryLayer;
using Shared.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer
{
    public class ObligationBusiness
    {
        public ObligationRepository obligationRepository;

        public ObligationBusiness()
        {
            this.obligationRepository = new ObligationRepository();
        }

        public List<Obligation> GetAllObligations()
        {
            return this.obligationRepository.GetAllObligations();
        }

        public List<Obligation> GetObligationsByUserId(int user_id)
        {
            List<Obligation> obligations = new List<Obligation>();

            foreach(var obligation in obligationRepository.GetAllObligations())
            {
                if(obligation.GetSetUserId == user_id)
                {
                    obligations.Add(obligation);
                }
            }

            if(obligations.Count == 0)
            {
                Console.WriteLine("No Such Obligations for user with "+user_id+" id!");
            }

            return obligations;
        }
    }
}
