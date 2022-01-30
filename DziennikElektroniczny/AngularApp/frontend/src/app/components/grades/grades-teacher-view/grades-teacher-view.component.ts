import { Component, Input, OnInit } from '@angular/core';
import { SubjectViewModel } from 'src/app/models/Subject';
import { SubjectService } from 'src/app/services/subject/subject.service';

@Component({
  selector: 'app-grades-teacher-view',
  templateUrl: './grades-teacher-view.component.html',
  styleUrls: ['./grades-teacher-view.component.scss']
})
export class GradesTeacherViewComponent implements OnInit {
  @Input() teacherId: number = -1;
  subjects: SubjectViewModel[] = [];
  
  constructor(private subjectService: SubjectService) { }

  ngOnInit(): void {
    this.subjectService.getAllTeacherSubjects(this.teacherId).subscribe(
      response => {
        response.forEach(
          element => this.subjects.push(element)
        )
      }
    );
  }

}
