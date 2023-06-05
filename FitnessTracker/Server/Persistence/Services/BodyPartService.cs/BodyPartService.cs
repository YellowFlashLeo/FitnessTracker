using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessTracker.Server.Persistence.DataBase;
using FitnessTracker.Shared;
using FitnessTracker.Shared.Domain.Fitness;
using Microsoft.EntityFrameworkCore;

namespace FitnessTracker.Server.Persistence.Services.BodyPartService.cs
{
    public class BodyPartService : IBodyPartService
    {
        private readonly FitnessStoreContext _dbContext;

        public BodyPartService(FitnessStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<List<BodyPart>>> GetBodyParts()
        {
            try
            {
                var bodyParts = await _dbContext.BodyParts.ToListAsync();
                return new ServiceResponse<List<BodyPart>>
                {
                    Data = bodyParts
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }

        public async Task<ServiceResponse<BodyPart>> GetBodyPart(int id)
        {
            var bodyPart = await _dbContext.BodyParts.FirstOrDefaultAsync(b => b.Id.Equals(id));
            return new ServiceResponse<BodyPart>
            {
                Data = bodyPart
            };
        }

        public async Task<ServiceResponse<List<Exercise>>> GetExercises(string bodyPartUrl)
        {
            var bodyPart = await _dbContext.BodyParts.FirstOrDefaultAsync(b => b.Name.Equals(bodyPartUrl));
            var exercises = await _dbContext.Exercises.Where(e => e.BodyPartId.Equals(bodyPart.Id)).ToListAsync();
            return new ServiceResponse<List<Exercise>>
            {
                Data = exercises
            };
        }
    }
}
