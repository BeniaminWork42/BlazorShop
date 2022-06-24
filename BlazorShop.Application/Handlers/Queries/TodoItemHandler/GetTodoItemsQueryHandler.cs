﻿// <copyright file="GetTodoItemsQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.TodoItemHandler
{
    public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, Result<TodoItemResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetTodoItemsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetTodoItemsQueryHandler(IApplicationDbContext dbContext, ILogger<GetTodoItemsQueryHandler> logger, IMapper mapper)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<Result<TodoItemResponse>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.TodoItems
                    .TagWith(nameof(GetTodoItemsQueryHandler))
                    .ProjectTo<TodoItemResponse>(_mapper.ConfigurationProvider)
                    .ToList();

                return Task.FromResult(new Result<TodoItemResponse>
                {
                    Successful = true,
                    Items = result ?? new List<TodoItemResponse>()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetTodoItemsQuery);
                return Task.FromResult(new Result<TodoItemResponse>
                {
                    Error = $"{ErrorsManager.GetTodoItemsQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
