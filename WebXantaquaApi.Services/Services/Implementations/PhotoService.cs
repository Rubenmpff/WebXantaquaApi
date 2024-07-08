using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebXantaquaApi.Infra.Data.Repositories.Interfaces;
using WebXantaquaApi.Services.Mapping.Dtos;
using WebXantaquaApi.Services.Services.Interfaces;

namespace WebXantaquaApi.Services.Services.Implementations
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository _photoRepository;
        private readonly IMapper _mapper;

        public PhotoService(IPhotoRepository photoRepository, IMapper mapper)
        {
            _photoRepository = photoRepository;
            _mapper = mapper;
        }

        public async Task<List<PhotoDto>> GetAllPhotosAsync()
        {
            var photos = await _photoRepository.GetAll();
            return _mapper.Map<List<PhotoDto>>(photos);
        }

        public async Task<PhotoDto> GetPhotoByIdAsync(int id)
        {
            var photo = await _photoRepository.GetById(id);
            return _mapper.Map<PhotoDto>(photo);
        }

        public async Task<List<PhotoDto>> GetPhotosByProjectIdAsync(int projectId)
        {
            var photos = await _photoRepository.GetByProjectId(projectId);
            return _mapper.Map<List<PhotoDto>>(photos);
        }

        public async Task<PhotoDto> AddPhotoAsync(PhotoDto photoDto)
        {
            var photo = _mapper.Map<Photo>(photoDto);
            await _photoRepository.AddAsync(photo);
            return _mapper.Map<PhotoDto>(photo);
        }

        public async Task<PhotoDto> UpdatePhotoAsync(PhotoDto photoDto)
        {
            var photo = _mapper.Map<Photo>(photoDto);
            await _photoRepository.UpdateAsync(photo);
            return _mapper.Map<PhotoDto>(photo);
        }

        public async Task DeletePhotoAsync(int id)
        {
            var photo = await _photoRepository.GetById(id);
            if (photo != null)
            {
                await _photoRepository.DeleteAsync(photo);
            }
        }
    }
}
