using PieVerse.DomainModel.Entities;

namespace PieVerse.BLL.Interfaces
{
    public interface IAuthorService
    {
        void CreateAuthor(Author author);
        Author GetAuthor(string userName);
    }
}
