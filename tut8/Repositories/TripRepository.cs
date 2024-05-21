using Microsoft.EntityFrameworkCore;
using tut8.Context;
using tut8.Models;

namespace tut8.Repositories
{
    public class TripRepository(TripContext context) : ITripRepository
    {
        public async Task<IEnumerable<Trip>> GetTrips(int page, int pageSize)
        {
            return await context.Trips
                                 .OrderByDescending(t => t.DateFrom)
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .Include(t => t.CountryTrips)
                                 .ThenInclude(ct => ct.Country)
                                 .Include(t => t.ClientTrips)
                                 .ThenInclude(ct => ct.Client)
                                 .ToListAsync();
        }

        public async Task<int> GetTripsCount()
        {
            return await context.Trips.CountAsync();
        }

        public async Task<Client> GetClientById(int idClient)
        {
            return await context.Clients.Include(c => c.ClientTrips).FirstOrDefaultAsync(c => c.IdClient == idClient);
        }

        public async Task<bool> DeleteClient(int idClient)
        {
            var client = await context.Clients.FindAsync(idClient);
            if (client == null) return false;

            context.Clients.Remove(client);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AssignClientToTrip(Client client, int idTrip)
        {
            var trip = await context.Trips.FindAsync(idTrip);
            if (trip == null || trip.DateFrom <= DateTime.Now) return false;

            var existingClient = await context.Clients.FirstOrDefaultAsync(c => c.Pesel == client.Pesel);
            if (existingClient != null)
            {
                var clientTrip = await context.ClientTrips.FirstOrDefaultAsync(ct => ct.IdClient == existingClient.IdClient && ct.IdTrip == idTrip);
                if (clientTrip != null) return false;

                client = existingClient;
            }
            else
            {
                await context.Clients.AddAsync(client);
                await context.SaveChangesAsync();
            }

            var newClientTrip = new ClientTrip
            {
                IdClient = client.IdClient,
                IdTrip = idTrip,
                RegisteredAt = DateTime.Now,
                PaymentDate = client.ClientTrips.FirstOrDefault()?.PaymentDate
            };

            await context.ClientTrips.AddAsync(newClientTrip);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
