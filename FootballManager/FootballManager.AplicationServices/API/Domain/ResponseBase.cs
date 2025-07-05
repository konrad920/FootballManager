namespace FootballManager.AplicationServices.API.Domain
{
    public abstract class ResponseBase<T>
    {
        public T Data { get; set; }
    }
}
