using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebApiDemo.Data
{
    public class WebAPIDemoContextInitializer:DropCreateDatabaseAlways<WebAPIDemoContext>
    {
        protected override void Seed(WebAPIDemoContext context)
        {
            var books = new List<Book>
            {
                new Book()
                {
                    Name = "War and Peace",
                    Author = "Tolstroy",
                    Price = 19.99m
                },
                new Book()
                {
                    Name = "As I Lay Dying",
                    Author = "Faulkner",
                    Price = 49.99m
                },
                new Book()
                {
                    Name = "Harry Potter 1",
                    Author = "Tolstroy",
                    Price = 59.99m
                },
                new Book()
                {
                    Name = "Pro Win 8",
                    Author = "Tolstroy",
                    Price = 219.99m
                },
                new Book()
                {
                    Name = "Book One",
                    Author = "Author1",
                    Price = 139.99m
                },
                new Book()
                {
                    Name = "Book Two",
                    Author = "Author2",
                    Price = 193.99m
                },
                new Book()
                {
                    Name = "Book Three",
                    Author = "Author3",
                    Price = 192.99m
                }
            };
            books.ForEach(b=>context.Books.Add(b));
            context.SaveChanges();

            var order = new Order()
            {
                Customer = "John Doe",
                OrderDate = new DateTime(2014, 7, 10)
            };

            var orderDetails = new List<OrderDetail>()
            {
                new OrderDetail()
                {
                    Book = books[0],
                    Quantity = 1,
                    Order = order
                },
                new OrderDetail()
                {
                    Book = books[2],
                    Quantity = 2,
                    Order = order
                },
                new OrderDetail()
                {
                    Book = books[1],
                    Quantity = 3,
                    Order = order
                },
            };
            context.Orders.Add(order);
            orderDetails.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();

            order = new Order()
            {
                Customer = "Joe Smith",
                OrderDate = new DateTime(2014, 12, 25)
            };

            orderDetails=new List<OrderDetail>()
            {
                 new OrderDetail()
                {
                    Book = books[1],
                    Quantity = 1,
                    Order = order
                },
                new OrderDetail()
                {
                    Book = books[1],
                    Quantity = 1,
                    Order = order
                },
                new OrderDetail()
                {
                    Book = books[3],
                    Quantity = 12,
                    Order = order
                },
                 new OrderDetail()
                {
                    Book = books[4],
                    Quantity = 3,
                    Order = order
                }
            };

            context.Orders.Add(order);
            orderDetails.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}