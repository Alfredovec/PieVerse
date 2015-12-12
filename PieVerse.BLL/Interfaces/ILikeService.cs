using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PieVerse.BLL.Interfaces
{
    public interface ILikeService
    {
        int Like(int pieverseId, string userName);
        bool IsLikedBy(string userName, int pieverseId);
        void DeleteLikesOf(int pieverseId);
    }
}
