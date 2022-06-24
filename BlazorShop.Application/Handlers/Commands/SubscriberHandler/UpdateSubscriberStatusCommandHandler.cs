﻿// <copyright file="UpdateSubscriberStatusCommandHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Commands.SubscriberHandler
{
    public class UpdateSubscriberStatusCommandHandler : IRequestHandler<UpdateSubscriberStatusCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateSubscriberStatusCommandHandler> _logger;

        public UpdateSubscriberStatusCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateSubscriberStatusCommandHandler> logger)
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
        public async Task<RequestResponse> Handle(UpdateSubscriberStatusCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Subscribers
                    .TagWith(nameof(UpdateSubscriberStatusCommandHandler))
                    .FirstOrDefault(x => x.StripeSubscriberSubscriptionId == request.StripeSubscriberSubscriptionId);
                if (entity == null) throw new Exception("The subscriber does not exists");

                entity.Status = SubscriptionStatus.Inactive;

                _dbContext.Subscribers.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success(entity.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.UpdateSubscriberStatusCommand);
                return RequestResponse.Failure($"{ErrorsManager.UpdateSubscriberStatusCommand}. {ex.Message}. {ex.InnerException?.Message}");
            }
        }
    }
}
