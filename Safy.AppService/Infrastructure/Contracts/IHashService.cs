namespace Safy.AppService.Infrastructure.Contracts
{
    public interface IHashService
    {
        byte[] CreateSalt();
        string CreateHash(string value, byte[] salt);
    }
}