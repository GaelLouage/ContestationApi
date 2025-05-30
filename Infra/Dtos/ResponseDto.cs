using Infra.Enum;

namespace Infra.Dtos
{
    public class ResponseDto
    {
        public string FineNumber { get; set; }
        public DecisionType Decision { get; set; }
        public string DecisionDate { get; set; }
        public string Notes { get; set; }
        public string ReviewedBy { get; set; }
        public double? NewAmount { get; set; }
        public string Currency { get; set; }
    }
}
