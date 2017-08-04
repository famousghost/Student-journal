using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCartWPF_GIT
{

    public enum AddStudentResult
    {
        FailedToAddStudent = 0,
        StudentIsExist,
        SuccessToAddStudent
    }

    public enum DeleteStudentResult
    {
        FailedToDeleteStudent = 0,
        StudentIsNotExist,
        SuccessToDeleteStudent
    }

    public enum UpdateStudentResult
    {
        FailedToUpdateStudent = 0,
        StudentIsNotExist,
        SuccessToUpdateStudent
    }


    public interface IStudentReposiotory
    {
        AddStudentResult AddStudent(Student studentToAdd);

        DeleteStudentResult DeleteEntity(Student studentToRemove);

        UpdateStudentResult UpdateEntity(Student studentToUpdate);

        IList<Student> getAllStudents();
    }

    public class StudentRepository : IStudentReposiotory
    {
        List<Student> studentsList;

        AddStudentResult addStudentResult;

        DeleteStudentResult deleteStudentResult;

        UpdateStudentResult updateStudentResult;
            
        public StudentRepository()
        {
            studentsList = new List<Student>();
        }

        public AddStudentResult AddStudent(Student studentToAdd)
        {
            if(studentsList.Contains(studentToAdd))
            {
                addStudentResult = AddStudentResult.StudentIsExist;
            }
            else
            {
                addStudentResult = AddStudentResult.SuccessToAddStudent;
                studentsList.Add(studentToAdd);
            }
            return addStudentResult;
        }

        public DeleteStudentResult DeleteEntity(Student studentToRemove)
        {
            if (!studentsList.Contains(studentToRemove))
            {
                deleteStudentResult = DeleteStudentResult.StudentIsNotExist;
            }
            else
            {
                deleteStudentResult = DeleteStudentResult.SuccessToDeleteStudent;
                studentsList.Remove(studentToRemove);
            }
            return deleteStudentResult;
        }

        public UpdateStudentResult UpdateEntity(Student studentToUpdate)
        {
            if (!studentsList.Contains(studentToUpdate))
            {
                updateStudentResult = UpdateStudentResult.StudentIsNotExist;
            }
            else
            {
                updateStudentResult = UpdateStudentResult.SuccessToUpdateStudent;
            }
            return updateStudentResult;
        }

        public string GetStudentAddMessage()
        {
            if(addStudentResult == AddStudentResult.FailedToAddStudent)
            {
                return "Nie można dodać studenta";
            }
            else if(addStudentResult == AddStudentResult.StudentIsExist)
            {
                return "Taki student już istnieje";
            }
            return "Udało się dodać studenta";
        }

        public IList<Student> getAllStudents()
        {
            return studentsList;
        }
    }
}
