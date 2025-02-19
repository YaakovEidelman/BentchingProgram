namespace BusinessLogicLayer
{
    public interface IDeleteable
    {
        Task Delete();
        string Name { get; }
    }
}
