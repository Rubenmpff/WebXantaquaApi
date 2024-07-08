using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebXantaquaApi.Infra.Data.Repositories.Interfaces;
using WebXantaquaApi.Services.Mapping.Dtos;
using WebXantaquaApi.Services.Services.Interfaces;

namespace WebXantaquaApi.Services.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _repository;

        public CommentService(IMapper mapper, ICommentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<List<CommentDto>> GetAll()
        {
            var comments = await _repository.GetAll();
            return _mapper.Map<List<CommentDto>>(comments);
        }

        public async Task<CommentDto> GetById(int id)
        {
            var comment = await _repository.GetById(id);
            if (comment == null)
            {
                throw new KeyNotFoundException("Comment not found.");
            }
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task<List<CommentDto>> GetCommentsByApprovalStatusAsync(bool isApproved)
        {
            var comments = await _repository.GetCommentsByApprovalStatusAsync(isApproved);
            return _mapper.Map<List<CommentDto>>(comments);
        }

        public async Task<CommentDto> Save(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            if (comment.Id > 0)
            {
                await _repository.UpdateAsync(comment);
            }
            else
            {
                await _repository.AddAsync(comment);
            }
            return _mapper.Map<CommentDto>(comment);
        }

        public async Task Delete(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _repository.DeleteAsync(comment);
        }
    }
}
