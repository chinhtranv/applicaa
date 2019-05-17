--populate cache
[sims].[sta_pix_Groups_MaintainCache_730] 8404

-- save applicant detail
[sims].[adm_pix_ApplicationDetail_Save]


SELECT TOP 100  * FROM sims.stud_student ss
where person_id = 8404

SELECT TOP 100  * FROM sims.stud_contact

SELECT * FROM sims.sims_person
where person_id = 8404

SELECT * FROM sims.sims_person
where forename LIKE '%ApplicantForename%'

SELECT * FROM sims.sims_students