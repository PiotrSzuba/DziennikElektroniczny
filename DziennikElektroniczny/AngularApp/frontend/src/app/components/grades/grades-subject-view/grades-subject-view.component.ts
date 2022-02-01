import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { map } from 'rxjs';
import { GradeViewModel } from 'src/app/models/Grade';
import { PersonViewModel } from 'src/app/models/Person';
import { AccountService } from 'src/app/services/account/account.service';
import { GradesService } from 'src/app/services/grades/grades.service';
import { StatisticsService } from 'src/app/services/statistics/statistics.service';
import { AddGradeModalComponent } from './add-grade-modal/add-grade-modal.component';
import { DeleteModifyGradeModalComponent } from './delete-modify-grade-modal/delete-modify-grade-modal.component';

@Component({
  selector: 'app-grades-subject-view',
  templateUrl: './grades-subject-view.component.html',
  styleUrls: ['./grades-subject-view.component.scss']
})
export class GradesSubjectViewComponent implements OnInit {
  @Input() teacherId: number = -1;
  @Input() subjectId: number = -1;
  @Input() subjectDisplayName: string = "";
  subjectGrades: Map<number, GradeViewModel[]> = new Map<number, GradeViewModel[]>();
  
  constructor(private gradesService: GradesService,
              private accountService: AccountService,
              private statisticService: StatisticsService,
              private dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadGrades()
  }

  private loadGrades(){
    this.subjectGrades = new Map<number, GradeViewModel[]>()
    this.gradesService.getGradesFromSubject(this.subjectId).subscribe(
      response => {
        response.forEach(
          element => {
            this.accountService.getPerson(element.studentPersonId)
            .pipe(
              map(response => response[0])
            )
            .subscribe(
              response => {
                  let grades = this.subjectGrades.get(response.id)
                  if(grades){
                    grades.push(element)
                    grades.sort((g1, g2) => g1.id - g2.id);
                  }
                  else{
                    grades = [element]
                  }
                  this.subjectGrades.set(response.id, grades)
              }
            )
          }
        )
      }
    )
  }

  public getAvg(gardes: GradeViewModel[]){
    return this.statisticService.calculateGradeAverage(gardes)
  } 

  public openAddModal(studentId: number, studentDisplayName: string){
    const dialogRef = this.dialog.open(AddGradeModalComponent, {
      data: {
        studentId: studentId,
        studentDisplayName: studentDisplayName,
        subjectId: this.subjectId,
        subjectDisplayName: this.subjectDisplayName,
      }
    })

    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.gradesService.addGrade(this.teacherId, studentId, this.subjectId, result).subscribe(
          response => {
            if(response){
              this.loadGrades()
            }
          }
        )
      }
    });
  }

  public openDeleteModifyModal(gradeId: number, gradeValue: string, studentId: number, studentDisplayName: string){
    const dialogRef = this.dialog.open(DeleteModifyGradeModalComponent, {
      data: {
        gradeId: gradeId,
        gradeValue: gradeValue,
        studentDisplayName: studentDisplayName,
        subjectDisplayName: this.subjectDisplayName,
      }
    })

    dialogRef.afterClosed().subscribe(result => {
      if(result == 'delete'){
        this.gradesService.deleteGrade(gradeId).subscribe(
          response => {
            this.loadGrades()
          }
        )
      }
      else if(result){
        this.gradesService.updateGrade(gradeId, result, this.subjectId, studentId, this.teacherId).subscribe(
          response => {
            console.log(response)
            this.loadGrades()
          }
        )
      }
    });
  }
}
