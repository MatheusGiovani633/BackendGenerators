namespace BackendGenerators.Auth
{
    using BackendGenerators.Interfaces;
    public class GuidRefreshTokenGenerator : IRefreshTokenGenerator
    {
        public string Generate() => Guid.NewGuid().ToString();
    }
}