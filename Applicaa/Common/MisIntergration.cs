using System.Collections.Generic;
using Common.DataModel;
using SIMSInterface;

namespace Common
{
    public static class MisCache
    {
        public static string UserToken;

        public static string UserEmail;

        public static bool IsImportExamResults;
        
        public static bool IsImportClasses;

        public static List<ClassesMappingItem> ClassesMapping;

        public static List<Student> SelectedStudents;

        public static List<StudentItem> Students;
    }
}
