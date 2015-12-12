namespace PieVerse.BLL.Interfaces
{
    public interface IService
    {
        IAuthorService AuthorService { get; }

        IFirstLineService FirstLineService { get; }

        IPayverseService PayverseService { get; }

        ILikeService LikeService { get; }
    }
}
