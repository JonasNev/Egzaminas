using PostalService.Models;
using PostalService.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostalService.Services
{
    public class ParcelService
    {
        private readonly ParcelRepository _parcelRepository;
        private readonly PostRepository _postRepository;

        public ParcelService(ParcelRepository parcelRepository, PostRepository postRepository)
        {
            _parcelRepository = parcelRepository;
            _postRepository = postRepository;
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

        public bool CheckCapacity(int postId)
        {
            var parcels = _parcelRepository.GetAsync();
            int counter = 0;
            foreach (var parcel in parcels.Result)
            {
                if (parcel.PostId == postId)
                {
                    counter++;
                }
            }
            var checkedPost = _postRepository.GetByIdAsync(postId);
            if (counter >= checkedPost.Result.Capacity)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
