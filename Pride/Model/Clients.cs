using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pride.Model
{
    public class Clients
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
       
        public string CoverageType { get; set; }
        [StringLength(50)]
       
        public string Broker { get; set; }
        [StringLength(50)]
       
        public string ClientInsuranceCompany { get; set; }
        [StringLength(50)]
       
        public string PolicyNumber { get; set; }
    
       
        public string Effectivedate { get; set; }
      
       
        public string Expirydate { get; set; }
       
        public Double PremiumAmount { get; set; }
       

        public Double Taxfees { get; set; }
       
        public Double Sumtotalpremium { get; set; }
       
        public string financecompany { get; set; }
       
        public Double DownPayment { get; set; }
       
        public Double DownPaymentReceived { get; set; }
       
        public Double PendingDownPayment { get; set; }
       
        public Double Commission { get; set; }
       
        public Double Brokerge { get; set; }
       
        public Double Commissionrecived { get;set; }
       

        public Double Balancecommission { get; set; }
       
        public Double Payments { get; set; }
       
        public Double Pendingpayment { get; set; }
        public string Email  { get; set; }
    }
}
