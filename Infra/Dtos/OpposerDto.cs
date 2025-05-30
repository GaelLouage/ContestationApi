namespace Infra.Dtos
{
    public class OpposerDto
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ContestationDate { get; set; }
        public string FineNumber { get; set; }
        public string FineIssueDate { get; set; }
        public string ReasonForFine { get; set; }
        public string ReasonForContestation { get; set; }
        public List<string> AttachedDocuments { get; set; }
    }
}
