using FileDoc.Interfaces;
using FileDoc.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDoc.Services
{
    public class CargoManifestSvc : ICargoManifest
    {
        protected DataContext _context;

        public CargoManifestSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddCargoManifest(CargoManifest CargoManifests)
        {
            _context.Add(CargoManifests);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> EditCargoManifest(int id, CargoManifest CargoManifests)
        {
            _context.cargoManifests.Update(CargoManifests);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CargoManifest>> GetCargoManifestAll()
        {
            var dataContext = _context.cargoManifests;
            return await dataContext.ToListAsync();
        }

        public async Task<CargoManifest> GetCargoManifest(int? id)
        {
            var CargoManifests = await _context.cargoManifests
                .FirstOrDefaultAsync(m => m.FlightId == id);
            if (CargoManifests == null)
            {
                return null;
            }

            return CargoManifests;
        }

    }
}

