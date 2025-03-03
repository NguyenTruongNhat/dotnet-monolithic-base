﻿using MonolithicBase.Contract.Abstractions.Message;

namespace MonolithicBase.Contract.Services.V1.Product;

public static class Command
{
    public record CreateProductCommand(string Name, decimal Price, string Description) : ICommand;

    public record UpdateProductCommand(Guid Id, string Name, decimal Price, string Description) : ICommand;

    public record DeleteProductCommand(Guid Id) : ICommand;
}
