//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class fee
    {
        public int fee_id { get; set; }
        public int user_id { get; set; }
        public int transaction_id { get; set; }
        public System.DateTime create_date { get; set; }
        public Nullable<decimal> total_fee { get; set; }
        public Nullable<decimal> remaining_fee { get; set; }
        public Nullable<bool> is_paid { get; set; }
    
        public virtual checkout_records checkout_records { get; set; }
        public virtual checkout_records checkout_records1 { get; set; }
        public virtual checkout_records checkout_records2 { get; set; }
        public virtual checkout_records checkout_records3 { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
        public virtual user user2 { get; set; }
        public virtual user user3 { get; set; }
    }
}
