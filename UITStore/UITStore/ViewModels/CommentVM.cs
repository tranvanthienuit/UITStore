using System;
using System.Collections.Generic;
using System.Text;
using UITStore.Models;
using UITStore.Services;

namespace UITStore.ViewModels
{
    public class CommentVM
    {
        public UserVM userVM = new UserVM();
        public bool AddNewComment(Guid ProductId, Guid UserId, int Rating, string Content )
        {
            CommentRequest cmt = new CommentRequest
            {
                productid = ProductId, userid = UserId, rating = Rating, content = Content
            };
            CommentModel result = CommentService.ServiceClientInstance.AddComment(cmt).Result;
            if (result.success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<DataComment> GetComments(Guid productId)
        {
            List<DataComment> listDataComment = new List<DataComment>();
            CommentByProduct result = CommentService.ServiceClientInstance.GetComment(productId).Result;
            if(result.success)
            {
                List<Comment> listComment = result.data;
                foreach(var item in listComment)
                {
                    User user = userVM.GetUserById(item.userid);
                    listDataComment.Add(new DataComment {id = item.id, productid = item.productid, userid = item.userid, username = user.username, avatar = user.avatar, rating = item.rating, content = item.content });
                }
                return listDataComment;
            } else
            {
                return null;
            }
        }
        public bool DeleteComment(Guid id)
        {
            DeleteComment result = CommentService.ServiceClientInstance.DeleteComment(id).Result;
            if (result.success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
