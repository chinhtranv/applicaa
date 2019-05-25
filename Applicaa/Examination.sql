

---- ALL GRADE ----

select    [id] = asmg.grade_id,  --
		[gradeset_id] = asmgh.gradeset_id,
          [code] = asmg.title,
          [description] = asmg.description,
          [display_order] = asmg.rank_order,
		[active_status] = 1, 
          [start_date] = asmgh.start_date,
          [end_date] = asmgh.end_date
from sims.asm_gradeset_history asmgh
join sims.asm_grade asmg 
on asmg.gradeset_history_id = asmgh.gradeset_history_id
where exists (select 1 from sims.exam_level el where el.default_gradeset_id = asmgh.gradeset_id)
order by asmgh.gradeset_id, asmg.rank_order

--select all gradesets with Result Types
select [id]            = ags.gradeset_id
     , [code]          = ags.external_id 
      ,[description]   = ags.[name]
	  ,[active_status] = 1
    from sims.asm_gradeset ags
    join sims.sims_agency sac1
      on ags.module_id = sac1.agency_id
    join sims.sims_agency sac2
      on ags.supplier_id  = sac2.agency_id 
	  where sac1.agency_name='CES Examination Services' and ags.external_id like '%Result%'
     order by [description]



	 
/***********************************TABLE 11 To Load Census Qualfication Types**************************************************/

select	[id] = qualification_type_id
	   ,[code] = qualification_type
	   ,[description]
	   ,[active_status] = 1
from sims.census_qan_qualification_type
order by [description]



------------------------------------------------
-- populate external lookup
sims.exam_pix_ManageExternalExamResult_PopulateLookups


--resultset 0 subjects
exec sims.exam_pix_populate_ExternalResultsSubjects @qan, @acad_year

--resultset 1 levels
exec sims.exam_pix_populate_ExternalResultsLevels '10002431', 2018

--resultset 2 - Awarding body
exec  sims.exam_pix_populate_ExternalResultsAwardingbodies @qan, @acad_year

--resultset 3 - School History
exec  sims.exam_pix_get_school_history @person_id

----------------------------------------------

  SELECT * FROM sims.exam_board
				ORDER BY sims.exam_board.board_abbreviation

  SELECT * FROM sims.exam_qualification

  SELECT TOP 1000  * FROM sims.asm_result
  ORDER BY result_id DESC
  SELECT * FROM sims.asm_aspect aa WHERE aa.aspect_id=7024

  SELECT * FROM  sims.exam_level el
  join sims.exam_qualification EQ on el.qualification_id = EQ.qualification_id

  --subject
  SELECT * FROM sims.census_qan_discount_code

  --level
  SELECT * FROM  sims.exam_level


  ---
  -- EXAM Cache populated

  sims.exam_pix_ExamCache_Populate 2018

  SELECT TOP 1000 * FROM sims.exam_candidate e
  ORDER BY e.candidate_id DESC

  where  e.person_id IN  (12105 ,12107)


  -- Admit Appication

  [sims].[adm_pix_ApplicationStatus_Update]

  -- populate application

  [sims].[adm_pix_AdmitApplicantDetail_PopulateApplications] 1041, 3


   select * from sims.adm_application_status_category