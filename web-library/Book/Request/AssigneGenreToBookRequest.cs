using System.Text.Json.Serialization;

namespace web_library.Book.Request
{
    public class AssigneGenreToBookRequest
    {
        
        public ICollection<int> genres_ids { get; set; }
        [JsonIgnore] 
        public int book_id { get; set; }
    }
}
