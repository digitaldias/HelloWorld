using HelloWorld.CrossCutting.Testing;
using HelloWorld.Domain.Contracts;
using Moq;
using Should;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorld.Business.UnitTests
{
    public class ExceptionHandlerTests : TestsFor<ExceptionHandler>
    {
        [Fact]
        public void Run_FunctionThrowsException_ReturnsDefaultOfReturningType()
        {
            // Arrange
            var randomException = RandomException;
            Func<double> throwingFunction = () => { throw randomException; };

            // Act
            var result = Instance.Run(throwingFunction);

            // Assert
            result.ShouldEqual(default(double));

        }


        [Fact]
        public void Run_FunctionThrowsExceptionAndLoggerIsInjected_TheExceptionIsLogged()
        {
            // Arrange
            var randomException = RandomException;
            Func<double> throwingFunction = () => { throw randomException; };

            // Act
            var result = Instance.Run(throwingFunction);

            // Assert
            GetMockFor<ILogger>().Verify(logger => logger.LogException(randomException), Times.Once());
        }



        [Fact]
        public void Run_FunctionThrowsExceptionLoggerIsNotInjected_TheExceptionIsNotLogged()
        {
            // Arrange
            var randomException = RandomException;
            Func<double> throwingFunction = () => { throw randomException; };
            Instance = new ExceptionHandler(null);

            // Act
            var result = Instance.Run(throwingFunction);

            // Assert
            GetMockFor<ILogger>().Verify(logger => logger.LogException(randomException), Times.Never());
        }


        [Fact]
        public void Run_FunctionRunsWithoutErrors_ReturnsResultOfFunction()
        {
            // Arrange
            var expectedResult = Guid.NewGuid().ToString();
            Func<string> niceFunction = () => expectedResult;

            // Act
            var actualResult = Instance.Run(niceFunction);

            // Assert
            actualResult.ShouldEqual(expectedResult);

        }


        [Fact]
        public void Run_FunctionIsNull_ResultIsDefaultOfReturningType()
        {
            // Arrange
            Func<string> nullFunction = null;

            // Act
            var result = Instance.Run(nullFunction);

            // Assert
            result.ShouldEqual(default(string));
        }


        [Fact]
        public async Task RunAsync_FunctionRunsWithoutError_ReturnsResultOfFunction()
        {
            // Arrange
            Func<Task<bool>> goodFunction = async () => {                
                return await Task.FromResult(true);
            };

            // Act
            var result = await Instance.RunAsync(goodFunction);

            // Assert
            result.ShouldEqual(true);
        }


        [Fact]
        public async Task RunAsync_FunctionThrowsException_ResultIsDefaultReturnType()
        {
            // Arrange
            Func<Task<bool>> badFunction = async () => {
                throw new Exception("I'm really bad");
                await Task.FromResult(true);
            };
            // Act
            var result = await Instance.RunAsync(badFunction);

            // Assert
            result.ShouldBeFalse();
        }


        private Exception RandomException
        {
            get { return new Exception(Guid.NewGuid().ToString()); }
        }
    }
}
