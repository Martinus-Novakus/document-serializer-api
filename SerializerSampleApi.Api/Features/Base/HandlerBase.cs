using AutoMapper;
using FluentValidation;
using MediatR;

namespace SerializerSampleApi.Api.Features;

public abstract class HandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse> 
{
    protected readonly IValidator<TRequest> _validator;
    protected readonly ILogger _logger;
    protected readonly IMapper _mapper;

    protected HandlerBase(
        IValidator<TRequest> validator,
        ILogger logger,
        IMapper mapper
    )
    {
        _validator = validator;
        _logger = logger;
        _mapper = mapper;
    }

    protected abstract Task<TResponse> HandleInternal(TRequest request, CancellationToken cancellationToken);

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        _logger.LogInformation("Handling request of type");

        return await HandleInternal(request, cancellationToken);
    }
}

public abstract class HandlerBase<TRequest> : IRequestHandler<TRequest> where TRequest : IRequest 
{
    protected readonly IValidator<TRequest> _validator;
    protected readonly ILogger _logger;
    protected readonly IMapper _mapper;

    protected HandlerBase(
        IValidator<TRequest> validator,
        ILogger logger,
        IMapper mapper
    )
    {
        _validator = validator;
        _logger = logger;
        _mapper = mapper;
    }

    protected abstract Task HandleInternal(TRequest request, CancellationToken cancellationToken);

    public async Task Handle(TRequest request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);
        _logger.LogInformation("Handling the incoming request: {request}", request);

        await HandleInternal(request, cancellationToken);
    }
}