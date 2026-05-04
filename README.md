# FlyGon.ChainOfResponsibility

[![Build and Test](https://github.com/grecojoao/FlyGon.ChainOfResponsibility/actions/workflows/build-and-test.yml/badge.svg)](https://github.com/grecojoao/FlyGon.ChainOfResponsibility/actions/workflows/build-and-test.yml)
[![NuGet](https://img.shields.io/nuget/v/FlyGon.ChainOfResponsibility.svg)](https://www.nuget.org/packages/FlyGon.ChainOfResponsibility/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/FlyGon.ChainOfResponsibility.svg)](https://www.nuget.org/packages/FlyGon.ChainOfResponsibility/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A simple and elegant implementation of the Chain of Responsibility design pattern for .NET 10.

## 📦 Installation

Install via NuGet Package Manager:

```bash
dotnet add package FlyGon.ChainOfResponsibility
```

Or via Package Manager Console:

```powershell
Install-Package FlyGon.ChainOfResponsibility
```

## 🚀 Features

- ✅ Simple and intuitive API
- ✅ Fully compatible with .NET 10
- ✅ Nullable reference types support
- ✅ Comprehensive unit tests
- ✅ Well documented code
- ✅ MIT License

## 📖 Usage

### Basic Example

```csharp
using FlyGon.ChainOfResponsibility.Handlers;

// Create custom handlers
class MonkeyHandler : Handler
{
    public override object? Handle(object request)
    {
        if ((request as string) == "Banana")
            return $"Monkey: I'll eat the {request}.";
        return base.Handle(request);
    }
}

class SquirrelHandler : Handler
{
    public override object? Handle(object request)
    {
        if (request.ToString() == "Nut")
            return $"Squirrel: I'll eat the {request}.";
        return base.Handle(request);
    }
}

class DogHandler : Handler
{
    public override object? Handle(object request)
    {
        if (request.ToString() == "MeatBall")
            return $"Dog: I'll eat the {request}.";
        return base.Handle(request);
    }
}

// Setup the chain
var monkey = new MonkeyHandler();
var squirrel = new SquirrelHandler();
var dog = new DogHandler();

monkey.SetNext(squirrel).SetNext(dog);

// Use the chain
var result = monkey.Handle("Banana");
Console.WriteLine(result); // Output: Monkey: I'll eat the Banana.
```

## 🏗️ How It Works

The Chain of Responsibility pattern allows you to pass requests along a chain of handlers. Each handler decides either to process the request or to pass it to the next handler in the chain.

### Key Components

- **IHandler**: Interface that defines the contract for handlers
- **Handler**: Abstract base class that implements the chain logic
- **SetNext()**: Method to link handlers together
- **Handle()**: Method to process requests or pass them along

## 🧪 Testing

The library includes comprehensive unit tests with 100% code coverage:

```bash
dotnet test
```

## 📝 Requirements

- .NET 10.0 or higher

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👤 Author

**João Greco**
- Company: Greco Labs
- GitHub: [@grecojoao](https://github.com/grecojoao)

## 🔗 Links

- [NuGet Package](https://www.nuget.org/packages/FlyGon.ChainOfResponsibility/)
- [GitHub Repository](https://github.com/grecojoao/FlyGon.ChainOfResponsibility)
- [Report Issues](https://github.com/grecojoao/FlyGon.ChainOfResponsibility/issues)

## 📊 Version History

### 2.0.0
- Updated to .NET 10
- Added nullable reference types support
- Added comprehensive unit tests
- Updated to latest dependencies
- Company updated to Greco Labs

### 1.0.1
- Added documentation
- Initial stable release
