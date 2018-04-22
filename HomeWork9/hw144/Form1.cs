using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hw144
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            /*
            using (var db = new LibraryContainer())
            {
                var book1 = new Book { Id = 1, Name = "Book1"};
                var book2 = new Book { Id = 2, Name = "Book2"};
                var book3 = new Book { Id = 3, Name = "Book3" };
                db.BookSet.Add(book1);
                db.BookSet.Add(book2);
                db.BookSet.Add(book3);

                var author1 = new Author { Id = 1, Name = "Author1" };
                var author2 = new Author { Id = 2, Name = "Author2" };
                var author3 = new Author { Id = 3, Name = "Author3" };
                db.AuthorSet.Add(author1);
                db.AuthorSet.Add(author2);
                db.AuthorSet.Add(author3);

                var user1 = new User { Id = 1, Status = true };
                var user2 = new User { Id = 2, Status = false };
                var user3 = new User { Id = 3, Status = false };
                db.UserSet.Add(user1);
                db.UserSet.Add(user2);
                db.UserSet.Add(user3);

                var bookAuthor1 = new BookAuthor { BookId = 1, AuthorId = 3 };
                var bookAuthor2 = new BookAuthor { BookId = 2, AuthorId = 3 };
                var bookAuthor3 = new BookAuthor { BookId = 3, AuthorId = 1 };
                db.BookAuthorSet.Add(bookAuthor1);
                db.BookAuthorSet.Add(bookAuthor2);
                db.BookAuthorSet.Add(bookAuthor3);

                var bookRequest1 = new BookRequest { BookId = 1, UserId = 2};
                var bookRequest2 = new BookRequest { BookId = 2, UserId = 2};
                db.BookRequestSet.Add(bookRequest1);
                db.BookRequestSet.Add(bookRequest2);

                db.SaveChanges();
            }*/
            using (var db = new LibraryContainer())
            {
                listBox1.DataSource = new BindingList<User>(db.UserSet.ToList().Where(x => x.Status == false).ToList());
                listBox1.DisplayMember = "Id";

                BindingList<Author> lb2 = new BindingList<Author>();
                foreach(var bookAuthor in db.BookAuthorSet)
                {
                    if(bookAuthor.Book.Id == 3) { lb2.Add(bookAuthor.Author); }
                }
                listBox2.DataSource = lb2;
                listBox2.DisplayMember = "Name";

                BindingList<Book> lb3 = new BindingList<Book>();
                foreach (var bookRequest in db.BookRequestSet)
                {
                    foreach (var book in db.BookSet)
                    {
                        if (bookRequest.Book != book)
                        {
                            lb3.Add(book);
                        }
                    }
                }
                listBox3.DataSource = lb3;
                listBox3.DisplayMember = "Name";


                BindingList<Book> lb4 = new BindingList<Book>();
                foreach (var bookRequest in db.BookRequestSet)
                {
                    if (bookRequest.User.Id == 2) { lb4.Add(bookRequest.Book); }
                }
                listBox4.DataSource = lb4;
                listBox4.DisplayMember = "Name";

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new LibraryContainer())
            {
                foreach(var user in db.UserSet.ToList())
                {
                    user.Status = true;
                }
                db.SaveChanges();
            }
            listBox1.Update();
        }
    }
}
