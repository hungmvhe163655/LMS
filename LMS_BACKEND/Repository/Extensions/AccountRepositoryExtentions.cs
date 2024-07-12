using Entities.Models;
using Shared.DataTransferObjects.RequestParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class AccountRepositoryExtentions
    {
        public static IQueryable<Account> Search(this IQueryable<Account> data, NeedVerifyParameters parameters)
        {
            var hold = data;

            if (parameters.UserId != null) hold = data.Where(x => x.VerifiedBy != null && x.VerifiedBy.Equals(parameters.UserId));

            if (string.IsNullOrWhiteSpace(parameters.SearchContent ?? "")) return hold;

            var lowerCaseTerm = parameters.SearchContent == null ? "" : parameters.SearchContent.Trim().ToLower();

            hold = hold.Where(n => n.FullName != null && n.FullName.ToLower().Contains(lowerCaseTerm));

            return hold;
        }
    }
}
