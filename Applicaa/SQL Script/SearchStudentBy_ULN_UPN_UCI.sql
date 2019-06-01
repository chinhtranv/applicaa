DECLARE @unique_pupil_no nvarchar(200) = ''
DECLARE @unique_learner_number nvarchar(200) = ''
DECLARE @uci nvarchar(200) = ''

--G823432110124	1111167582	951370117010T -- Andreassen	Nick

SET @unique_pupil_no ='D823432110122' -- Harvey Anderson
--SET @unique_learner_number = '1111167590' -- Amy Anderton
--SET @uci = '951370117005W' -- David Albanie

SELECT  [person_id]	= p.person_id,
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
							where person_id = s.person_id and school_id = sc.school_id) -- 2188

	-- Filter by UPN, ULN, UCI

AND ( ( s.unique_pupil_no = @unique_pupil_no) OR 
	  ( uln.unique_learner_number = @unique_learner_number) OR
	  ( c.uci = @uci )
	  )

