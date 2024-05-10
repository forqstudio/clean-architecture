using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}


public interface ICommand<TResponse> : IRequest<Result<TResponse>>, ICommand
{
}

public interface IBaseCommand
{
}
