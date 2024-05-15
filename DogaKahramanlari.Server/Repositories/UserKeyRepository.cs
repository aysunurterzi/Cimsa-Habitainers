using DogaKahramanlari.Server.Models;
using DogaKahramanlari.Server.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DogaKahramanlari.Server.Repositories
{
    public class UserKeyRepository : RepositoryBase<UserKey>, IUserKeyRepository
    {
        public UserKeyRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserKey>> GetAllUserKeysAsync(bool trackChanges) =>
                         await FindAll(trackChanges)
                        .ToListAsync();

        public async Task<UserKey> GetOneUserKeyByIdAsync(string id, bool trackChanges) =>
           await FindByCondition(c => c.Id.Equals(id), trackChanges)
                .SingleOrDefaultAsync();
        public void CreateOneUserKey(UserKey userKey) => Create(userKey);
        public void UpdateOneUserKey(UserKey userKey) => Update(userKey);



    }
}