select l.study_date, l.slot_no, c.lecturer_shortname, c.class,
	case when a.attendance_status = 0 then 'Absent'
	else case when a.attendance_status = 1 then 'Present'
	else 'Future' end end as status
from Attendances a, LectureDetail l, CourseDetail c
where a.lecture_detail_id = l.id and l.course_detail_id = c.id and a.student_code like 'he130022'
and c.term_id = 1 and c.id = 1 order by l.study_date asc

update Attendances set attendance_status = 1
from Attendances a inner join LectureDetail l on a.lecture_detail_id = l.id inner join CourseDetail c on l.course_detail_id = c.id
where a.student_code like 'he130069' and c.course_code = 'LAB231' and l.study_date between CAST('2019/05/13' as date) and GETDATE()

update Attendances set attendance_status = 1
from Attendances a inner join LectureDetail l on a.lecture_detail_id = l.id inner join CourseDetail c on l.course_detail_id = c.id
where a.student_code like 'he130059' and c.course_code = 'LAB231' and l.study_date between CAST('2019/05/13' as date) and GETDATE()

update Attendances set attendance_status = 1
from Attendances a inner join LectureDetail l on a.lecture_detail_id = l.id inner join CourseDetail c on l.course_detail_id = c.id
where a.student_code like 'he130088' and c.course_code = 'LAB231' and l.study_date between CAST('2019/05/13' as date) and GETDATE()

update Attendances set attendance_status = 1
from Attendances a inner join LectureDetail l on a.lecture_detail_id = l.id inner join CourseDetail c on l.course_detail_id = c.id
where a.student_code like 'he130569' and c.course_code = 'LAB231' and l.study_date between CAST('2019/05/13' as date) and GETDATE()

update Attendances set attendance_status = 1
from Attendances a inner join LectureDetail l on a.lecture_detail_id = l.id inner join CourseDetail c on l.course_detail_id = c.id
where a.student_code like 'he130022' and c.course_code = 'LAB231' and l.study_date between CAST('2019/05/13' as date) and GETDATE()



select c.course_code,
	case when a.attendance_status = 0 then 'Absent'
	else case when a.attendance_status = 1 then 'Present'
	else 'Not yet' end end as status
from Attendances a, LectureDetail l, CourseDetail c
where a.lecture_detail_id = l.id and l.course_detail_id = c.id and a.student_code like 'he130069'
and l.study_date = '2019/11/11' and l.slot_no = 4


select distinct c.course_code, c.course_name
from Course c, CourseDetail cd
where c.course_code = cd.course_code and c.department = 'Software Engineering' and cd.term_id = 1

select distinct cd.id, l.short_name, cd.class, COUNT(cs.student_code) as student_num
from Lecturer l, Course c, CourseDetail cd, CourseStudent cs
where l.short_name = cd.lecturer_shortname and cd.course_code = c.course_code and cd.id = cs.course_detail_id
and c.department = 'Software Engineering' and cd.term_id = 1 and cd.course_code = 'PRN292'
group by cd.id, l.short_name, cd.class


update Attendances set attendance_status = 0
from Attendances a inner join LectureDetail l on a.lecture_detail_id = l.id inner join CourseDetail c on l.course_detail_id = c.id
where a.student_code like 'he130069' and c.course_code = 'LAB231' and l.study_date = CAST('2019/11/04' as date)

update Attendances set attendance_status = 0
from Attendances a inner join LectureDetail l on a.lecture_detail_id = l.id inner join CourseDetail c on l.course_detail_id = c.id
where a.student_code like 'he130059' and c.course_code = 'LAB231' and l.study_date = CAST('2019/11/06' as date)

update Attendances set attendance_status = 0
from Attendances a inner join LectureDetail l on a.lecture_detail_id = l.id inner join CourseDetail c on l.course_detail_id = c.id
where a.student_code like 'he130088' and c.course_code = 'LAB231' and l.study_date = CAST('2019/10/28' as date)

update Attendances set attendance_status = 0
from Attendances a inner join LectureDetail l on a.lecture_detail_id = l.id inner join CourseDetail c on l.course_detail_id = c.id
where a.student_code like 'he130569' and c.course_code = 'LAB231' and l.study_date = CAST('2019/09/30' as date)

update Attendances set attendance_status = 0
from Attendances a inner join LectureDetail l on a.lecture_detail_id = l.id inner join CourseDetail c on l.course_detail_id = c.id
where a.student_code like 'he130022' and c.course_code = 'LAB231' and l.study_date = CAST('2019/10/14' as date)