using System.Collections.Generic;
using Common.AdmissionApi;
using Common.DataModel;
using RestSharp;
using RestSharp.Deserializers;

namespace Common.RestApi
{
    public class AdmissionStudentsClient : BaseClient
    {
        private const string LoginResource = "/graphql";

        //private const string query =
        //    "{ enrolledStudents( applicationFormId: 1 ) {id,application_reference_number,first_name,last_name,gender,birthday,form_group_name,email,phone_home,phone_mobile,postcode,address1,address2,when_moved_in,ethnicity,religion,first_language,home_language,nationality,country_of_birth,resident_UK_last_3yrs,resident_country,date_of_arrival,head_of_year,head_of_year_email,policy_data_protection,policy_term_condition,policy_home_school,unique_learner_number,unique_pupil_number,unique_candidate_number,parents_job,parents_UK_university,goal,hobbies,created_at,avatar,permission,current_progress,home_schooled,school_outside_UK,school_detail,enrolment_status,form_group_id,enrolled_by,all_policies_agree,group_id,current_year_tutor,gp_name,gp_contact,ref_attachment,gp_postcode,enrolled_date,university_note,passport_required,internal,student_id,username,application_status,school_year_id,imported_by_sims,application_form_id,sub_building_name,street,post_town,building_name,age,clazz_ids,clazzs{id,name,id,name,code,blocks{id,name,schedule,created_at,application_form_id}}} }";
        private const string query =
            "{ enrolledStudents( applicationFormId: 1 ) {id,application_reference_number, exam_results{board_code,level,subject_code,school,year,result,result_type,qan},first_name,last_name,gender,birthday,form_group_name,email,phone_home,phone_mobile,postcode,when_moved_in,ethnicity,religion,first_language,home_language,nationality,country_of_birth,resident_UK_last_3yrs,resident_country,date_of_arrival,head_of_year,head_of_year_email,policy_data_protection,policy_term_condition,policy_home_school,unique_learner_number,unique_pupil_number,unique_candidate_number,parents_job,parents_UK_university,goal,hobbies,created_at,avatar,permission,current_progress,home_schooled,school_outside_UK,school_detail,enrolment_status,form_group_id,enrolled_by,all_policies_agree,group_id,current_year_tutor,gp_name,gp_contact,ref_attachment,gp_postcode,enrolled_date,university_note,passport_required,internal,student_id,username,application_status,school_year_id,imported_by_sims,application_form_id,sub_building_name,street,post_town,building_name,age,clazz_ids,clazzs{id,name,id,name,code,blocks{id,name,schedule,created_at,application_form_id}}} }";


        public AdmissionStudentsClient(IDeserializer serializer, IErrorLogger errorLogger)
            : base(serializer, errorLogger, RestSharpConfig.BaseUrl)
        {

        }

        public List<StudentItem> GetStudents(string email, string token)
        {
            var result = new List<StudentItem>();

            var request = new RestRequest(LoginResource, Method.POST);
            request.AddQueryParameter("user_email", email);
            request.AddQueryParameter("user_token", token);
            request.AddQueryParameter("query", query);

            var data= Get<StudentResponse>(request);
            if (data != null)
            {
                result = data.data.enrolledStudents;
                return result;
            }

            return result;
        }
    }
}
