import { Component, Input, OnInit } from '@angular/core';
import { SubjectViewModel } from 'src/app/models/Subject';
import { GradesService } from 'src/app/services/grades/grades.service';
import { StatisticsService } from 'src/app/services/statistics/statistics.service';
import { SubjectService } from 'src/app/services/subject/subject.service';

@Component({
  selector: 'app-grades-student-view',
  templateUrl: './grades-student-view.component.html',
  styleUrls: ['./grades-student-view.component.scss']
})
export class GradesStudentViewComponent implements OnInit {
  @Input() studentId: number = -1;
  avgGrades: Map<number, number> = new Map<number, number>()
  public subjects: SubjectViewModel[] = [];
  constructor(
    private subjectService: SubjectService,
    private gradesService: GradesService,
    private statisticService: StatisticsService,
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
          grades.sort((g1, g2) => g1.id - g2.id);
          subject.grades = grades;
          this.avgGrades.set(subject.id, this.statisticService.calculateGradeAverage(subject.grades))
        });
    }
  }

  public getAvg(subjectId: number){
    console.log("hello")
    return this.avgGrades.get(subjectId)
  }
}
