﻿using HRMS.DTOs.RequestDtos;
using HRMS.DTOs.ResponseDtos;

namespace HRMS.Iservice
{
    public interface IUserAttendanceService
    {
        Task<UserAttendanceResponseDtos> AddAttendanceForUser(Guid UserId, UserAttendanceRequestDtos userAttendanceRequestDtos);
        Task<UserAttendanceResponseDtos> GetUserAttendanceByUserIdAndDate(Guid userId, DateTime date);
        Task<List<AttendanceReportDto>> GenerateUserAttendanceReportByUser(Guid userId, DateTime startDate, DateTime endDate);
        Task<List<UserAttendanceResponseDtos>> GetAllAttendanceByDate(DateTime date);
        Task<UserAttendanceResponseDtos> UpdateUserAttendance(Guid UserId, DateTime date, UserAttendanceRequestDtos userAttendanceRequestDtos);
    }
}
