using BLOG_LIB.Interface;
using BLOG_LIB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_LIB.Service
{
    public class AuthorService:IDisposable ,IAuthorService
    {
        private bool disposed = false;
        private readonly ApplicationDbContext _context;

        public AuthorService(ApplicationDbContext context)
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

        public async Task CreateAuthorAsync(string name , bool gender)
        {
            Author add = new Author
            {
                Name = name,
                Gender = gender
            };

            _context.Authors.Add(add);
            await _context.SaveChangesAsync();
        }

        public async Task<Author> GetAuthorDetailAsync(int id)
        {
            var entity = await _context.Authors.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception("找不到作者");
            }

            return entity;
        }

        public async Task UpdateAuthorAsync(int id, string name, bool gender)
        {
            var entity = await _context.Authors.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception("找不到作者");
            }


            entity.Name = name;
            entity.Gender = gender;

        }

        public async Task DeleteAuthorAsync(int id)
        {
            var entity = await _context.Authors.Where(p => p.Id == id).FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new Exception("找不到作者");
            }


            _context.Authors.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
