using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Reviews.Application.Features.GetListingReviews;

public record GetListingReviewsQuery(Guid ListingId) : IRequest<IEnumerable<GetListingReviewsResponse>>;

public record GetListingReviewsQueryHandler : IRequestHandler<GetListingReviewsQuery, IEnumerable<GetListingReviewsResponse>>
{
    private readonly IReviewsRepository _repository;
    public GetListingReviewsQueryHandler(IReviewsRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<GetListingReviewsResponse>> Handle(GetListingReviewsQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _repository.GetReviewsByListingIdAsync(request.ListingId);

        if (reviews == null)
            {
            return Enumerable.Empty<GetListingReviewsResponse>();
        }

        return reviews.Select(review => new GetListingReviewsResponse(
            review.Id,
            review.ListingId,
            review.Rating,
            review.Comment,
            review.CreatedAt));
    }
}