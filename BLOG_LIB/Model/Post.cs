using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace BLOG_LIB.Model
{
    public class Post
    {
        public int Id { get; set; }

        
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        [JsonIgnore]
        public Author Author { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        
    }
}
