using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Festifact;
using Festifact.Services;
using Festifact.Models;
using Moq;

namespace FestifactTests
{
    public class OrganisatorServiceTests
    {
        private readonly Mock<MockHttpClient> _mockHttpClient;
        private readonly OrganisatorService _organisatorService;

        public OrganisatorServiceTests()
        {
            _mockHttpClient = new Mock<MockHttpClient>();
            //_organisatorService = new OrganisatorService(_mockHttpClient.Object);
        }

        [Fact]
        public async Task GetOrganisatorsAsync_ReturnsListOfOrganisators()
        {
            // Arrange
            var expectedOrganisators = new List<Organisator>
            {
                new Organisator { Id = 1, Name = "Organisator 1" },
                new Organisator { Id = 2, Name = "Organisator 2" },
            };

            _mockHttpClient.Setup(client => client.GetAsync("/api/organisators"))
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(expectedOrganisators)
                });

            // Act
            var result = await _organisatorService.GetOrganisatorsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedOrganisators.Count, result.Count);
            Assert.Equal(expectedOrganisators[0].Name, result[0].Name);
            Assert.Equal(expectedOrganisators[1].Name, result[1].Name);
        }

        [Fact]
        public async Task CreateOrganisatorAsync_ReturnsOkStatusCode()
        {
            // Arrange
            var newOrganisator = new Organisator { Name = "New Organisator" };
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = JsonContent.Create(newOrganisator)
            };

            _mockHttpClient.Setup(client => client.PostAsJsonAsync("/api/organisators", newOrganisator))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _organisatorService.CreateOrganisatorAsync(newOrganisator);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }


        [Fact]
        public async Task UpdateOrganisatorAsync_ReturnsOkStatusCode()
        {
            // Arrange
            var existingOrganisator = new Organisator { Id = 1, Name = "Existing Organisator" };
            var updatedOrganisator = new Organisator { Id = 1, Name = "Updated Organisator" };
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = JsonContent.Create(updatedOrganisator)
            };

            _mockHttpClient.Setup(client => client.PutAsJsonAsync("/api/organisators/1", updatedOrganisator))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _organisatorService.UpdateOrganisatorAsync(existingOrganisator.Id.GetValueOrDefault(), updatedOrganisator);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

    }
}
