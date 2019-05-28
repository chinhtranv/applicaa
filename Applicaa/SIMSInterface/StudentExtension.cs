using System;
using System.Data;
using System.Data.SqlClient;
using Common;
using SIMS.Processes;

namespace SIMSInterface
{
    public class StudentExtension : DatabaseCommandCreator
    {
        public StudentItem GetStudentByCriteria(string uln, string upn, string uci)
        {            
            if (string.IsNullOrEmpty(uln) &&
                string.IsNullOrEmpty(upn) &&
                string.IsNullOrEmpty(uci)
            )
            {
                return null;
            }
            
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.PopulateConnectionString()))
            {
                conn.Open();
                string sql = PopulateSql();
                var cmd = new SqlCommand(sql, conn) {CommandType = CommandType.Text};
                cmd.Parameters.AddWithValue("@unique_pupil_no", upn);
                cmd.Parameters.AddWithValue("@unique_learner_number", uln);
                cmd.Parameters.AddWithValue("@uci", uci);

                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.Read())
                {
                    return new StudentItem
                    {
                        PersonId = Int32.Parse(reader["person_id"].ToString()),
                        Surname = reader["surname"].ToString(),
                        Forename = reader["forename"].ToString(),
                        Upn = reader["upn"].ToString(),
                        Uln = reader["unique_learner_number"].ToString(),
                        Uci = reader["uci"].ToString()
                    };
                }

            }

            return null;
        }

        private static string PopulateSql()
        {
            return @"SELECT  [person_id]	= p.person_id,
		                p.surname,		
		                p.forename,
		                [dob]		= p.dob,
		                [admission_number]  = sh.admission_number,
                        [date_of_admission] = sh.start_date,
                        [date_of_leaving]   = sh.end_date,
		                [upn]		= s.unique_pupil_no,
		                [unique_Learner_Number]	 = uln.unique_learner_number,
		                [uci]        = c.uci
                from 	sims.sims_person p
                join 	sims.stud_student s
                on 	p.person_id = s.person_id
                join 	sims.stud_school_history sh
                on 	s.person_id = sh.person_id

                join 	sims.sims_school sc
                on	sc.school_id = sh.school_id
                and	sc.status = 'S'
                 
                left join sims.sims_person_unique_learner_number uln
							                on uln.person_id = s.person_id
                LEFT JOIN sims.exam_candidate c ON p.person_id = c.person_id
                where	sh.start_date = (select max(start_date) from sims.stud_school_history  
							                where person_id = s.person_id and school_id = sc.school_id)

                AND ( ( s.unique_pupil_no = @unique_pupil_no) OR 
	                  ( uln.unique_learner_number = @unique_learner_number) OR
	                  ( c.uci = @uci )
	                  )";
        }
    }
}
