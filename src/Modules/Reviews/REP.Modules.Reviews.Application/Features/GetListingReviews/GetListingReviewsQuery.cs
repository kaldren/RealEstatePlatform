using REP.Modules.Accounts.Application.Contracts;
using REP.Modules.Accounts.Application.DTOs;
using REP.Shared.Mediator.Contracts;

namespace REP.Modules.Reviews.Application.Features.GetListingReviews;

public record GetListingReviewsQuery(Guid ListingId) : IRequest<IEnumerable<GetListingReviewsResponse>>;

public record GetListingReviewsQueryHandler : IRequestHandler<GetListingReviewsQuery, IEnumerable<GetListingReviewsResponse>>
{
    private readonly IReviewsRepository _reviewsRepository;
    private readonly IAccountsService _accountsService;

    public GetListingReviewsQueryHandler(IReviewsRepository reviewsRepository, IAccountsService accountsService)
    {
        _reviewsRepository = reviewsRepository;
        _accountsService = accountsService;
    }
    public async Task<IEnumerable<GetListingReviewsResponse>> Handle(GetListingReviewsQuery request, CancellationToken cancellationToken)
    {
        // Get reviews by listing id
        var reviews = await _reviewsRepository.GetReviewsByListingIdAsync(request.ListingId);

        if (reviews == null)
        {
            return Enumerable.Empty<GetListingReviewsResponse>();
        }

        var responses = new List<GetListingReviewsResponse>();
        AccountDto? author = null;

        // If there are reviews, get the author information by asking who is the author by author id
        foreach (var review in reviews)
        {
            if (author is null)
            {
                author = await _accountsService.GetAccountByIdAsync(review.AuthorId, cancellationToken);
            }

            responses.Add(new GetListingReviewsResponse(
                review.Id,
                review.ListingId,
                review.AuthorId,
                author.Name,
                review.Rating,
                review.Comment,
                review.CreatedAt));
        }

        return responses;
    }
}