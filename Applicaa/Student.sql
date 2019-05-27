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

SELECT TOP 100 * FROM sims.stud_student s
where s.person_id IN  (12105 ,12107)

---


SELECT TOP 100 * FROM sims.stud_student s
where s.person_id IN  (SELECT person_id FROM sims.sims_person p
							where p.forename LIKE '%Dang%')


--person id
SELECT * FROM sims.sims_person p
where p.forename like '%Dang%'


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
SELECT * FROM [sims].[adm_application_telephone]

select * from sims.adm_application_school_history 

Select * from sims.sims_telephone_device

SELECT * FROM sims.adm_application

SELECT * from sims.sims_telephone_location

-------------------------------------------------------------------
---- ASSESSMENT ------------------------------------



--Maintain aspect populate
sims.asm_pix_MaintainAspect_Populate_v7 447


-- Maintain grade set

asm_pix_MaintainGradeSet_Populate_v7
asm_pix_MaintainGradeSet_Save_v7
SELECT * from sims.asm_gradeset ag WHERE ag.gradeset_id = 12 -- JC C Forecast
SELECT * from sims.sims_agency sam


SELECT * FROM sims.asm_grade
-- list entity
-- aspect
-- gradeSet,
-- module,
-- supplier



-- Aspect
SELECT  * FROM sims.asm_aspect
--AspectSummary
 select   [aspect_id]= ava.aspect_id
           , [aspect_name] = ava.aspect_name
           , [aspect_type] = case (ava.aspect_type)
                                when 'R' then 'Age'
                                when 'C' then 'Comment'
                                when 'G' then 'Grade'
                                when 'I' then 'Marks-Integer'
                                when 'D' then 'Marks-Decimal'
                             end   
           , [column_heading]= ava.column_heading
           , [person_name] = ltrim(rtrim(coalesce(vp.forename+' ','')))
                             + ' ' + ltrim(rtrim(vp.surname))
						 ,[owner_id] = 	ava.creator_id
           , [module_id] =  ava.module_id 
					, [gradeset_name] =  sagr.name 
					,[supplier_id] = ava.supplier_id
			,[active] = ava.is_active
        from sims.asm_aspect ava
        join sims.sims_agency sag
							on sag.agency_id = ava.supplier_id
        join sims.sims_agency sag1
							 on sag1.agency_id = ava.module_id    
        left outer join sims.sims_person vp
							on vp.person_id = ava.creator_id
	    left join sims.asm_gradeset sagr
								on sagr.gradeset_id = ava.gradeset_id

-- Grade set Summary
select [id]            = ags.gradeset_id
       , [name]          = ags.[name]
       , [module_id]     = ags.module_id
       , [module]        = sac1.agency_name
       , [supplier_id]   = ags.supplier_id
       , [supplier]      = sac2.agency_name
        ,[external_id]   = ags.external_id ,
		sac1.agency_type_id
    from sims.asm_gradeset ags
    join sims.sims_agency sac1
      on ags.module_id = sac1.agency_id
     --and ((ags.module_id = @module_id) or (@module_id =0))
     --and ags.[name] like @gradeset_name + '%'
    join sims.sims_agency sac2
      on ags.supplier_id  = sac2.agency_id 
     --and sims.per_fnc_RemoveSpecialCharacters(sac2.agency_name) like @supplier_name + '%' 
     order by [name]

--
SELECT * FROM sims.sims_agency

SELECT * FROM [sims].[sims_agency_type]

----------

--gradeset agency module 
  select [gradeset_id]        = ag.gradeset_id
       , [module_id]         = ag.module_id
       , [module_name]       = sam.agency_name
       , [supplier_id]       = ag.supplier_id
       , [supplier_name]     = sas.agency_name
       , [name]              = ag.name
       , [default_name]      = ag.default_name
       , [notes]             = ag.notes
       , [default_notes]     = ag.default_notes
       , [external_id]       = ag.external_id
       , [last_import_date]  = convert(varchar(10), ag.last_import_date, 103)
       , [last_export_date]  = convert(varchar(10), ag.last_export_date, 103)
       , [create_date]       = convert(varchar(10), ag.create_date, 103)
       , [edit_date]         = convert(varchar(10), ag.edit_date, 103)
       , [is_version5] 		 = case when (select count(1) from sims.asm_aspect where gradeset_id = ag.gradeset_id and is_version5 = 'T') > 0 
								then 1 
								else 0 
							end 
    from sims.asm_gradeset ag
    join sims.sims_agency sam
      on ag.module_id = sam.agency_id
    
    join sims.sims_agency sas
      on ag.supplier_id  = sas.agency_id 
  
order by ag.name
	

	--get grades - values
    select [gradeset_history_id]=	agh.gradeset_history_id
		 , [grade_id]			=	ag.grade_id
		 , [grade]				=	ag.title
		 , [description]		=	ag.description
		 , [rank_order]			=	ag.rank_order
		 , [valueset_id]		=	avs.valueset_id
		 , [value_id]			=	av.value_id
		 , [value]				=	av.value_for_grade
		 , [temp_grade_id]		=	ag.grade_id
		 , [colour]				=   ISNULL(ag.colour,0)
		 , [is_used_in_mappings]   =   case when exists (
		  												select 1 
						                                        from sims.asm_assessment_mapping_grade_map amgm
						                                        where amgm.source_grade_id = ag.grade_id 
						                                        or amgm.dest_grade_id=ag.grade_id
						                              ) 						                          
															 
									      then 1
										  else 0
								    end
      from sims.asm_grade ag
inner join sims.asm_gradeset_history agh
	    on ag.gradeset_history_id = agh.gradeset_history_id
      
 left join sims.asm_valueset avs
	    on agh.gradeset_history_id = avs.gradeset_history_id
       and avs.is_default='T'
 left join sims.asm_value av 
	    on av.valueset_id = avs.valueset_id
       and av.grade_id = ag.grade_id
  order by agh.gradeset_history_id, ag.rank_order

  -- grade value set

  SELECT TOP 100 * FROM sims.asm_valueset
  where gradeset_history_id IN (12, 8358, 8359)

  --grade
  SELECT  * FROM sims.asm_grade g
  where gradeset_history_id IN (12, 8358, 8359)


  SELECT TOP 100 v.*,g.title FROM sims.asm_value v
  INNER JOIN sims.asm_grade g ON v.grade_id = g.grade_id

  where valueset_id IN (
		 SELECT valueset_id FROM sims.asm_valueset
			 where gradeset_history_id IN (12, 8358, 8359)
  )
  ---
   --get gradeset histories
  select [gradeset_history_id] = agh.gradeset_history_id
       , [gradeset_id]         = agh.gradeset_id
       , [start_date]          = agh.start_date
       , [end_date]            = agh.end_date
       , [is_used_in_mappings]   =   case when exists (
													select 1
															from sims.asm_gradeset gs	    
															inner join sims.asm_gradeset_history agh1
															on gs.gradeset_id = agh1.gradeset_id
															inner join sims.asm_grade g
															on g.gradeset_history_id = agh.gradeset_history_id
	  												        inner join 	sims.asm_assessment_mapping_grade_map amgm
	  												        on g.grade_id=amgm.source_grade_id
					                                        or g.grade_id=amgm.dest_grade_id
					                                        where agh1.gradeset_id = 12   -- JC C Forecast
					                                        and agh1.gradeset_history_id=agh.gradeset_history_id
						                              ) 						                          
															 
									     then 1
										 else 0
								    end
    from sims.asm_gradeset_history agh
   where agh.gradeset_id = 12 -- JC C Forecast
order by agh.start_date


SELECT * FROM sims.asm_result

SELECT * FROM sims.asm_resultset


SELECT * FROM sims.sims_agency WHERE sims.sims_agency.agency_id =26


select   [Resultset_id]     = resultset_id  
       , [Resultset_name]   = resultset_name   
       , [Locked]           = is_locked   
       , [DefaultName]      = default_name   
       , [Module_id]        = module_id  
       , [Supplier_id]      = supplier_id   
       , [Module_name]      = v1.agency_name    
       , [Supplier_name]    = v2.agency_name   
       , [Edit_date]        = edit_date
       , [External_id]      = rs.external_id
       , [Created_date]     = created_date  
       , [Last_import_date] = last_import_date  
       , [Last_export_date] = last_export_date  
       , [From]             = start_date    
       , [TO]               = end_date   
       , [is_active]		= rs.is_active 
       , [is_locked]		= rs.is_locked 
       , [lock_date]		= case isnull(rs.locked_by,0) when 0 then cast(floor(cast(getdate() as float)) as smalldatetime) else rs.lock_date end
       , [locked_by_name]	= sp.forename + ' ' + sp.surname --isnull(sp.forename,'') + ' '  + left(surname, 1) + isnull(left(sp.forename, 1), '') +rtrim(ltrim(upper(sp.surname)))
from sims.asm_resultset rs
  join  sims.sims_agency v1
    on v1.agency_id=rs.module_id 
      join  sims.sims_agency v2 
         on  v2.agency_id=rs.supplier_id
  left outer join sims.sims_person sp on rs.locked_by = sp.person_id
  where rs.resultset_id = 44 --January Exams 2005



  ---------------------

  ----

  SELECT * FROM sims.exam_board
				ORDER BY sims.exam_board.board_abbreviation

  SELECT * FROM sims.exam_qualification

  SELECT * FROM sims.asm_result

  SELECT * FROM sims.asm_aspect aa WHERE aa.aspect_id=7024

  ----
  -- Examination Browse Student
  --BY house : Hooke
  exec sims.exam_pix_BrowseExamStudents_GetStudents @surname='%',@forename='%',@year='%',@reg='%',@house='Hooke',@tier='%',@effective_date='2019-05-24 12:38:33.423',@roll_mode='Any',@show_photo='F',@use_dm='F'
  -- return all
  exec sims.exam_pix_BrowseExamStudents_GetStudents @surname='%',@forename='%',@year='%',@reg='%',@house='%',@tier='%',@effective_date='2019-05-24 12:38:33.423',@roll_mode='Any',@show_photo='F',@use_dm='F'

  --import Application
  sims.adm_pia_atf_import_application


  [sims].[sta_pix_SchoolCache_populate]


  ---
  ---FSM

  SELECT * FROM [sims].[sims_base_group_type]

  SELECT * FROM [sims].[sims_base_group]
  WHERE sims.sims_base_group.base_group_type_id = 60


  -----
  -- poplulate Student Cache : Phone Home, Phone Device
  [sims].[sta_pix_initialise_student_cache]


  SELECT TOP 1000 * FROM sims.sims_address

  SELECT TOP 1000 * FROM sims.sims_country sc


  SELECT TOP 1000  * FROM sims.stud_contact

  SELECT TOP 1000 * FROM sims.adm_application_relation

  -- save student information

  [sims].[sta_pix_EditStudentInformation_Save_705]