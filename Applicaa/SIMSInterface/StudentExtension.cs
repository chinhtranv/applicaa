using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common;
using SIMS.Processes;

namespace SIMSInterface
{
    public class StudentExtension : DatabaseCommandCreator
    {

        public List<StudentItem> GetStudentsByRefernces(List<string> refNumers)
        {
            var result = new List<StudentItem>();

            using (SqlConnection conn = new SqlConnection(DatabaseHelper.PopulateConnectionString()))
            {
                if (!conn.IsAvailable())
                {
                    Log.Info("Could not connect to SIMS database server. Please verify the connection string value ...");
                    throw new System.Exception("The connection string is not correct ...");
                }
                conn.Open();
                string sql = ReferenceSql(refNumers);
                var cmd = new SqlCommand(sql, conn) { CommandType = CommandType.Text };
              
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while(reader.Read())
                {
                    var stu = new StudentItem
                    {
                        PersonId = Int32.Parse(reader["person_id"].ToString()),
                        Surname = reader["surname"].ToString(),
                        Forename = reader["forename"].ToString(),                       
                        AdmissionNumber = reader["admission_number"].ToString(),
                        Reference = reader["reference"].ToString()
                    };
                    result.Add(stu);
                }

            }

            return result;
        }


        public StudentItem GetStudentByCriteria(string uln, string upn, string uci)
        {      
            //validate the inputs
            if (string.IsNullOrEmpty(uln) &&
                string.IsNullOrEmpty(upn) &&
                string.IsNullOrEmpty(uci)
            )
            {
                return null;
            }
            
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.PopulateConnectionString()))
            {
                if (!conn.IsAvailable())
                {
                    Log.Info("Could not connect to SIMS database server. Please verify the connection string value ...");
                    throw new System.Exception("The connection string is not correct ...");
                }
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
                        Uci = reader["uci"].ToString(),
                        AdmissionNumber = reader["admission_number"].ToString()
                    };
                }

            }

            return null;
        }

        private static string ReferenceSql(List<string> refNumers)
        {
            string refValue = "";
            int i = 1;
            foreach (var r in refNumers)
            {
                if (i != refNumers.Count)
                    refValue = refValue + string.Format("'{0}',", r);
                else
                {
                    refValue = refValue + string.Format("'{0}'", r);
                }

                i++;
            }

            string sql = @"SELECT 
		                        a.person_id,		
		                        sh.admission_number,
		                        p.surname,		
		                        p.forename,
		                        a.reference
                          FROM sims.adm_application a
			                        JOIN sims.stud_student s ON a.person_id = s.person_id
			                        join 	sims.stud_school_history sh
                                        on 	s.person_id = sh.person_id
			                        JOIN sims.sims_person p ON s.person_id = p.person_id
                          WHERE a.reference IN ("+ refValue + " )";
            return sql;
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
/*
 *  SELECT 
		a.person_id,		
		sh.admission_number,
		p.surname,		
		p.forename,
		a.reference
  FROM sims.adm_application a
			JOIN sims.stud_student s ON a.person_id = s.person_id
			join 	sims.stud_school_history sh
                on 	s.person_id = sh.person_id
			JOIN sims.sims_person p ON s.person_id = p.person_id
  WHERE a.reference IN ('999-2018-09-K-000104',
						 '999-2018-09-K-000116',
						 '999-2018-09-K-001452',
						 '999-2018-09-K-000714')
 *
 */
