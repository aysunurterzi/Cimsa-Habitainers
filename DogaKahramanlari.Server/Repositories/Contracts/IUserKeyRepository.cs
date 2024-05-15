using DogaKahramanlari.Server.Models;

namespace DogaKahramanlari.Server.Repositories.Contracts
{
    public interface IUserKeyRepository
    {
        Task<IEnumerable<UserKey>> GetAllUserKeysAsync(bool trackChanges);
        Task<UserKey> GetOneUserKeyByIdAsync(string id, bool trackChanges);
        void CreateOneUserKey(UserKey userKey);
        void UpdateOneUserKey(UserKey userKey);

    }
}