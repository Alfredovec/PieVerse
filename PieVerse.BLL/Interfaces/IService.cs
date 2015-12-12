namespace PieVerse.BLL.Interfaces
{
    public interface IService
    {
        IAuthorService AuthorService { get; }

        IFirstLineService FirstLineService { get; }

        IPayverseService PieverseService { get; }

        ILikeService LikeService { get; }
    }
}
