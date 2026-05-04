# FlyGon.ChainOfResponsibility

[![.NET](https://img.shields.io/badge/.NET-10.0-blue.svg)](https://dotnet.microsoft.com/download)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)
[![NuGet](https://img.shields.io/badge/nuget-v2.0.0-blue.svg)](https://www.nuget.org/packages/FlyGon.ChainOfResponsibility)

A simple and elegant implementation of the Chain of Responsibility design pattern for .NET 10.

## 📦 Installation

```bash
dotnet add package FlyGon.ChainOfResponsibility
```

## 🚀 Quick Start

```csharp
using FlyGon.ChainOfResponsibility.Handlers;

// Create your custom handlers
class MonkeyHandler : Handler
{
    public override object? Handle(object request)
    {
        if ((request as string) == "Banana")
            return $"Monkey: I'll eat the {request}.\n";
        return base.Handle(request);
    }
}

class SquirrelHandler : Handler
{
    public override object? Handle(object request)
    {
        if (request.ToString() == "Nut")
            return $"Squirrel: I'll eat the {request}.\n";
        return base.Handle(request);
    }
}

// Chain the handlers
var monkey = new MonkeyHandler();
var squirrel = new SquirrelHandler();
monkey.SetNext(squirrel);

// Use the chain
var result = monkey.Handle("Nut");
Console.WriteLine(result); // Output: Squirrel: I'll eat the Nut.
```

## 📖 Documentation

### IHandler Interface

The `IHandler` interface defines the contract for all handlers:

```csharp
public interface IHandler
{
    IHandler SetNext(IHandler handler);
    object? Handle(object request);
}
```

### Handler Base Class

The `Handler` abstract class provides the base implementation:

```csharp
public abstract class Handler : IHandler
{
    public IHandler SetNext(IHandler handler);
    public virtual object? Handle(object request);
}
```

## 🎯 Features

- ✅ Simple and intuitive API
- ✅ Fully compatible with .NET 10
- ✅ Nullable reference types support
- ✅ Comprehensive unit tests
- ✅ Well documented code
- ✅ Fluent interface for chaining handlers

## 🧪 Testing

The project includes comprehensive unit tests with 100% coverage:

```bash
dotnet test
```

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👤 Author

**João Greco** - [Greco Labs](https://github.com/grecojoao)

## 🤝 Contributing

Contributions, issues, and feature requests are welcome!

## ⭐ Show your support

Give a ⭐️ if this project helped you!
