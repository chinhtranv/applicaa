using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIMS.Entities;
using SIMS.Processes;
using StudentCache = SIMS.Entities.StudentCache;

namespace SIMSInterface
{
    public class StudentClasses
    {
        public static void EditStudentClass()
        {
            var hostProcess = new EditStudentPLASCClassType();
            var classType = (StudentPLASCClassType) StudentCache.PLASCClassTypes.ItemByCode("Code");
            hostProcess.StudClassesTypes.Add(new StudentPLASCClass
            {

                ClassType = classType,
                PersonIDAttribute = { Value = 11},
              
            });
            hostProcess.SaveDetails("term", "year");
        }
    }
}
