namespace KitchenRouter.Application.Result
{
    public class ErrorResult : Result
    {
        public IReadOnlyCollection<Error> Errors { get; }

        public ErrorResult(IReadOnlyCollection<Error> errors) 
        {
            IsSuccess = false;
            Errors = errors ?? Array.Empty<Error>();
        }
    }
}
