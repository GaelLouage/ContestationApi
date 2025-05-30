using Infra.Dtos;
using Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mappers
{
    public static class OpposerMapper
    {
        public static OpposerTask MapToOpposerTask(this OpposerDto opposer, string decision)
        {
            return new OpposerTask()
            {
                FineNumber = opposer.FineNumber,
                FullName = opposer.FullName,
                Address = opposer.Address,
                City = opposer.City,
                PostalCode = opposer.PostalCode,
                Email = opposer.Email,
                Phone = opposer.Phone,
                DecisionType = decision,
                ContestationDate = opposer.ContestationDate,
                ReasonForFine = opposer.ReasonForFine,
                ReasonForContestation = opposer.ReasonForContestation,
                FineIssueDate = opposer.FineIssueDate,
            };
        }

        public static OpposerDto MapToOpposerDto(this Opposer opposer)
        {
            return new OpposerDto()
            {
                FineNumber = opposer.FineNumber,
                FullName = opposer.FullName,
                Address = opposer.Address,
                City = opposer.City,
                PostalCode = opposer.PostalCode,
                Email = opposer.Email,
                Phone = opposer.Phone,
                ContestationDate = opposer.ContestationDate,
                ReasonForFine = opposer.ReasonForFine,
                ReasonForContestation = opposer.ReasonForContestation,
                FineIssueDate = opposer.FineIssueDate,
            };
        }
    }
}
