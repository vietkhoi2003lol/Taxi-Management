using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class UserUI
    {
        public RankManager rankMgr;
        public TaxiManager taxiMgr;
        public TransactionManager transactionMgr;
        public UserUI(RankManager rkMgr, TaxiManager txMgr, TransactionManager trMgr)
        {
            rankMgr = rkMgr;
            taxiMgr = txMgr;
            transactionMgr = trMgr;
        }
        public List<string> TaxiJoinsRank(int taxiNum, int rankId)
        {
            List<string> taxiJoinsRank = new List<string>();
            //If the t.Number does not exist, create new one
            // If t.Number exist, return t
            Taxi t = taxiMgr.CreateTaxi(taxiNum);
            //Add t with t.Number = taxiNum t into a specific rank defined by rankId
            if(rankMgr.AddTaxiToRank(t, rankId) == true)
            {
                rankMgr.AddTaxiToRank(t, rankId);
                taxiJoinsRank.Add($"Taxi {taxiNum} has joined rank {rankId}.");
                transactionMgr.RecordJoin(taxiNum, rankId);
                return taxiJoinsRank;
            }
            //If Taxi t is invalid or rank is invalid, output message and don't add anything
            else
            {
                taxiJoinsRank.Add($"Taxi {taxiNum} has not joined rank {rankId}.");
                return taxiJoinsRank;
            }

        }
        public List<string> TaxiLeavesRank(int rankId, string destination, double agreedPrice)
        {
            List<string> taxiLeavesRank = new List<string>();
            Taxi t = rankMgr.FrontTaxiInRankTakesFare(rankId, destination, agreedPrice);
            if (t != null)
            {
                transactionMgr.RecordLeave(rankId, t);
                t.AddFare(destination, agreedPrice);
                taxiLeavesRank.Add($"Taxi {t.Number} has left rank {rankId} to take a fare to {destination} for £{agreedPrice}.");
            } else
            {
                taxiLeavesRank.Add($"Taxi has not left rank {rankId}.");
            }
            return taxiLeavesRank;
        }
        public List<string> TaxiDropsFare(int taxiNum, bool pricePaid)
        {
            List<string> taxiDropsFare = new List<string>();
            Taxi t = taxiMgr.FindTaxi(taxiNum);
            t.DropFare(pricePaid);
            if(t.Location != Taxi.IN_RANK) {
                if (pricePaid)
                {
                    taxiDropsFare.Add($"Taxi {taxiNum} has dropped its fare and the price was paid.");
                    transactionMgr.RecordDrop(taxiNum, pricePaid);
                }
                else
                {
                    taxiDropsFare.Add($"Taxi {taxiNum} has dropped its fare and the price was not paid.");
                    transactionMgr.RecordDrop(taxiNum, pricePaid);
                }
            }
            else
            {
                taxiDropsFare.Add($"Taxi {taxiNum} has not dropped its fare.");
            }
            return taxiDropsFare;
        }
        public List<string> ViewTaxiLocations()
        {
            List<string> viewTaxiLocations = new List<string>();
            viewTaxiLocations.Add("Taxi locations");
            viewTaxiLocations.Add("==============");
            //Get all existing taxis
            SortedDictionary<int, Taxi> allTaxis = taxiMgr.GetAllTaxis();
            if(allTaxis.Count == 0)
            {
                viewTaxiLocations.Add("No taxis");
            } else
            {
                foreach (Taxi val in allTaxis.Values)
                {
                    if(val.Location == Taxi.IN_RANK)
                    {
                        viewTaxiLocations.Add($"Taxi {val.Number} is in rank {val.Rank.Id}");
                    }
                    else
                    {
                        if (val.Destination != "")
                        {
                            viewTaxiLocations.Add($"Taxi {val.Number} is on the road to {val.Destination}");
                        }
                        else
                        {
                            viewTaxiLocations.Add($"Taxi {val.Number} is on the road");
                        }
                    }
                   
                }
            }
            return viewTaxiLocations;
        }
        public List<string> ViewFinancialReport()
        {
            double total = 0;
            List<string> viewFinancialReport = new List<string>();
            viewFinancialReport.Add("Financial report");
            viewFinancialReport.Add("================");
            SortedDictionary<int, Taxi> allTaxis = taxiMgr.GetAllTaxis();
            if(allTaxis.Count > 0)
            {
                foreach (Taxi val in allTaxis.Values)
                {
                    viewFinancialReport.Add($"Taxi {val.Number}      {val.TotalMoneyPaid:0.00}");
                    total += val.TotalMoneyPaid;
                }
                viewFinancialReport.Add("           ======");
                viewFinancialReport.Add($"Total:       {total:0.00}");
                viewFinancialReport.Add("           ======");
            }
            else
            {
                viewFinancialReport.Add("No taxis, so no money taken");
            }

            
            return viewFinancialReport;
        }
        public List<string> ViewTransactionLog()
        {
            List<string> viewTransactionLog = new List<string>();
            List<Transaction> allTransactions = transactionMgr.GetAllTransactions();
            viewTransactionLog.Add("Transaction report");
            viewTransactionLog.Add("==================");
          
            if(allTransactions.Count > 0)
            {  
                foreach (Transaction val in allTransactions)
                {
                    viewTransactionLog.Add(val.ToString());
                }
            }
            else
            {
                viewTransactionLog.Add("No transactions");
            }
            return viewTransactionLog;
        }

    }


}
