using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class DropTransaction : Transaction
    {
        public int TaxiNum;
        public bool PriceWasPaid;
        public DropTransaction(DateTime transactionDatetime, int taxiNum, bool priceWasPaid) : base("Drop fare", transactionDatetime)
        {
            TaxiNum = taxiNum;
            PriceWasPaid = priceWasPaid;
        }
        public override string ToString()
        {
            string dateStr = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            if (PriceWasPaid == true)
            {
                return string.Format("{0} Drop fare - Taxi {1}, price was paid", dateStr, TaxiNum);
            }
            else
            {
                return string.Format("{0} Drop fare - Taxi {1}, price was not paid", dateStr, TaxiNum);
            }
       
        }
    }
}
