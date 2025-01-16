using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class RankManager
    {
        public Dictionary<int, Rank> ranks = new Dictionary<int, Rank>();
        public RankManager()
        {
            Rank r1 = new Rank(1, 5);
            Rank r2 = new Rank(2, 2);
            Rank r3 = new Rank(3, 4);
            ranks.Add(1, r1);
            ranks.Add(2, r2);
            ranks.Add(3, r3);
        }
        
        public Rank FindRank(int rankId)
        {
            if(rankId >= 0 && rankId <= 3)
            {
                Rank r = ranks[rankId];
                return r;
            }
            else
            {
                return null;
            }
        }

        public bool AddTaxiToRank(Taxi t, int rankId)
        {
            //ranks.ContainsValue check if taxi already exists in a rank
            //ranks.ContainsKey check validity of rankId
            //t.Destination check whether Taxi t is empty or not. If t has a destination, then t can not be added to rank
            if (!ranks.ContainsKey(rankId) || ranks.ContainsValue(t.Rank) ||  t.Destination != "")
            {
                return false;
            }
            else {
                return FindRank(rankId).AddTaxi(t);
            }
            
        }

        public Taxi FrontTaxiInRankTakesFare(int rankId, string destination, double agreedPrice)
        {
            Rank r = FindRank(rankId);
            if (r == null)
            {
                return null;
            }
            else
            {
                return r.FrontTaxiTakesFare(destination, agreedPrice);
            }
            
        }

    }
}
