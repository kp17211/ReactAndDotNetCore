using DotNetDemo.Controllers;
using DotNetDemo.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DotNetDemo.XUnitTest
{
    public class UnitTest
    {
        [Fact]
        public void CalculateSum_ShouldReturnSum()
        {
            RequestModel request = new RequestModel();
            request.Number1 = 20;
            request.Number2 = 20;

            var controller = new LogicController();
            var result = controller.CalculateSum(request);
            var okResult = (OkObjectResult)result;
            var responseModel = (ResponseModel)okResult.Value;
            Assert.NotNull(result);
            Assert.Equal(okResult.StatusCode, (int)HttpStatusCode.OK);
            Assert.Equal(40, responseModel.Sum);
        }

        [Fact]
        public void CalculateSum_ShouldReturnError()
        {
            RequestModel request = null;
            var controller = new LogicController();
            var result = controller.CalculateSum(request);
            Assert.NotNull(result);
            var okResult = (BadRequestObjectResult)result;
            Assert.Equal(okResult.StatusCode, (int)HttpStatusCode.BadRequest);
        }

        [Fact]
        public void CalculateSum_ShouldReturnWithNegativeValue()
        {
            RequestModel request = new RequestModel();
            request.Number1 = -20;
            request.Number2 = 10;
            var controller = new LogicController();
            var result = controller.CalculateSum(request);
            Assert.NotNull(result);
            var okResult = (OkObjectResult)result;
            Assert.NotNull(okResult);
            var responseModel = (ResponseModel)okResult.Value;          
            Assert.Equal(-10, responseModel.Sum);
        }

    }
}