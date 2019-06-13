using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataModel
{
    public class StudentResponse
    {
        public StudentData data { get; set; }

    }

    public class StudentData
    {
        public List<StudentItem> enrolledStudents { get; set; }
    }

    public class StudentItem
    {
        public int id { get; set; }
        public bool selected { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string age { get; set; }
        public string application_reference_number { get; set; }

        public string class_list
        {
            get
            {

                if (this.clazzs != null || clazzs.Any())
                    return string.Join(", ", clazzs.Select(x => x.name).ToList());
                return string.Empty;
            }
        }

        public List<StudentClass> clazzs { get; set; }
    }

    public class StudentClass
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
    }
}
/*
 *
 *
 *
 * {
                        "id": "385",
                        "name": "Dance B",
                        "code": "Dance B",
                        "blocks": [
                            {
                                "id": "2",
                                "name": "B",
                                "schedule": null,
                                "created_at": "17 Oct 2017",
                                "application_form_id": 1
                            }
                        ]
                    },


 {
                "id": "182",
                "application_reference_number": "999-2018-09-K-000182",
                "first_name": "Cyrus",
                "last_name": "Weimann",
                "gender": "Male",
                "birthday": "05 Oct 2000",
                "form_group_name": "13.V",
                "email": "test80@student.com",
                "phone_home": "86742471485",
                "phone_mobile": "43726305581",
                "postcode": "SW6 4HA",
                "address1": "7749 Gladyce Road",
                "address2": null,
                "when_moved_in": "14 Sep 2015",
                "ethnicity": "ABAN",
                "religion": "GR",
                "first_language": "ENG",
                "home_language": "ENG",
                "nationality": "NL",
                "country_of_birth": "Mozambique",
                "resident_UK_last_3yrs": true,
                "resident_country": null,
                "date_of_arrival": null,
                "head_of_year": "Demo",
                "head_of_year_email": "demo@ulas.co.uk",
                "policy_data_protection": false,
                "policy_term_condition": false,
                "policy_home_school": true,
                "unique_learner_number": "2905740333",
                "unique_pupil_number": "7306143637",
                "unique_candidate_number": "6963795088",
                "parents_job": "Hospitality Consultant",
                "parents_UK_university": "No",
                "goal": "Aliquam sapiente non ad quam architecto voluptatem dignissimos.",
                "hobbies": "Et ut suscipit dolor quibusdam adipisci.",
                "created_at": "05 Oct 2017",
                "avatar": "/uploads/demo/student/avatar/182/girl-5.png",
                "permission": "Staff",
                "current_progress": "5",
                "home_schooled": "false",
                "school_outside_UK": false,
                "school_detail": null,
                "enrolment_status": 0,
                "form_group_id": 0,
                "enrolled_by": 1,
                "all_policies_agree": true,
                "group_id": 3,
                "current_year_tutor": null,
                "gp_name": "Crystal Balistreri Sr.",
                "gp_contact": "25616909176",
                "ref_attachment": "",
                "gp_postcode": "W3J 9UE",
                "enrolled_date": "02 May 2018",
                "university_note": "",
                "passport_required": false,
                "internal": true,
                "student_id": null,
                "username": null,
                "application_status": 0,
                "school_year_id": 1,
                "imported_by_sims": false,
                "application_form_id": 1,
                "sub_building_name": "Flat 4",
                "street": 0,
                "post_town": 0,
                "building_name": 0,
                "clazz_ids": [
                    "385",
                    "15",
                    "8"
                ],
                "clazzs": [
                    {
                        "id": "385",
                        "name": "Dance B",
                        "code": "Dance B",
                        "blocks": [
                            {
                                "id": "2",
                                "name": "B",
                                "schedule": null,
                                "created_at": "17 Oct 2017",
                                "application_form_id": 1
                            }
                        ]
                    },
                    {
                        "id": "15",
                        "name": "12Sociology",
                        "code": "12SocC",
                        "blocks": [
                            {
                                "id": "3",
                                "name": "C",
                                "schedule": null,
                                "created_at": "17 Oct 2017",
                                "application_form_id": 1
                            }
                        ]
                    },
                    {
                        "id": "8",
                        "name": "12BusinessA",
                        "code": "12BusA",
                        "blocks": [
                            {
                                "id": "4",
                                "name": "D",
                                "schedule": null,
                                "created_at": "17 Oct 2017",
                                "application_form_id": 1
                            }
                        ]
                    }
                ]
            },
 *
 */
