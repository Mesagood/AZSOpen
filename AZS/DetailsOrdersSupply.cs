//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AZS
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetailsOrdersSupply
    {
        public int IdDetailOrder { get; set; }
        public int IdOrder { get; set; }
        public int IdPetrol { get; set; }
        public int PetrolCount { get; set; }
    
        public virtual OrdersFromSupplier OrdersFromSupplier { get; set; }
        public virtual Petrol Petrol { get; set; }
    }
}