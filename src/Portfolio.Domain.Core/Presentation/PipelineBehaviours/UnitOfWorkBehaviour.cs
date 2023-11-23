using MediatR;
using Portfolio.Domain.Core.Application.Abstractions;

namespace Portfolio.Domain.Core.Presentation.PipelineBehaviours;

public sealed class UnitOfWorkBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkBehaviour(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (IsNotCommand() || SkipSaving())
        {
            return await next();
        }

        TResponse response = await next();

        await _unitOfWork.CommitAsync(cancellationToken);

        return response;

    }

    private static bool IsNotCommand()
    {
        return !typeof(TRequest).Name.EndsWith("Command");
    }

    private static bool SkipSaving()
    {
        return typeof(TRequest) is SkipSavingAfterCommand;
    }
}