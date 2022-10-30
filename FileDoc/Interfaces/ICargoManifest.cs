using FileDoc.Model;
using FileDoc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileDoc.Interfaces
{
    public interface ICargoManifest
    {
        Task<bool> AddCargoManifest(CargoManifest CargoManifests);
        Task<bool> EditCargoManifest(int id, CargoManifest CargoManifests);
        Task<List<CargoManifest>> GetCargoManifestAll();
        Task<CargoManifest> GetCargoManifest(int? id);

    }
}
