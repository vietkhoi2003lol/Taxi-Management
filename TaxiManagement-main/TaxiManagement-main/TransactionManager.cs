using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
   public class TransactionManager
   {
        public List<Transaction> transactions = new List<Transaction>();

        public List<Transaction> GetAllTransactions()
        {
            return transactions;
        }
        public void RecordJoin(int taxiNum, int rankId)
        {
            Transaction tm = new JoinTransaction(DateTime.Now, taxiNum, rankId);
            transactions.Add(tm);
        }
        public void RecordLeave(int rankId, Taxi t)
        {
            Transaction tm = new LeaveTransaction(DateTime.Now, rankId, t);
            transactions.Add(tm);
        }
        public void RecordDrop(int taxiNum, bool pricePaid)
        {
            Transaction tm = new DropTransaction(DateTime.Now, taxiNum, pricePaid);
            transactions.Add(tm);
        }
    }
}
