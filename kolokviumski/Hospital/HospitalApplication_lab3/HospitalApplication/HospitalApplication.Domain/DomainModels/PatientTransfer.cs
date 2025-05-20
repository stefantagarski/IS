﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApplication.Domain.DomainModels
{
    public class PatientTransfer : BaseEntity
    {
        public Guid PatientId { get; set; }
        public Patient? Patient { get; set; }
        public Guid TransferRequestId { get; set; }
        public TransferRequest? TransferRequest { get; set; }
    }
}
