using Measure.Domain.DTOs.ReadDTO;
using Measure.Domain.DTOs.WriteDTO;
using Measure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Extensions
{
    internal static class UserMapper
    {
        internal static ReadUserDto ToUserDto(this User user) =>
            new ReadUserDto(
                user.Id,
                user.FirstName,
                user.LastName,
                user.Email,
                user.Password,
                user.UserName,
                user.Male,
                user.Female
                );
        
        internal static User ToUser(this SetUserDto userDto) =>
            new User(
                userDto.Id,
                userDto.FirstName,
                userDto.LastName,
                userDto.Email,
                userDto.Password,
                userDto.UserName
                );
    }
}
