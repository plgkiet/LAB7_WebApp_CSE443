using Microsoft.EntityFrameworkCore;
using LAB3_WEBAPP.Models;
using LAB3_WEBAPP.Models.Book;

namespace LAB3_WEBAPP.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carousel>().HasData(
                new Carousel
                {
                    CarouselId = 1,
                    ImageURL = "carousel_images/1.png",
                    Title = "1",
                    Description = "1",
                    LinkURL = null,
                    Order = 1,
                    IsActive = true,
                    CreatedDate = new DateTime(2025, 5, 9),
                    UpdatedDate = new DateTime(2025, 5, 9)
                },
                new Carousel
                {
                    CarouselId = 2,
                    ImageURL = "carousel_images/2.png",
                    Title = "2",
                    Description = "2",
                    LinkURL = null,
                    Order = 2,
                    IsActive = true,
                    CreatedDate = new DateTime(2025, 5, 9),
                    UpdatedDate = new DateTime(2025, 5, 9)
                }
            );
            
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1, Name = "Self-help", Description = "Personal development and self-help books",
                    CreatedDate = new DateTime(2025, 5, 19), IsActive = true
                },
                new Category
                {
                    CategoryId = 2, Name = "Literature", Description = "Fiction and literary works",
                    CreatedDate = new DateTime(2025, 5, 19), IsActive = true
                },
                new Category
                {
                    CategoryId = 3, Name = "Travel", Description = "Books about travel and exploration",
                    CreatedDate = new DateTime(2025, 5, 19), IsActive = true
                });

            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    AuthorId = 1, FirstName = "Dale", LastName = "Carnegie", CreatedDate = new DateTime(2025, 5, 19),
                    IsActive = true
                },
                new Author
                {
                    AuthorId = 2, FirstName = "Saint", LastName = "Exupery", CreatedDate = new DateTime(2025, 5, 19),
                    IsActive = true
                },
                new Author
                {
                    AuthorId = 3, FirstName = "Rosie", LastName = "Nguyễn", CreatedDate = new DateTime(2025, 5, 19),
                    IsActive = true
                },
                new Author
                {
                    AuthorId = 4, FirstName = "Nguyên", LastName = "Khải", CreatedDate = new DateTime(2025, 5, 19),
                    IsActive = true
                },
                new Author
                {
                    AuthorId = 5, FirstName = "Nguyễn", LastName = "Ngọc Ký", CreatedDate = new DateTime(2025, 5, 19),
                    IsActive = true
                },
                new Author
                {
                    AuthorId = 6, FirstName = "Nguyễn", LastName = "Hoàng Tình",
                    CreatedDate = new DateTime(2025, 5, 19), IsActive = true
                },
                new Author
                {
                    AuthorId = 7, FirstName = "Nguyễn", LastName = "Ngọc Ánh", CreatedDate = new DateTime(2025, 5, 19),
                    IsActive = true
                },
                new Author
                {
                    AuthorId = 8, FirstName = "Nguyễn", LastName = "Vỹ", CreatedDate = new DateTime(2025, 5, 19),
                    IsActive = true
                }
            );

            // Seed Books (ngẫu nhiên CategoryId từ 1 đến 3)
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Đắc Nhân Tâm", AuthorId = 1, CategoryId = 1, CoverImage = "book1.png", Pdf = "book.pdf" },
                new Book { BookId = 2, Title = "Hoàng Tử Bé", AuthorId = 2, CategoryId = 2, CoverImage = "book2.png", Pdf = "book.pdf" },
                new Book
                {
                    BookId = 3, Title = "Ta ba lô trên đất Á", AuthorId = 3, CategoryId = 3, CoverImage = "book3.png", Pdf = "book.pdf"
                },
                new Book
                {
                    BookId = 4, Title = "Vượt Bẫy Cảm Xúc", AuthorId = 4, CategoryId = 1, CoverImage = "book4.png", Pdf = "book.pdf"
                },
                new Book { BookId = 5, Title = "Tôi đi học", AuthorId = 5, CategoryId = 2, CoverImage = "book5.png", Pdf = "book.pdf" },
                new Book
                {
                    BookId = 6, Title = "Giã biệt hoang vu", AuthorId = 6, CategoryId = 3, CoverImage = "book6.png", Pdf = "book.pdf"
                },
                new Book
                {
                    BookId = 7, Title = "Tôi thấy hoa vàng trên cỏ xanh", AuthorId = 7, CategoryId = 2,
                    CoverImage = "book7.png", Pdf = "book.pdf"
                },
                new Book
                {
                    BookId = 8, Title = "Chiếc áo cưới màu hồng", AuthorId = 8, CategoryId = 2, CoverImage = "book8.png", Pdf = "book.pdf"
                }
            );
            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Username  = "admin",
                    Fullname = "Nguyễn Văn A",
                    Password  = "$2a$11$lpIJVZRmA94ZEbPzWx61r./7yq/NaJbIxSDgRAbNJ0r9uptRo82lW", // hash của "0"
                    Email = "admin@example.com",
                    Phone = "0909123456",
                    Address = "123 Đường ABC, Bình Dương",
                    Status = 1,
                    CreatedDate = new DateTime(2025, 5, 23),
                    UserCode = "USR001",
                    IsLocked = false,
                    IsDeleted = false,
                    IsActive = true,
                    Avatar = "avatars/user1.png"
                },
                new User
                {
                    UserId = 2,
                    Fullname = "Trần Thị B",
                    Username  = "mem1",
                    Password  = "$2a$11$DO6pmHlIENmuldPySmnZ5OVRhDFqvVzo04iKun58oZRPbJMYANRZO", // hash của "1"
                    Email = "thib@example.com",
                    Phone = "0988765432",
                    Address = "456 Đường XYZ, TP.HCM",
                    Status = 0,
                    CreatedDate = new DateTime(2025, 5, 23),
                    UserCode = "USR002",
                    IsLocked = false,
                    IsDeleted = false,
                    IsActive = true,
                    Avatar = "avatars/user2.png"
                },
                new User
                {
                    UserId = 3,
                    Fullname = "Lê Văn C",
                    Username  = "mem2",
                    Password  = "$2a$11$LNROwf1mJ6XybRprV99CR.Q0rPiR5gOO/j/rL8KFSPp8XNPSipj2O", // hash của "1"
                    Email = "vanc@example.com",
                    Phone = "0911222333",
                    Address = "789 Phố QWE, Hà Nội",
                    Status = 1,
                    CreatedDate = new DateTime(2025, 5, 23),
                    UserCode = "USR003",
                    IsLocked = false,
                    IsDeleted = false,
                    IsActive = true,
                    Avatar = "avatars/user3.png"
                }
            );
            
            
            modelBuilder.Entity<Loan>().HasData(
                new Loan
                {
                    LoanId = 1,
                    UserId = 1,
                    BookId = 1,
                    LoanDate = new DateTime(2025, 5, 20),
                    DueDate = new DateTime(2025, 6, 20),
                    ReturnDate = null,
                    Status = 0 // 0 = chưa trả
                },
                new Loan
                {
                    LoanId = 2,
                    UserId = 2,
                    BookId = 3,
                    LoanDate = new DateTime(2025, 5, 15),
                    DueDate = new DateTime(2025, 6, 15),
                    ReturnDate = new DateTime(2025, 6, 10),
                    Status = 1 // 1 = đã trả
                },
                new Loan
                {
                    LoanId = 3,
                    UserId = 3,
                    BookId = 5,
                    LoanDate = new DateTime(2025, 4, 25),
                    DueDate = new DateTime(2025, 5, 25),
                    ReturnDate = null,
                    Status = 2 // 2 = quá hạn
                }
            );
            
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Name = "Admin" },
                new Role { RoleId = 2, Name = "Member" }
            );
            
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserId = 1, RoleId = 1 }, 
                new UserRole { UserId = 2, RoleId = 2 }, 
                new UserRole { UserId = 3, RoleId = 2 }  
            );
        }
    }
}