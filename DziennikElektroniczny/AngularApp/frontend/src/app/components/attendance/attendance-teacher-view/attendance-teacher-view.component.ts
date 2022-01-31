import { Component, Input, OnInit } from '@angular/core';
import { SubjectViewModel } from 'src/app/models/Subject';
import { SubjectService } from 'src/app/services/subject/subject.service';

@Component({
  selector: 'app-attendance-teacher-view',
  templateUrl: './attendance-teacher-view.component.html',
  styleUrls: ['./attendance-teacher-view.component.scss']
})
export class AttendanceTeacherViewComponent implements OnInit {
  @Input() teacherId: number = -1;
  subjects: SubjectViewModel[] = [];
  
  constructor(private subjectService: SubjectService) { }

  ngOnInit(): void {
    this.subjectService.getAllTeacherSubjects(this.teacherId).subscribe(
      response => {
        response.forEach(
          element => {
            this.subjects.push(new SubjectViewModel(
              element.id,
              element.subjectInfoId,
              element.subjectName,
              element.teacherPersonId,
              element.teacherName,
              element.studentsGroupId,
              element.studentsGroupName,
              element.classRoomId,
              element.classRoomName,
              element.classRoomFloor,
              element.classRoomBuilding
            ))
          }
        )
      }
    )
  }

}
