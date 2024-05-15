using AutoMapper;
using Azure.Core;
using DogaKahramanlari.Server.Models;
using DogaKahramanlari.Server.Repositories.Contracts;
using DogaKahramanlari.Server.Services.Contracts;
using DogaKahramanlari.Server.Utilities.DataTransferObjects;
using Microsoft.AspNetCore.Identity;

namespace DogaKahramanlari.Server.Services
{
    public class UserKeyManager : IUserKeyService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        private User? _user;


        public UserKeyManager(IRepositoryManager manager, IMapper mapper, UserManager<User> userManager)
        {
            _manager = manager;
            _userManager = userManager;
            _mapper = mapper;

        }
        public async Task<IEnumerable<UserKey>> GetAllUserKeysAsync(bool trackChanges)
        {
            return await _manager
                .UserKeyRepository
                .GetAllUserKeysAsync(trackChanges);
        }
        public async Task<UserKey> GetOneUserKeyByIdAsync(string id, bool trackChanges)
        {

            var userKey = await _manager
                .UserKeyRepository
                .GetOneUserKeyByIdAsync(id, trackChanges);

            if (userKey is null)
                throw new ArgumentNullException(nameof(userKey), "Userkey cannot be null.");
            return userKey;
        }
        public async Task UpdateOneUserKeyAsync(string id, UserKeyDtoForUpdate userkeyDto, bool trackChanges)
        {
            var entity = await _manager.UserKeyRepository.GetOneUserKeyByIdAsync(id, trackChanges);

            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "Userkey cannot be null.");

            // Güncelleme işlemi öncesinde entity'nin değerlerini userkeyDto'dan alınan değerlerle güncelleyin
            _mapper.Map(userkeyDto, entity);

            // Bu satırda UpdateOneUserKey metodunu çağırmadan önce entity'nin Id'sinin boş olmadığından emin olun
            if (string.IsNullOrEmpty(entity.Id))
            {
                throw new ArgumentException("UserKey entity Id cannot be null or empty.", nameof(entity.Id));
            }

            // UpdateOneUserKey metodunu çağırarak güncelleme işlemini gerçekleştirin
            _manager.UserKeyRepository.UpdateOneUserKey(entity);
            await _manager.SaveAsync();
        }



        public async Task<UserKeyDto> CreateOneUserKeyAsync(UserKeyDtoForInsertion userKeyDtoForInsertion)
        {
            var entity = _mapper.Map<UserKey>(userKeyDtoForInsertion);
            _manager.UserKeyRepository.CreateOneUserKey(entity);
            await _manager.SaveAsync();
            return _mapper.Map<UserKeyDto>(entity);

        }


    }
}