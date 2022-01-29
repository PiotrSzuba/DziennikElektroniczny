import { Component, OnInit } from '@angular/core';
import { SubjectViewModel } from 'src/app/models/Subject';
import { GradesService } from 'src/app/services/grades/grades.service';
import { SubjectService } from 'src/app/services/subject/subject.service';

@Component({
  selector: 'app-grades',
  templateUrl: './grades.component.html',
  styleUrls: ['./grades.component.scss'],
})
export class GradesComponent implements OnInit {
  public subjects: SubjectViewModel[] = [];
  constructor(
    private subjectService: SubjectService,
    private gradesService: GradesService
  ) {}

  ngOnInit(): void {
    this.subjectService
      .getAllMySubjects()
      .subscribe((res) => (this.subjects = res));
  }

  public expandSubject(subject: SubjectViewModel) {
    subject.isExpanded = !subject.isExpanded;
    if (subject.isExpanded) {
      this.gradesService
        .getStudentGradesFromSubject(subject.id)
        .subscribe((grades) => {
          subject.grades = grades;
        });
    }
  }
}
