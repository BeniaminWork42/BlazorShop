﻿namespace BlazorShop.Application.Validators.SubscriberValidator
{
    public class UpdateSubscriberStatusCommandValidator : AbstractValidator<UpdateSubscriberStatusCommand>
    {
        public UpdateSubscriberStatusCommandValidator()
        {
            RuleFor(x => x.StripeSubscriberSubscriptionId)
                .MaximumLength(500).WithMessage("StripeSubscriberSubscriptionId maximum length exceeded")
                .NotEmpty().WithMessage("StripeSubscriberSubscriptionId must not be empty")
                .NotNull().WithMessage("StripeSubscriberSubscriptionId must not be null");
        }
    }
}
