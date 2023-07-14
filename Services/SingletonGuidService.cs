namespace ServiceLifetime.Services
{
    public class SingletonGuidService:ISingeltonGuidService
    {
        private readonly Guid _id;

        public SingletonGuidService()
        {
            _id = Guid.NewGuid();
        }

        public string GetGuid()
        {
            return _id.ToString();
        }
        
    }
}
