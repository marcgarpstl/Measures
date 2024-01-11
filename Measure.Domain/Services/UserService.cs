using Measure.Domain.DTOs.WriteDTO;
using Measure.Domain.Entities;
using Measure.Domain.Extensions;
using Measure.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        //private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            //_unitOfWork = unitOfWork;
        }
        public async Task AddUserAsync(SetUserDto user, CancellationToken ct = default)
        {
            if (user == null) throw new ArgumentNullException();

            User createUser = user.ToUser();
            await _userRepository.AddUserAsync(createUser, ct);
        }

        public async Task ChangeEmail(Guid id, string email, CancellationToken ct = default)
        {
            if (id == Guid.Empty || string.IsNullOrEmpty(email)) throw new ArgumentNullException("Id or Email can not be null");

            var user = await _userRepository.GetUserByGuid(id);

            if(user is null) throw new ArgumentNullException("No user found");

            user.Email = email;

            await _userRepository.ChangeEmail(user);
            //await _iUnitOfWork.SaveChangesAsync();
        }

        public async Task ChangePassword(Guid id, string password, CancellationToken ct = default)
        {
            if (id == Guid.Empty || string.IsNullOrEmpty (password)) throw new ArgumentNullException("Id or password can not be null");

            var user = await _userRepository.GetUserByGuid(id);

            if (user is null) throw new ArgumentNullException("No user found");

            user.Password = password;

            await _userRepository.ChangePassword(user);
            //await _iUnitOfWork.SaveChangesAsync();
        }
    }
}
