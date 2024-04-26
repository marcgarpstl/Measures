using Measure.Domain.DTOs.ReadDTO;
using Measure.Domain.DTOs.WriteDTO;
using Measure.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Extensions
{
    internal static class UserMapper
    {
        internal static List<ReadUserCridentialsDto> ToUsersDtoList(this List<User> usersList) =>
            usersList.Select(ul => ul.ToUserCridentials()).ToList();
        internal static ReadUserCridentialsDto ToUserCridentials(this User user) =>
            new ReadUserCridentialsDto(
                user.Id,
                user.FirstName,
                user.LastName,
                user.UserName,
                user.Email,
                user.Password
                );
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
                userDto.FirstName,
                userDto.LastName,
                userDto.Email,
                userDto.Password,
                userDto.UserName
                );
    }
}
