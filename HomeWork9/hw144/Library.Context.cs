﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LibraryContainer : DbContext
    {
        public LibraryContainer()
            : base("name=LibraryContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Book> BookSet { get; set; }
        public virtual DbSet<Author> AuthorSet { get; set; }
        public virtual DbSet<BookAuthor> BookAuthorSet { get; set; }
        public virtual DbSet<User> UserSet { get; set; }
        public virtual DbSet<BookRequest> BookRequestSet { get; set; }
    }
}
