using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class JoinTransaction : Transaction
    {
        public int TaxiNum;
        public int RankId;
        public JoinTransaction(DateTime transactionDatetime, int taxiNum, int rankId) : base("Join", transactionDatetime)
        {
            TaxiNum = taxiNum;
            RankId = rankId;
        }
        public override string ToString()
        {
            string dateStr = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return string.Format("{0} Join      - Taxi {1} in rank {2}", dateStr, TaxiNum, RankId);
        }
    }
}
