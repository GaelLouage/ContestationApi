using Infra.Dtos;
using Infra.Enum;
using Infra.Models;

namespace Infra.Mappers
{
    public static class ResponseMapper
    {
        public static ResponseDto MapToResponseDto(this Response? response)
        {
            return new ResponseDto()
            {
                FineNumber = response.FineNumber,
                Decision = response.Decision,
                DecisionDate = response.DecisionDate,
                Notes = response.Notes,
                Currency = response.Currency,
                NewAmount = response.NewAmount,
            };
        }
    }
}
