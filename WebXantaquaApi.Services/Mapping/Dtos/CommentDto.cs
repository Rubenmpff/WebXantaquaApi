using System;

namespace WebXantaquaApi.Services.Mapping.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsApproved { get; set; }
        public int ProjectId { get; set; }
    }
}
