using AutoMapper;
using DogaKahramanlari.Server.Models;
using DogaKahramanlari.Server.Repositories.Contracts;
using DogaKahramanlari.Server.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace DogaKahramanlari.Server.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authencationService;
        private readonly Lazy<IAnimalService> _animalService;
        private readonly Lazy<IUserKeyService> _userKeyService;
        private readonly Lazy<IDutyService> _dutyService;



        public ServiceManager(IRepositoryManager repositoryManager,
            IMapper mapper,
            IConfiguration configuration,
            UserManager<User> userManager)
        {

            _authencationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationManager(repositoryManager,mapper, userManager, configuration));

            _animalService = new Lazy<IAnimalService>(() =>
           new AnimalManager(repositoryManager, mapper));

            _userKeyService = new Lazy<IUserKeyService>(() =>
           new UserKeyManager(repositoryManager, mapper, userManager));
            
           _dutyService = new Lazy<IDutyService>(() =>
           new DutyManager(repositoryManager, mapper));



        }
        public IAuthenticationService AuthenticationService => _authencationService.Value;
        public IAnimalService AnimalService => _animalService.Value;
        public IUserKeyService UserKeyService => _userKeyService.Value;
        public IDutyService DutyService => _dutyService.Value;


    }
}