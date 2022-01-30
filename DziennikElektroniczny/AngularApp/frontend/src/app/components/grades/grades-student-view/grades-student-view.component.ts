import { Component, Input, OnInit } from '@angular/core';
import { SubjectViewModel } from 'src/app/models/Subject';
import { GradesService } from 'src/app/services/grades/grades.service';
import { SubjectService } from 'src/app/services/subject/subject.service';

@Component({
  selector: 'app-grades-student-view',
  templateUrl: './grades-student-view.component.html',
  styleUrls: ['./grades-student-view.component.scss']
})
export class GradesStudentViewComponent implements OnInit {
  @Input() studentId: number = -1;
  public subjects: SubjectViewModel[] = [];
  constructor(
    private subjectService: SubjectService,
    private gradesService: GradesService
  ) {}

  ngOnInit(): void {
    this.subjectService
      .getAllMySubjects(this.studentId)
      .subscribe((res) => (this.subjects = res));
  }

  public expandSubject(subject: SubjectViewModel) {
    subject.isExpanded = !subject.isExpanded;
    if (subject.isExpanded) {
      this.gradesService
        .getStudentGradesFromSubject(subject.id, this.studentId)
        .subscribe((grades) => {
          subject.grades = grades;
        });
    }
  }
}
