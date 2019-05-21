--LookupCache
[sims].[sta_pix_Lookups_MaintainCache_705]

--populate cache
[sims].[sta_pix_Groups_MaintainCache_730] 8404

--personal cache popuplate

sta_pix_lookups_maintain_PersonCache


-- save applicant detail
[sims].[adm_pix_ApplicationDetail_Save]

--aspect summary
asm_pix_AspectSummary_Populate_v7

SELECT TOP 100  * FROM sims.stud_student ss
where person_id = 8404

SELECT TOP 100  * FROM sims.stud_contact

SELECT * FROM sims.sims_person
where person_id = 8404

SELECT * FROM sims.sims_person
where forename LIKE '%ApplicantForename%'

SELECT * FROM sims.sims_students


--person id
SELECT * FROM sims.sims_person
where person_id = 447


-- school
SELECT * FROM [sims].[sims_school]

-- aspect

SELECT * FROM sims.asm_aspect

SELECT * from sims.sims_school
where school_name LIKE  '%Junior%'
/*
Main Application
SIMS.Processes.DocManagementCache.Populate();
      SIMS.Processes.LookupCache.Populate();
      SIMS.Processes.PersonCache.Populate();
      SIMS.Processes.ContactCache.Populate();
      SIMS.Processes.GroupCache.Populate();
      SIMS.Processes.DocManagementCache.Populate();
      UDFCache.Populate();
      SIMS.Processes.AgencyCache.Populate();
      SIMS.Processes.StudentCache.Populate();
      SchoolCache.Populate();
      Cache.Populate();
      SIMS.Processes.NurseryCareProvisionCache.Populate();
      this.PopulateLookups();
      this.populateCriteriaLookups();

*/


select * from sims.adm_application_school_history 