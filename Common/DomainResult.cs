namespace Platform.Domain.Common
{
    public class DomainResult
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        protected DomainResult(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None)
                throw new InvalidOperationException();

            if (!isSuccess && error == Error.None)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Error = error;
        }

        public static DomainResult Success() => new(true, Error.None);
        public static DomainResult Failure(Error error) => new(false, error);
    }

    public class DomainResult<TValue> : DomainResult
    {
        private readonly TValue? _value;

        protected DomainResult(TValue? value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        public TValue Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException("The value of a failure result can not be accessed.");

        public static DomainResult<TValue> Success(TValue value) => new(value, true, Error.None);
        public new static DomainResult<TValue> Failure(Error error) => new(default, false, error);

        public static implicit operator DomainResult<TValue>(TValue value) => Success(value);
    }
}
