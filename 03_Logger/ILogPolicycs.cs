namespace NapilnikLogger
{
    public interface ILogPolicy
    {
        public bool IsAllowedWriteLog();
    }
}
