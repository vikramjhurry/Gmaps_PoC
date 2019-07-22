using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App446MasterDetail.Models;

namespace App446MasterDetail.Services
{
    public class MockTripDataStore : IDataStore<TransportationTrips>
    {
        List<TransportationTrips> items;

        public MockTripDataStore()
        {
            items = new List<TransportationTrips>();
            var mockItems = new List<TransportationTrips>
            {
                new TransportationTrips { Vehicle = "3344 JN 12", StartTime=new DateTime(10,10,10,9,30,0), Tolerance=new TimeSpan(0,10,0), DestinationLocation=23.122M, StartLocation=56.111M, SeatCount=4 },
                new TransportationTrips { Vehicle = "445 SP 09", StartTime=new DateTime(10,10,10,9,30,0), Tolerance=new TimeSpan(0,10,0), DestinationLocation=23.122M, StartLocation=56.111M, SeatCount=4 },
                new TransportationTrips { Vehicle = "3344 FB 12", StartTime=new DateTime(10,10,10,9,30,0), Tolerance=new TimeSpan(0,10,0), DestinationLocation=23.122M, StartLocation=56.111M, SeatCount=4 },
                new TransportationTrips { Vehicle = "2222 JN 20", StartTime=new DateTime(10,10,10,9,30,0), Tolerance=new TimeSpan(0,10,0), DestinationLocation=23.122M, StartLocation=56.111M, SeatCount=4 },
                new TransportationTrips { Vehicle = "1111 JN 12", StartTime=new DateTime(10,10,10,9,30,0), Tolerance=new TimeSpan(0,10,0), DestinationLocation=23.122M, StartLocation=56.111M, SeatCount=4 },
                new TransportationTrips { Vehicle = "5678 NV 12", StartTime=new DateTime(10,10,10,9,30,0), Tolerance=new TimeSpan(0,10,0), DestinationLocation=23.122M, StartLocation=56.111M, SeatCount=4 },
                new TransportationTrips { Vehicle = "3341 JN 12", StartTime=new DateTime(10,10,10,9,30,0), Tolerance=new TimeSpan(0,10,0), DestinationLocation=23.122M, StartLocation=56.111M, SeatCount=4 },
                new TransportationTrips { Vehicle = "4453 SP 09", StartTime=new DateTime(10,10,10,9,30,0), Tolerance=new TimeSpan(0,10,0), DestinationLocation=23.122M, StartLocation=56.111M, SeatCount=4 },
                new TransportationTrips { Vehicle = "3366 FB 12", StartTime=new DateTime(10,10,10,9,30,0), Tolerance=new TimeSpan(0,10,0), DestinationLocation=23.122M, StartLocation=56.111M, SeatCount=4 },
                new TransportationTrips { Vehicle = "2299 AP 20", StartTime=new DateTime(10,10,10,9,30,0), Tolerance=new TimeSpan(0,10,0), DestinationLocation=23.122M, StartLocation=56.111M, SeatCount=4 },
                new TransportationTrips { Vehicle = "1132 JN 12", StartTime=new DateTime(10,10,10,9,30,0), Tolerance=new TimeSpan(0,10,0), DestinationLocation=23.122M, StartLocation=56.111M, SeatCount=4 },
                new TransportationTrips { Vehicle = "592 MR 12", StartTime=new DateTime(10,10,10,9,30,0), Tolerance=new TimeSpan(0,10,0), DestinationLocation=23.122M, StartLocation=56.111M, SeatCount=4 }
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(TransportationTrips item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(TransportationTrips item)
        {
            var oldItem = items.Where((TransportationTrips arg) => arg.Vehicle == item.Vehicle).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((TransportationTrips arg) => arg.Vehicle == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<TransportationTrips> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Vehicle == id));
        }

        public async Task<IEnumerable<TransportationTrips>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}