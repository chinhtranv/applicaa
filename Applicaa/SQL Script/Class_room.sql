exec sims.currpt_pix_stud_CategoryDetails_Load @load_category=1,@categoryXML='<?xml version="1.0" encoding="ISO-8859-1"?><data> <row table_number=''0'' category_code=''BasicDetails'' /></data>',@effective_date='2019-06-01 00:00:00',@reference_date='2019-06-01 00:00:00',@owner_id=1,@time='08:50:00',@studentsXML=NULL

-- Populate all grouping information for the class list details on an effective date.
exec sims.currpt_pix_class_list_grouping_options_load @effective_date='2019-06-01 00:00:00',@student_ids='<?xml version="1.0" encoding="ISO-8859-1"?><data></data>'


EXEC sims.currpt_pia_class_room_details_load  @effective_date='2001-09-01 00:00:00'

EXEC sims.currpt_pia_all_classes_details_load @effective_date='2001-09-01 00:00:00'

EXEC sims.currpt_pia_get_period_information_details @effective_date='2001-09-01 00:00:00'


--- get home school
SELECT *
 FROM sims.sims_school  
          WHERE STATUS = 'S' 



-- Get all classes data   
        SELECT  [id] = bg.base_group_id  
              ,[code] = bg.short_name  
              ,[description] = bg.description                                      
         FROM sims.sims_base_group bg  
        JOIN  sims.sims_base_group_type bgt  
           ON bgt.base_group_type_id= bg.base_group_type_id  
          AND bgt.code='class'  
          AND bg.populate_mode = 'R'    
        JOIN sims.curr_destinationgroup cdg on bg.base_group_id = cdg.base_group_id 
		--AND @effective_date BETWEEN cdg.start_date AND cdg.end_date
        /*  
          AND EXISTS( SELECT 1 from sims.curr_class_period cp   
                       WHERE cp.base_group_id = bg.base_group_id   
                         AND ISNULL(cp.start_date, @effective_date) <= @effective_date  
                         AND ISNULL(cp.end_date, @effective_date) >= @effective_date  
                    ) 
        */   
        JOIN sims.curr_scheme cs ON cdg.scheme_id = cs.scheme_id    
        LEFT JOIN sims.curr_segment_tier cst ON cs.cycle_segment_id = cst.cycle_segment_id 
		--AND cst.base_group_id = @tier_id
        --WHERE cst.base_group_id = @tier_id OR @tier_id = 0 OR cs.cycle_segment_id IS NULL
         where bg.short_name LIKE '10A/Mu1'
       ORDER BY bg.base_group_id  
         

exec sims.currpt_pix_report_preview_selection_load @report_type='ClassList',@user_id=2

-- get list students of classes
exec sims.mid_pix_retrieve_student_classes @PersonID=12105,@effective_date='2019-06-01 08:45:21.607'

--EditStudentPLASCClassType
[sims].[plasc_pix_EditStudentPLASCClassType_SaveDetails]

SELECT * FROM sims.plasc_student_class

SELECT * FROM sims.plasc_student_class

exec sims.mid_pix_retrieve_student_classes @PersonID=12105,@effective_date='2019-06-01 00:00:00'
/*
class_id	code	description	staff_id	staff	noofperiods	subject_title
4950	HCL Hooke	Hooke	81	Mrs W Harris	0	Hooke

*/


SELECT * from sims.sims_member


-------------------------------------------------------
SELECT cvc.*,gm.* 
FROM sims.sims_base_group gm

join sims.curr_via_classes cvc
    on gm.base_group_id = cvc.base_group_id
	where gm.base_group_type_id = 2 -- class
	AND cvc.code LIKE '%10A/Mu1%'

------------------------------------------------------
	SELECT * FROM sims.curr_via_classes

SELECT * FROM sims.sims_base_group_type
WHERE code = 'Class'

------------------------------

plasc_pix_EditStudentPLASCClassType_GetDetails


-- SAVE student to class [sims].[curr_pix_CurrSchemeDetail_Save]


curr_pix_CurrSchemeDetail_Load

-- MEMBER TABLE
-- base group id and person id
SELECT bt.code AS GroupType,
	  sbg.code AS ClassName,
	  sm.* FROM sims.sims_member sm
		INNER JOIN sims.sims_base_group sbg ON sm.base_group_id = sbg.base_group_id
		INNER JOIN sims.sims_base_group_type bt ON sbg.base_group_type_id = bt.base_group_type_id
where sm.person_id = 12583 --9 rows

-- find class
SELECT * FROM sims.sims_base_group bg where bg.base_group_id = 11673

-- list all class
SELECT * FROM sims.sims_base_group bg WHERE bg.base_group_type_id =2

SELECT * FROM sims.sims_base_group_type

SELECT * FROM sims.sims_base_group bg
where bg.description like '%ALT:Fri:1%'

SELECT * FROM sims.curr_scheme
where sims.curr_scheme.external_name = '12a Option A' -- scheme_id 4236


SELECT * FROM sims.curr_scheme_type cst

SELECT * FROM sims.curr_scheme
where sims.curr_scheme.external_name = '10x English' -- scheme_id 4236

SELECT * from sims.sims_base_group
WHERE sims.sims_base_group.base_group_id =11673 -- base group type id 2 : class

SELECT * from sims.sims_base_group bg
WHERE bg.base_group_id IN (9693, 9694)


exec sims.curr_pix_CurrSchemeDetail_Load @acad_year_event_instance_id=42098,@group_ids_XML='<?xml version="1.0" encoding="ISO-8859-1"?><data> <row base_group_id=''11701'' /> <row base_group_id=''11710'' /> <row base_group_id=''11709'' /></data>',@scheme_id=4236


exec sims.curr_pix_CurrSchemeDetail_Save @group_ids_XML='<?xml version="1.0" encoding="ISO-8859-1"?><data> <row base_group_id=''11710'' /> <row base_group_id=''11709'' /></data>',@student_ids_XML='<?xml version="1.0" encoding="ISO-8859-1"?><data></data>',@members_XML='<?xml version="1.0" encoding="ISO-8859-1"?><data></data>'

exec sims.curr_pix_CurrSchemeDetail_Save @group_ids_XML='<?xml version="1.0" encoding="ISO-8859-1"?><data> <row base_group_id=''11673'' /> <row base_group_id=''11674'' /> <row base_group_id=''11675'' /></data>',@student_ids_XML='<?xml version="1.0" encoding="ISO-8859-1"?><data></data>',@members_XML='<?xml version="1.0" encoding="ISO-8859-1"?><data></data>'

exec sims.curr_pix_CurrSchemeDetail_Save @group_ids_XML='<?xml version="1.0" encoding="ISO-8859-1"?><data> <row base_group_id=''9693'' /> <row base_group_id=''9694'' /></data>',@student_ids_XML='<?xml version="1.0" encoding="ISO-8859-1"?><data></data>',@members_XML='<?xml version="1.0" encoding="ISO-8859-1"?><data></data>'


SELECT  cycle_segment_id FROM sims.curr_scheme cs WHERE cs.scheme_id = 4236
/*
1	Bands
2	Block
3	Cluster
4	Alternative
*/

SELECT * FROM sims.curr_scheme_type

-----------------------------------------------------
-- CurrCache populate
-- sims.curr_pix_CurrCache_Populate

SELECT * from    sims.sims_event_instance tei
where tei.event_instance_id = 14199

-- Table 2 = Destination-group -------------------------------------------
-- find start, end date for class

-- to determine start , end date of class

SELECT  
		tei.event_instance_id ,

		tei.narrative,
		t.description,
		s.* 
FROM sims.curr_scheme s
INNER JOIN sims.curr_scheme_type t ON s.scheme_type_id = t.scheme_type_id
INNER JOIN sims.sims_event_instance tei ON s.event_instance_id = tei.event_instance_id
where s.external_name = '10B/Ar1a' -- scheme_id 4236
ORDER BY tei.event_start DESC
-- Academic Year 2017/2018
--list all class base on schema_type_id

SELECT  [scheme_id]     = tdg.scheme_id
,       [base_group_id] = tdg.base_group_id
,       [start_date]    = tdg.start_date
,       [end_date]      = tdg.end_date
,bg.description AS ClassName
,ts.*
FROM    sims.curr_destinationgroup tdg
JOIN    sims.curr_scheme ts
  ON    ts.scheme_id = tdg.scheme_id
  JOIN sims.sims_base_group bg ON tdg.base_group_id = bg.base_group_id

where ts.scheme_id = 4235 --'10B/Ar1a'

--where  tdg.base_group_id = 11673

SELECT * FROM sims.curr_group
SELECT * FROM sims.curr_class


-- Academic Year 2018/2019 : event_id : 251
SELECT * FROM sims.sims_event
where sims.sims_event.event_type_id = 2
ORDER BY sims.sims_event.event_id DESC

SELECT * FROM sims.sims_event_type [set]



select  tei.event_id
,       tei.event_instance_id
,		te.description
,		[narrative]  = null
,		[start_date] = tei.event_start
,		[end_date]   = tei.event_end
,		[current]    = 'F'
from    sims.sims_event_instance tei
join    sims.sims_event te
on      te.event_id = tei.event_id
where   tei.event_instance_id = 251
