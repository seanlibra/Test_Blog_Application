using BLOG_LIB.Model;
using BLOG_LIB.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_LIB.Interface
{
    /// <summary>
    ///  文章介面
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// 建立文章
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="authorId"></param>
        /// <returns></returns>
        Task CreatePostAsync(string title, string content ,int authorId);

        /// <summary>
        /// 取得所有文章
        /// </summary>
        /// <returns></returns>
        Task<List<PostListViewModel>> GetAllPostAsync();

        /// <summary>
        /// 更新文章
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="conent"></param>
        /// <returns></returns>

        Task UpdatePostAsync(int id, string title, string content , int authorId );

        /// <summary>
        /// 刪除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeletePostAsync(int id);

    }
}
