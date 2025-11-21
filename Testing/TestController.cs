using Microsoft.AspNetCore.Mvc;
using TestGHA.Controllers;
using Xunit;

namespace Testing
{
    public class TestController
    {
        [Fact]
        public void Test_Index_GET_ReturnsViewResultNullModel()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewData.Model);
        }

        [Fact]
        public void Test_Index_POST_InvalidModelState()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index(null, null, null, null);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public void Test_Index_POST_ValidModelState()
        {
            // Arrange
            string presidentInput = "Donald Trump", playerInput = "Christiano Ronaldo", personInput = "Elon Musk", tennisInput = "Novak Djokovic";
            var controller = new HomeController();

            // Act
            var result = controller.Index(presidentInput, playerInput, personInput, tennisInput);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<string>(viewResult.ViewData.Model);
        }
    }
}
