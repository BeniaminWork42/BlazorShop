﻿namespace BlazorShop.Application.Handlers.Commands.AppUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, RequestResponse>
    {
        private readonly IAppUserService _AppUserService;

        public UpdateUserCommandHandler(IAppUserService AppUserService)
        {
            _AppUserService = AppUserService;
        }

        public async Task<RequestResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _AppUserService.UpdateUserAsync(request);
                return result;
            }
            catch (Exception ex)
            {
                return RequestResponse.Error(new Exception("There was an error while updating the user", ex));
            }
        }
    }
}
