namespace BusinessLogic.Interfaces
{
    public interface IReportService
    {
        string CreateReportByStudent(string studentName, string studentSurname, int reportType);

        string CreateReportBySubject(string subjectName, int reportType);
    }
}
