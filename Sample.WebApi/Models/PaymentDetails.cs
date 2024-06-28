using System.ComponentModel.DataAnnotations;

namespace Sample.WebApi.Models
{
    public class PaymentDetails
    {
        [Key]
        public int PaymentId { get; set; }
        public string PaymentType { get; set; }
        public string Bank { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public decimal AmountPaid { get; set; }
        public int ProductId { get; set; }
        public string TransactionId { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
