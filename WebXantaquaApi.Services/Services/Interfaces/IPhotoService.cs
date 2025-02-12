﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WebXantaquaApi.Services.Mapping.Dtos;

namespace WebXantaquaApi.Services.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<List<PhotoDto>> GetAllPhotosAsync();
        Task<PhotoDto> GetPhotoByIdAsync(int id);
        Task<List<PhotoDto>> GetPhotosByProjectIdAsync(int projectId);
        Task<PhotoDto> AddPhotoAsync(PhotoDto photoDto);
        Task<PhotoDto> UpdatePhotoAsync(PhotoDto photoDto);
        Task DeletePhotoAsync(int id);
    }
}
