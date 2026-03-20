using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentLibrary2.Data;
using StudentLibrary2.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary2.Test.UnitTests.Pages.Book
{
    public class CreateModelTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void OnPost_ShouldReturnPage_WhenModelStateIsInvalid()
        {
            // Arrange
            var context = GetDbContext();
            var pageModel = new StudentLibrary2.Pages.Books.CreateModel(context);

            pageModel.ModelState.AddModelError("Title", "Required");

            // Act
            var result = pageModel.OnPost();

            // Assert
            object value = result.Should().BeOfType<PageResult>();
            context.Books.Count().Should().Be(0);
        }

        [Fact]
        public void OnPost_ShouldAddBookAndRedirect_WhenModelStateIsValid()
        {
            // Arrange
            var context = GetDbContext();
            var pageModel = new StudentLibrary2.Pages.Books.CreateModel(context);

            pageModel.Book = new StudentLibrary2.Model.Book
            {
                Title = "Test Book",
                Author = new Author { Name = "Author" },
                Year = 2000,
                Copies = 1
            };

            // Act
            var result = pageModel.OnPost();

            // Assert
            result.Should().BeOfType<RedirectToPageResult>();

            var redirect = result as RedirectToPageResult;
            redirect.PageName.Should().Be("Index");

            context.Books.Count().Should().Be(1);
            context.Books.First().Title.Should().Be("Test Book");
        }
    }
}
