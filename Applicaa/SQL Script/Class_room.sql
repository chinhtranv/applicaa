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