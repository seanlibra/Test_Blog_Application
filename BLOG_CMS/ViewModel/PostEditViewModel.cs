using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLOG_CMS.ViewModel
{
    public class PostEditViewModel
    {

        public int AuthorId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
