import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { LessonViewModel } from 'src/app/models/Lessons';
import { SubjectViewModel } from 'src/app/models/Subject';
import { LessonService } from 'src/app/services/lesson/lesson.service';

@Component({
  selector: 'app-attendance-subject-view',
  templateUrl: './attendance-subject-view.component.html',
  styleUrls: ['./attendance-subject-view.component.scss']
})
export class AttendanceSubjectViewComponent implements OnInit {
  @Input() teacherId: number = -1;
  @Input() subject: SubjectViewModel = new SubjectViewModel();
  lessons: LessonViewModel[] = [];

  constructor(private lessonService: LessonService) { }

  ngOnInit(): void {
    this.loadLessons()
  }

  public loadLessons(){
    this.lessons = []
    this.lessonService.getLessonsForSubject(this.subject.id).subscribe(
      response => {
        response.forEach(
          element => {
            this.lessons.push(new LessonViewModel(
              element.id,
              element.teacherPersonId,
              element.teacherName,
              element.subjectId,
              element.subjectName,
              element.topic,
              element.date
            ))
          }

        )
        this.lessons.sort((l1, l2) => Date.parse(l1.date) - Date.parse(l2.date))
      }
    )
  }

  public getHeader(topic: string, date: string): string{
    const datepipe: DatePipe = new DatePipe('en-US')
    let formattedDate = datepipe.transform(Date.parse(date), 'dd.MM.YYYY', 'UTC+2')?.toString()
    return topic + ' - ' + formattedDate
  }

}
