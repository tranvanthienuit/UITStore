using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UITStore.Models;

namespace UITStore.Services
{
    public interface ICommentService
    {
        Task<CommentModel> AddComment(CommentRequest cmtRequest);
        Task<CommentByProduct> GetComment(Guid productId);
        Task<DeleteComment> DeleteComment(Guid id);
    }
}
