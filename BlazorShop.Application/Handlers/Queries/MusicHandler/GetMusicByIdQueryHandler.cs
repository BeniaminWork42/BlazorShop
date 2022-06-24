﻿// <copyright file="GetMusicByIdQueryHandler.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Handlers.Queries.MusicHandler
{
    public class GetMusicByIdQueryHandler : IRequestHandler<GetMusicByIdQuery, Result<MusicResponse>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger<GetMusicByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetMusicByIdQueryHandler(IApplicationDbContext dbContext, ILogger<GetMusicByIdQueryHandler> logger, IMapper mapper)
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
        public Task<Result<MusicResponse>> Handle(GetMusicByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _dbContext.Musics
                    .TagWith(nameof(GetMusicByIdQueryHandler))
                    .ProjectTo<MusicResponse>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.Id == request.Id);

                return Task.FromResult(new Result<MusicResponse>
                {
                    Successful = true,
                    Item = result ?? new MusicResponse()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ErrorsManager.GetMusicByIdQuery);
                return Task.FromResult(new Result<MusicResponse>
                {
                    Error = $"{ErrorsManager.GetMusicByIdQuery}. {ex.Message}. {ex.InnerException?.Message}"
                });
            }
        }
    }
}
