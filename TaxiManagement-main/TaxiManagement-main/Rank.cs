using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class Rank
    {
        public int Id;
        public int NumberOfTaxiSpaces;
        public List<Taxi> taxiSpace = new List<Taxi>();
        
        public Rank(int rankId, int numberOfTaxiSpaces) 
        {
            Id = rankId;
            NumberOfTaxiSpaces = numberOfTaxiSpaces;
        }

        public bool AddTaxi(Taxi t)
        {
            if (NumberOfTaxiSpaces > 0)
            {
                t.Rank = this;
                taxiSpace.Add(t);
                NumberOfTaxiSpaces--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Taxi FrontTaxiTakesFare(string destination, double agreedPrice)
        {
            if (taxiSpace.Count > 0)
            {
                Taxi t = taxiSpace[0];
                t.Destination = destination;
                t.CurrentFare = agreedPrice;
                taxiSpace.RemoveAt(0);
                NumberOfTaxiSpaces++;
                return t;
                
            }
            else
            {
                return null;
            }
        }


    }
}
