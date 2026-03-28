using Microsoft.AspNetCore.SignalR;
using StudentLibrary2.Hubs;
using StudentLibrary2.Model;
using Moq;

namespace StudentLibrary2.Test.UnitTests.Hubs
{
    public class BookHubTests
    {
        [Fact]
        public async Task SendBookUpdate_ShouldSendMessageToAllClients()
        {
            // Arrange
            var hub = new BookHub();

            var clientsMock = new Mock<IHubCallerClients>();
            var clientProxyMock = new Mock<IClientProxy>();

            clientsMock.Setup(c => c.All).Returns(clientProxyMock.Object);

            hub.Clients = clientsMock.Object;

            var book = new Book
            {
                Title = "Test Book",
                Year = 2024,
                Copies = 1
            };

            // Act
            await hub.SendBookUpdate(book);

            // Assert
            clientProxyMock.Verify(
                c => c.SendCoreAsync(
                    "BookUpdated",
                    It.Is<object[]>(o => o.Length == 1 && o[0] == book),
                    default
                ),
                Times.Once
            );
        }
    }
}
