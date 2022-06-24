﻿// <copyright file="GetUserSubscribersQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriberValidator
{
    public class GetUserSubscribersQueryValidator : AbstractValidator<GetUserSubscribersQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetUserSubscribersQueryValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
