using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class Taxi
    {
        public const string IN_RANK = "in rank";
        public const string ON_ROAD = "on the road";
        public int Number;
        public double CurrentFare;
        public string Destination = "";
        public string Location = ON_ROAD;
        public double TotalMoneyPaid = 0;
        public Taxi(int num)
        {
            Number = num;

        }
        private Rank rank;
        public Rank Rank
        {
            get
            {
                return rank;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Rank cannot be null");
                }
                if (Destination != "")
                {
                    throw new Exception("Cannot join rank if fare has not been dropped");
                }
                else
                {
                    rank = value;
                    Location = IN_RANK;
                }
            }
        }
        public void AddFare(string destination, double agreedPrice) 
        {
            Location = ON_ROAD;
            Destination = destination;
            CurrentFare = agreedPrice;
            rank = null;
        }

        public void DropFare(bool priceWasPaid) 
        {
            if(priceWasPaid)
            {
                Destination = "";
                TotalMoneyPaid += CurrentFare;
                CurrentFare = 0;
            }
        }


    }
}
