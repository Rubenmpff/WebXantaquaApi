﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebKrpcApi.Services.Mapping.Dtos;

namespace WebKrpcApi.Services.Services.Interfaces
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetAll();
        Task<CommentDto> GetById(int id);
        Task<List<CommentDto>> GetCommentsByApprovalStatusAsync(bool isApproved);
        Task<CommentDto> Save(CommentDto commentDto);
        Task Delete(CommentDto commentDto);
    }
}
