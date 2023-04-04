namespace Core.Interfaces.Configuration
{
    public interface IConfigurationHelper
    {
        public  T GetHost<T>(string Host);
    }
}
