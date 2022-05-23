using BLOG_LIB.Interface;
using BLOG_LIB.Model;
using BLOG_LIB.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_LIB.Service
{
    public class PostService : IDisposable , IPostService
    {
        private bool disposed = false;
        private readonly ApplicationDbContext _context;


        public PostService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


        public async Task CreatePostAsync(string name , string content , int authorId)
        {
            Post add = new Post
            {
                Name = name,
                Content = content,
                AuthorId = authorId
            };

            _context.Posts.Add(add);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PostListViewModel>> GetAllPostAsync()
        {
            List<PostListViewModel> entities = await _context.Posts.
                Select(p => new PostListViewModel { 
                    Id = p.Id,
                    Title = p.Name,
                    AuthorName = p.Author.Name,
                    AuthorId = p.Author.Id,
            } ).AsNoTracking().ToListAsync();

            return entities;

        }

        public async Task UpdatePostAsync(int id, string title, string content , int authorId)
        {
            var entity = await _context.Posts.Where(p => p.Id == id).FirstOrDefaultAsync();

                if (entity == null)
            {
                throw new Exception("找不到文章");
            }

            entity.Name = title;
            entity.Content = content;
            entity.AuthorId = authorId;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(int id)
        {
           var entity = await _context.Posts.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception("找不到文章");
            }

            _context.Posts.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
