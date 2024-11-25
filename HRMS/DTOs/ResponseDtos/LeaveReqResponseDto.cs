using HRMS.Entities;

namespace HRMS.DTOs.ResponseDtos
{
    public class LeaveReqResponseDto
    {
        public Guid Id { get; set; }
        public string ApplyDate { get; set; }
        public string Reason { get; set; }
        public string LeaveDate { get; set; }
        public string ReJoinDate { get; set; }
        public string? AproverId { get; set; }
        public int leaveCount { get; set; }
        public int AvailableLeaves { get; set; }
        public string? Comments { get; set; }
        public string status { get; set; } = "pending";
        public Guid usersId { get; set; }
        public Guid leaveTypeId {  get; set; }
        public UserLeaveResponseDtos? Users { get; set; }
       
    }
}
