using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaloom.Application.UseCases.Students.SharedValidator.Utils
{
    public class BirthDateValidate
    {
        public static bool ValidDate(DateOnly date)
        {
            return date != default;
        }

        public static bool InTheFuture(DateOnly date)
        {
            return date <= DateOnly.FromDateTime(DateTime.Today);
        }
    }
}