using System;

namespace BusinessLogic.Infrastructure
{
    public class CustomException : Exception
    {
        public ErrorCode ErrorCode { get; set; }
        public CustomException(ErrorCode errorCode, string errorMessage) : base(errorMessage)
        {
            ErrorCode = errorCode;
        }
    }

    public enum ErrorCode
    {
        NotSupportedReportType = 0,
        WrongMarkAndIsStudentOnLectureCondition = 1
    }
}
