using StudentLibrary2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentLibrary2.Test.UnitTests.Model
{
    public class BookTests
    {
        [Fact]
        public void Book_WithValidData_ShouldBeValid()
        {
            // Создаем объект книги с валидными значениями.
            var book = new Book
            {
                Name = "C# in Depth",     // Обязательное поле, строка < 100 символов
                Author = new Author { Name = "Пушкин"},      // Обязательное поле, строка < 100 символов
                Year = 2020,               // В пределах допустимого диапазона 1000–2100
            };

            // Создаем контекст валидации на основе объекта
            var context = new ValidationContext(book);

            // Сюда будут записаны ошибки валидации, если они есть
            var result = new List<ValidationResult>();

            // Проводим валидацию объекта с учетом всех атрибутов [Required], [Range] и т.п.
            var isValid = Validator.TryValidateObject(book, context, result, true);

            // Ожидаем, что валидация прошла успешно (все поля корректны)
            Assert.True(isValid);

            // Также убеждаемся, что список ошибок пуст
            Assert.Empty(result);
        }

        // Тест проверяет, что если не указать заголовок, то объект будет невалиден.
        [Fact]
        public void Book_WithInvalidYear_ShouldBeInvalid()
        {
            // Arrange
            var book = new Book
            {
                Title = "Test Book",
                Author = new Author { Name = "Пушкин" },
                Year = 12 // ❗ теперь это действительно ошибка
            };

            var context = new ValidationContext(book);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(book, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Год должен быть"));
        }
    }
}

