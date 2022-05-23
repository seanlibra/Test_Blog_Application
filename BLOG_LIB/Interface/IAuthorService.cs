using BLOG_LIB.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_LIB.Interface
{
    /// <summary>
    /// 文章作者
    /// </summary>
    public interface IAuthorService
    {
        /// <summary>
        /// 新增作者
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <returns></returns>
        Task CreateAuthorAsync(string name, bool gender);

        /// <summary>
        /// 取得作者詳細資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Author> GetAuthorDetailAsync(int id);

        /// <summary>
        /// 更新作者
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <returns></returns>

        Task UpdateAuthorAsync(int id, string name, bool gender);

        /// <summary>
        /// 刪除作者
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task DeleteAuthorAsync(int id);


    }
}
