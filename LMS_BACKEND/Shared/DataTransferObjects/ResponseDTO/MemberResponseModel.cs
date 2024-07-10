﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.ResponseDTO
{
    public class MemberResponseModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public bool IsLeader { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
