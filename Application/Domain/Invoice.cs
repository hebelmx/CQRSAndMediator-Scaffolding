using System;
using System.Runtime.Serialization;

namespace Application.Domain
{
    public class Invoice
    {
        [DataMember]
        public int InvoiceId { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public DateTime DueDate { get; set; }

        [DataMember]
        public DateTime PaidDate { get; set; }

        [DataMember]
        public decimal GrandTotal { get; set; }

        [DataMember]
        public decimal SubTotal { get; set; }

        [DataMember]
        public decimal Tax { get; set; }

        [DataMember]
        public string OrderedBy { get; set; }

        [DataMember]
        public string PurchaseOrderRef { get; set; }

        [DataMember]
        public int InvoiceNo { get; set; }

        [DataMember]
        public double PaidAmount { get; set; }

        [DataMember]
        public double PaidTax { get; set; }

        [DataMember]
        public bool InvoiceEmailed { get; set; }

        [DataMember]
        public string EmailTo { get; set; }

        [DataMember]
        public string TermsAndConditions { get; set; }

        [DataMember]
        public string PaymentDetails { get; set; }
    }
}