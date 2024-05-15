using DogaKahramanlari.Server.Models;
using DogaKahramanlari.Server.Utilities.DataTransferObjects;

namespace DogaKahramanlari.Server.Services.Contracts
{
    public interface IUserKeyService
    {
        Task<IEnumerable<UserKey>> GetAllUserKeysAsync(bool trackChanges);
        Task<UserKey> GetOneUserKeyByIdAsync(string id, bool trackChanges);
        Task<UserKeyDto> CreateOneUserKeyAsync(UserKeyDtoForInsertion userKeyDtoForInsertion);
        Task UpdateOneUserKeyAsync(string id, UserKeyDtoForUpdate userkeyDto, bool trackChanges);


    }
}