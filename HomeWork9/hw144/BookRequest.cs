//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hw144
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookRequest
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}