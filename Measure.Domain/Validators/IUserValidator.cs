using Measure.Domain.DTOs.WriteDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Validators
{
    public interface IUserValidator
    {
        ValidationResult Validating(SetUserDto user);
    }
}
