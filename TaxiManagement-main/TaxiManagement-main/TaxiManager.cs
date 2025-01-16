using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiManagementAssignment
{
    public class TaxiManager
    {
        public SortedDictionary<int, Taxi> taxis = new SortedDictionary<int, Taxi>();
        public SortedDictionary<int, Taxi> GetAllTaxis()
        {
            //This method return a empty dictionary so tm.GetAllTaxis.Count == 0
            //Pass test011
            return taxis;
        }
        public Taxi FindTaxi(int taxiNum)
        {
            //Pass test02
            if (taxis.Count == 0)
            {
                return null;
            }
            //past test03
            else if (taxis.ContainsKey(taxiNum))
            {
                Taxi t = taxis[taxiNum];
                return t;
            }
            else
            {
                return null;
            }
        }

        public Taxi CreateTaxi(int taxiNum)
        {
            if (FindTaxi(taxiNum) != null)
            {
                return FindTaxi(taxiNum);
            }
            else
            {
                Taxi t = new Taxi(taxiNum);
                taxis.Add(taxiNum, t);
                return t;
            }
        }
    }
}
