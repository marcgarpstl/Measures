﻿using Measure.Domain.DTOs.ReadDTO;
using Measure.Domain.DTOs.WriteDTO;
using Measure.Domain.Entities;
using Measure.Domain.Extensions;
using Measure.Domain.Repositories;
using Measure.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IFemaleMeasureRepository _faemaleMeasureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IFemaleMeasureRepository femaleMeasureRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _faemaleMeasureRepository = femaleMeasureRepository;
        }
        public async Task<IEnumerable<ReadUserCridentialsDto>> GetAll(CancellationToken ct)
        {
            IEnumerable<User> users = await _userRepository.GetAllAsync(ct);

            if (ct.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }
            return users.ToList().ToUsersDtoList();
        }
        public async Task AddUserAsync(SetUserDto user, CancellationToken ct = default)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            User createUser = user.ToUser();
            await _userRepository.AddUserAsync(createUser, ct);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ChangeEmail(Guid id, string email, CancellationToken ct = default)
        {
            if (id == Guid.Empty || string.IsNullOrEmpty(email)) throw new ArgumentNullException("Id or Email can not be null");

            var user = await _userRepository.GetUserByGuidAsync(id);

            if(user is null) throw new ArgumentNullException("No user found");

            user.Email = email;

            await _userRepository.ChangeEmailAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ChangePassword(Guid id, string password, CancellationToken ct = default)
        {
            if (id == Guid.Empty || string.IsNullOrEmpty (password)) throw new ArgumentNullException("Id or password can not be null");

            var user = await _userRepository.GetUserByGuidAsync(id);

            if (user is null) throw new ArgumentNullException("No user found");

            user.Password = password;

            await _userRepository.ChangePasswordAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUser(Guid id, CancellationToken ct = default)
        {
            if (id == Guid.Empty) throw new ArgumentNullException("Not null");

            await _userRepository.DeleteUserAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<ReadUserDto> GetById(Guid id, CancellationToken ct = default)
        {
            if (id == Guid.Empty) throw new ArgumentNullException("Id cannot be null");

            var user = await _userRepository.GetUserByGuidAsync(id);
            user.Female = await _faemaleMeasureRepository.GetFemaleMeasuresByIdAsync(id);

            if (user == null) throw new ArgumentNullException("Not found");


            else if (ct.IsCancellationRequested) throw new OperationCanceledException();

            return user.ToUserDto();
        }
    }
}
