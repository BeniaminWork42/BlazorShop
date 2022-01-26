﻿namespace BlazorShop.Application.Handlers.Commands.OrderHandler
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, RequestResponse>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<UpdateOrderCommandHandler> _logger;

        public UpdateOrderCommandHandler(IApplicationDbContext dbContext, ILogger<UpdateOrderCommandHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RequestResponse> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = _dbContext.Orders.SingleOrDefault(d => d.Id == request.Id);
                if (entity == null) throw new Exception("The entity does not exists");

                entity.UserEmail = request.UserEmail;
                entity.OrderDate = request.OrderDate;
                entity.LineItems = request.LineItems;
                entity.AmountTotal = request.AmountTotal;

                _dbContext.Orders.Update(entity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return RequestResponse.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "There was an error updating the order");
                return RequestResponse.Error(new Exception("There was an error updating the order", ex));
            }
        }
    }
}
