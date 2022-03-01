namespace Features.Interfaces
{
    public interface IUpdate
    {
        bool Status();
        void ExecuteFrame(double elapsedMilliseconds);
    }
}