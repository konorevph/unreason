public interface ILock
{
    public void UpdateState();
    public bool IsOpened();
}
