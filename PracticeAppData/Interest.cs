//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracticeAppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Interest
    {
        public int id { get; set; }
        public Nullable<decimal> interest1 { get; set; }
        public Nullable<int> accId { get; set; }
    
        public virtual CreateAccount CreateAccount { get; set; }
    }
}