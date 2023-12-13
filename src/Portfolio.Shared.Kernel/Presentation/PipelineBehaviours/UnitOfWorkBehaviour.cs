using System.Transactions;
using MediatR;
using Portfolio.Shared.Kernel.Application.Abstractions;

namespace Portfolio.Shared.Kernel.Presentation.PipelineBehaviours;

public sealed class UnitOfWorkBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkBehaviour(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (IsNotCommand() || SkipSaving(request))
        {
            return await next();
        }

        if (CheckIfShouldUseTransactionScope(request))
        {
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                TResponse response = await next();

                await _unitOfWork.CommitAsync(cancellationToken);
                
                transactionScope.Complete();
            
                return response;
            }
        }
        
        TResponse responseUOW = await next();

        await _unitOfWork.CommitAsync(cancellationToken);
        
        return responseUOW;
        
        

        

    }

    private static bool IsNotCommand()
    {
        return !typeof(TRequest).Name.EndsWith("Command");
    }

    private static bool SkipSaving(TRequest request)
    {
        return request is SkipSavingAfterCommand;
    }

    private static bool CheckIfShouldUseTransactionScope(TRequest request)
    {
        return request is UseTransactionScopeSaveLogic;
    }
}