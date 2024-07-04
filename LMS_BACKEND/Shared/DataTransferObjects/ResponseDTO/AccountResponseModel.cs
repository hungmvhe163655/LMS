using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class AccountResponseModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime CreatedDate { get; set; } 
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public Guid? VerifiedByUserId { get; set; } = null!;
        public ICollection<string> Roles { get; init; } = null!;
    }
}
