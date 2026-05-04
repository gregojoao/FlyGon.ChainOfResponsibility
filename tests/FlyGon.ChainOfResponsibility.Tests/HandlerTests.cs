using FluentAssertions;
using FlyGon.ChainOfResponsibility.Handlers;
using FlyGon.ChainOfResponsibility.Handlers.Contracts;
using Xunit;

namespace FlyGon.ChainOfResponsibility.Tests
{
    public class HandlerTests
    {
        private class TestHandler : Handler
        {
            private readonly string _expectedRequest;
            private readonly string _response;

            public TestHandler(string expectedRequest, string response)
            {
                _expectedRequest = expectedRequest;
                _response = response;
            }

            public override object? Handle(object request)
            {
                if (request?.ToString() == _expectedRequest)
                    return _response;
                return base.Handle(request);
            }
        }

        [Fact]
        public void Handle_WhenHandlerCanProcess_ShouldReturnResponse()
        {
            // Arrange
            var handler = new TestHandler("test", "handled");

            // Act
            var result = handler.Handle("test");

            // Assert
            result.Should().Be("handled");
        }

        [Fact]
        public void Handle_WhenHandlerCannotProcess_ShouldReturnNull()
        {
            // Arrange
            var handler = new TestHandler("test", "handled");

            // Act
            var result = handler.Handle("other");

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void SetNext_ShouldReturnNextHandler()
        {
            // Arrange
            var handler1 = new TestHandler("test1", "handled1");
            var handler2 = new TestHandler("test2", "handled2");

            // Act
            var result = handler1.SetNext(handler2);

            // Assert
            result.Should().BeSameAs(handler2);
        }

        [Fact]
        public void Handle_WithChain_ShouldPassToNextHandler()
        {
            // Arrange
            var handler1 = new TestHandler("test1", "handled1");
            var handler2 = new TestHandler("test2", "handled2");
            handler1.SetNext(handler2);

            // Act
            var result = handler1.Handle("test2");

            // Assert
            result.Should().Be("handled2");
        }

        [Fact]
        public void Handle_WithChain_FirstHandlerShouldHandleItsRequest()
        {
            // Arrange
            var handler1 = new TestHandler("test1", "handled1");
            var handler2 = new TestHandler("test2", "handled2");
            handler1.SetNext(handler2);

            // Act
            var result = handler1.Handle("test1");

            // Assert
            result.Should().Be("handled1");
        }

        [Fact]
        public void Handle_WithChain_WhenNoHandlerCanProcess_ShouldReturnNull()
        {
            // Arrange
            var handler1 = new TestHandler("test1", "handled1");
            var handler2 = new TestHandler("test2", "handled2");
            handler1.SetNext(handler2);

            // Act
            var result = handler1.Handle("test3");

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void SetNext_WithMultipleHandlers_ShouldChainCorrectly()
        {
            // Arrange
            var handler1 = new TestHandler("test1", "handled1");
            var handler2 = new TestHandler("test2", "handled2");
            var handler3 = new TestHandler("test3", "handled3");

            // Act
            handler1.SetNext(handler2).SetNext(handler3);
            var result = handler1.Handle("test3");

            // Assert
            result.Should().Be("handled3");
        }

        [Fact]
        public void Handle_WithNullRequest_ShouldReturnNull()
        {
            // Arrange
            var handler = new TestHandler("test", "handled");

            // Act
            var result = handler.Handle("nonmatching");

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void Handle_WithNullableRequest_ShouldHandleGracefully()
        {
            // Arrange
            var handler = new TestHandler("test", "handled");
            object? nullRequest = null;

            // Act
            var result = handler.Handle(nullRequest!);

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public void Handle_WithComplexChain_ShouldStopAtFirstMatch()
        {
            // Arrange
            var handler1 = new TestHandler("test1", "handled1");
            var handler2 = new TestHandler("test2", "handled2");
            var handler3 = new TestHandler("test2", "handled3"); // Same request as handler2
            handler1.SetNext(handler2).SetNext(handler3);

            // Act
            var result = handler1.Handle("test2");

            // Assert
            result.Should().Be("handled2"); // Should stop at handler2
        }

        [Fact]
        public void IHandler_Interface_ShouldBeImplementedCorrectly()
        {
            // Arrange
            IHandler handler = new TestHandler("test", "handled");

            // Act & Assert
            handler.Should().BeAssignableTo<IHandler>();
        }
    }
}
