using Microsoft.EntityFrameworkCore;
using PostalService.Data;
using PostalService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostalService.Repositories
{
    public class ParcelRepository
    {
        private readonly DataContext _context;

        public ParcelRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Parcel>> GetAsync()
        {
            return await _context.Parcels.Include(x => x.Post).ToListAsync();
        }

        public async Task<Parcel> GetByIdAsync(int id)
        {
            return await _context.Parcels.Include(x => x.Post).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Parcel parcel)
        {
            _context.Parcels.Add(parcel);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Parcel parcel)
        {
            _context.Remove(parcel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Parcel parcel)
        {

            _context.Entry(parcel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
