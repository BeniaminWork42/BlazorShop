﻿// <copyright file="DeleteClotheCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.ClotheHandler
{
    public class DeleteClotheCommandHandler : IRequestHandler<DeleteClotheCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<DeleteClotheCommandHandler> _logger;

        public DeleteClotheCommandHandler(IApplicationDbContext dbContext, ILogger<DeleteClotheCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<RequestResponse> Handle(DeleteClotheCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Clothes
                    .TagWith(nameof(DeleteClotheCommandHandler))
                    .SingleOrDefault(d => d.Id == request.Id && d.IsActive == true);
                if (entity == null) throw new Exception("The clothe does not exists");

                entity.IsActive = false;

                _dbContext.Clothes.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.DeleteClotheCommand);
                return RequestResponse.Failure($"{ErrorsManager.DeleteClotheCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}
