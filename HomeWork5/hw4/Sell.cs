//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hw4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sell
    {
        public int Id { get; set; }
        public int Sum { get; set; }
        public System.DateTime Date { get; set; }
        public int BuyersId { get; set; }
        public int SellersId { get; set; }
    
        public virtual Buyers Buyer { private get; set; }
        public virtual Sellers Seller { private get; set; }
    }
}
