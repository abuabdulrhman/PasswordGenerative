namespace PasswordGenerative.Services.Internal
{
    public interface IUniqueNumberGeneratorService
    {
        public string GenerateUniqueNumbers(int length);
        public string GenerateUniqueNumbersNotStartWithZero(int length);
    }
}