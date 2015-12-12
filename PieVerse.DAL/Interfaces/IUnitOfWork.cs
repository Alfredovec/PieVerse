namespace PieVerse.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; }

        IPieverseRepository PieverseRepository { get; }

        IFirstLineRepository FirstLineRepository { get; }

        ILikeRepository LikeRepository { get; }

        void Save();
    }
}
