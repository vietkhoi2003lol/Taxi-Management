using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class LeaveTransaction : Transaction
    {
        public int TaxiNum;
        public int RankId;
        public double AgreedPrice;
        public string Destination;
        public LeaveTransaction(DateTime transactionDatetime, int rankId, Taxi t) : base("Leave", transactionDatetime)
        {
            TaxiNum = t.Number;
            AgreedPrice = t.CurrentFare;
            Destination = t.Destination;
            RankId = rankId;
        }
        public override string ToString()
        {
            string dateStr = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            return string.Format("{0} Leave     - Taxi {1} from rank {2} to {3} for £{4}", dateStr, TaxiNum, RankId, Destination, AgreedPrice);
        }
    }
}
