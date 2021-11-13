using PostalService.Models;
using PostalService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Services
{
    public class ParcelService
    {
        private readonly ParcelRepository _parcelRepository;

        public ParcelService(ParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        public async Task<List<Parcel>> GetAllAsync()
        {
            return await _parcelRepository.GetAsync();
        }

        public async Task<Parcel> GetByIdAsync(int id)
        {
            return await _parcelRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Parcel parcel)
        {
            await _parcelRepository.AddAsync(parcel);
        }

        public async Task DeleteAsync(int id)
        {
            var parcel = await GetByIdAsync(id);
            await _parcelRepository.DeleteAsync(parcel);
        }

        public async Task UpdateAsync(Parcel parcel)
        {
            await _parcelRepository.UpdateAsync(parcel);
        }
    }
}
