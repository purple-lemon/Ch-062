﻿using AutoMapper;
using Model.DB;
using Model.DTO;
using System.Collections.Generic;
using Model.DB.Code;
using Model.DTO.CodeDTO;

namespace BAL.IoC
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
              : this("MyProfile")
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, options => options.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, options => options.MapFrom(src => src.Email));
                cfg.CreateMap<List<User>, List<UserDTO>>();

                cfg.CreateMap<Exercise, ExerciseDTO>().ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.TaskName, options => options.MapFrom(src => src.TaskName))
                .ForMember(dest => dest.TaskTextField, options => options.MapFrom(src => src.TaskTextField))
                .ForMember(dest => dest.TaskBaseCodeField, options => options.MapFrom(src => src.TaskBaseCodeField))
                .ForMember(dest => dest.TeacherId, options => options.MapFrom(src => src.TeacherId))
                .ForMember(dest => dest.CourseId, options => options.MapFrom(src => src.CourseId))
                .ForMember(dest => dest.Course, options => options.MapFrom(src => src.Course))
                .ForMember(dest => dest.IsDeleted, options => options.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.CreateDateTime, options => options.MapFrom(src => src.CreateDateTime))
                .ForMember(dest => dest.UpdateDateTime, options => options.MapFrom(src => src.UpdateDateTime));
                cfg.CreateMap<List<Exercise>, List<ExerciseDTO>>();

                cfg.CreateMap<Course, CourseDTO>().ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, options => options.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsActive, options => options.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.CreationDate, options => options.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.UserId, options => options.MapFrom(src => src.UserId));
                cfg.CreateMap<List<Course>, List<CourseDTO>>();

                cfg.CreateMap<UserCode, UserCodeDTO>().ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                    .ForMember(dest => dest.CodeText, options => options.MapFrom(src => src.CodeText))
                    .ForMember(dest => dest.ExerciseId, options => options.MapFrom(src => src.ExerciseId))
                    .ForMember(dest => dest.UserId, options => options.MapFrom(src => src.UserId))
                    .ForMember(dest => dest.Exercise, options => options.MapFrom(src => src.Exercise))
                    .ForMember(dest => dest.CodeErrors, options => options.MapFrom(src => src.CodeErrors))
                    .ForMember(dest => dest.CodeResults, options => options.MapFrom(src => src.CodeResults))
                    .ForMember(dest => dest.User, options => options.MapFrom(src => src.User));
                cfg.CreateMap<List<UserCode>, List<UserCodeDTO>>();

                cfg.CreateMap<CodeResult, CodeResultDTO>()
                    .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Code, options => options.MapFrom(src => src.Code))
                    .ForMember(dest => dest.CodeId, options => options.MapFrom(src => src.CodeId))
                    .ForMember(dest => dest.Result, options => options.MapFrom(src => src.Result));
                cfg.CreateMap<List<CodeResult>, List<CodeResultDTO>>();

                cfg.CreateMap<CodeError, CodeErrorDTO>()
                    .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Code, options => options.MapFrom(src => src.Code))
                    .ForMember(dest => dest.CodeId, options => options.MapFrom(src => src.CodeId))
                    .ForMember(dest => dest.Result, options => options.MapFrom(src => src.Result));
                cfg.CreateMap<List<CodeError>, List<CodeErrorDTO>>();

                cfg.CreateMap<CodeHistory, CodeHistoryDTO>()
                    .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Code, options => options.MapFrom(src => src.Code))
                    .ForMember(dest => dest.CodeId, options => options.MapFrom(src => src.CodeId))
                    .ForMember(dest => dest.CodeText, options => options.MapFrom(src => src.CodeText));
                cfg.CreateMap<List<CodeHistory>, List<CodeHistoryDTO>>();

                cfg.CreateMap<TestCase, TestCaseDTO>()
                   .ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id))
                   .ForMember(dest => dest.ExerciseDTOId, options => options.MapFrom(src => src.ExerciseId))
                   .ForMember(dest => dest.UserDTOId, options => options.MapFrom(src => src.UserId))
                   .ForMember(dest => dest.InputData, options => options.MapFrom(src => src.InputData))
                   .ForMember(dest => dest.OutputData, options => options.MapFrom(src => src.OutputData))
                   .ForMember(dest => dest.Exercise, options => options.MapFrom(src => src.Exercise))
                   .ForMember(dest => dest.User, options => options.MapFrom(src => src.User));
                cfg.CreateMap<List<TestCase>, List<TestCaseDTO>>();
            });
        }

        protected AutoMapperProfileConfiguration(string profileName)
            : base(profileName)
        {

        }
    }
}