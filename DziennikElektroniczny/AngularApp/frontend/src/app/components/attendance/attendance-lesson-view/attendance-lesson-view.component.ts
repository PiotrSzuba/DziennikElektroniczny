import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { forkJoin, Observable } from 'rxjs';
import { AttendanceViewModel } from 'src/app/models/Attendance';
import { LessonViewModel } from 'src/app/models/Lessons';
import { StudentGroupMemberViewModel } from 'src/app/models/StudentGroupMember';
import { SubjectViewModel } from 'src/app/models/Subject';
import { AttendanceService } from 'src/app/services/attendance/attendance.service';
import { LessonService } from 'src/app/services/lesson/lesson.service';
import { StudentGroupMemberService } from 'src/app/services/student-group-member/student-group-member.service';
import { ModifyDeleteLessonComponent } from '../../lesson/modify-delete-lesson/modify-delete-lesson.component';

export interface AttendanceElement {
  personId: number;
  name: string;
  present: boolean;
  absent: boolean;
  absentNote: string;
}

@Component({
  selector: 'app-attendance-lesson-view',
  templateUrl: './attendance-lesson-view.component.html',
  styleUrls: ['./attendance-lesson-view.component.scss']
})
export class AttendanceLessonViewComponent implements OnInit {
  @Input() teacherId: number = -1;
  @Input() subject: SubjectViewModel = new SubjectViewModel();
  @Input() lesson: LessonViewModel = new LessonViewModel();
  @Output() lessonDeleted = new EventEmitter()
  @Output() lessonModified = new EventEmitter()
  dataSource = new MatTableDataSource<AttendanceElement>();
  displayedColumns: string[] = ['name', 'present', 'absent', 'absentNote'];
  members: Map<number, StudentGroupMemberViewModel> = new Map<number, StudentGroupMemberViewModel>();
  attendances: Map<number, AttendanceViewModel> = new Map<number, AttendanceViewModel>();
  tableData: Map<number, AttendanceElement> = new Map<number, AttendanceElement>();
  wasPresent: Map<number, number> = new Map<number, number>();
  presentSelected: boolean = false
  absentSelected: boolean = false
  modifyAttendancesButtonDisabled: boolean = true

  
  constructor(
    private studentGropMemberService: StudentGroupMemberService,
    private attendanceService: AttendanceService,
    private lessonService: LessonService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadTableData()
  }

  private loadTableData(){
    this.dataSource = new MatTableDataSource<AttendanceElement>();
    this.members = new Map<number, StudentGroupMemberViewModel>();
    this.attendances = new Map<number, AttendanceViewModel>();
    this.tableData = new Map<number, AttendanceElement>();
    this.wasPresent = new Map<number, number>();
    this.presentSelected = false
    this.absentSelected = false
    this.modifyAttendancesButtonDisabled = true

    this.studentGropMemberService.getStudentGroupMembers(this.subject.studentsGroupId).subscribe(
      response => {
        response.forEach(
          element => {
            this.members.set(element.studentPersonId, new StudentGroupMemberViewModel(
              element.id,
              element.studentsGroupId,
              element.studentsGroupName,
              element.studentPersonId,
              element.studentDisplayName
            ))
            this.tableData.set(element.studentPersonId, {
              personId: element.studentPersonId,
              name: element.studentDisplayName,
              present: false,
              absent: false,
              absentNote: ''
            })
            this.wasPresent.set(element.studentPersonId, -1)
          }
        )
        this.loadAttendance()
      }
    )
  }

  private loadAttendance(){
    this.attendanceService.getAttendanceForLesson(this.lesson.id).subscribe(
      response => {
        response.forEach(
          element => {
            if(this.tableData.has(element.studentPersonId)){
              this.attendances.set(element.studentPersonId, new AttendanceViewModel(
                element.id,
                element.studentPersonId,
                element.studentDisplayName,
                element.lessonId,
                element.subjectName,
                element.lessonDate,
                element.wasPresent,
                element.absenceNote
              ))
              let tableDataElement = this.tableData.get(element.studentPersonId)
              if(tableDataElement){
                tableDataElement.present = Boolean(element.wasPresent)
                tableDataElement.absent = !element.wasPresent
                tableDataElement.absentNote = element.absenceNote
                this.wasPresent.set(element.studentPersonId, Number(element.wasPresent))
                this.tableData.set(element.studentPersonId, tableDataElement)
              }
            }
          }
        )
        this.loadDataSource()
      },
      error => {
        this.loadDataSource()
      }
    )
  }

  private loadDataSource(){
    let data: AttendanceElement[] = []
        for(let value of this.tableData.values()){
          data.push(value)
        }
        this.dataSource.data = data
  }

  public wasStudentPresent(studentId: number): boolean{
    let wasPresent = this.wasPresent.get(studentId)
    if(wasPresent === 1){
      return true
    }
    else{
      return false
    }
  }

  public wasStudentAbsent(studentId: number): boolean{
    let wasPresent = this.wasPresent.get(studentId)
    if(wasPresent === 0){
      return true
    }
    else{
      return false
    }
  }

  public changeStudentPresence(studentId: number, controler: string){
    this.presentSelected = false
    this.absentSelected = false

    let wasPresent = this.wasPresent.get(studentId)
    if(controler === 'present'){
      if(wasPresent === -1){
        this.setWasAbsent(studentId, 1)
      }
      else{
        this.setWasAbsent(studentId, Number(!Boolean(wasPresent)))
      }
    }
    else if(controler === 'absent'){
      if(wasPresent === -1){
        this.setWasAbsent(studentId, 0)
      }
      else{
        this.setWasAbsent(studentId, Number(!Boolean(wasPresent)))
      }
    }
    
  }

  public changeAllStudentsPresence(controler: string){
    if(controler === 'present'){
      this.absentSelected = false
      for(let key of this.wasPresent.keys()){
        this.setWasAbsent(Number(key), Number(this.presentSelected))
      }
    }
    else if(controler === 'absent'){
      this.presentSelected = false
      for(let key of this.wasPresent.keys()){
        this.setWasAbsent(Number(key), Number(!this.absentSelected))
      }
    }
  }

  public setWasAbsent(studentId: number, newValue: number){
    this.modifyAttendancesButtonDisabled = false
    this.wasPresent.set(studentId, newValue)
  }

  public updateAttendances(){
    let requests: Observable<Object>[] = []
    for(let [studentId, wasPresent] of this.wasPresent){
      if(wasPresent !== -1){
        if(this.attendances.has(studentId)){
          let attendance = this.attendances.get(studentId)
          if(attendance?.id){
            let request = this.attendanceService.updateStudentAttendance(attendance.id, this.lesson.id, studentId, wasPresent, attendance.absenceNote)
            requests.push(request)
          }
        }
        else{
          let request = this.attendanceService.createStudentAttendance(this.lesson.id, studentId, wasPresent)
          requests.push(request)
        }
      }
    }
    forkJoin(requests).subscribe(
      responses => {
        this.loadTableData()
      }
    )
  }

  public modifyLesson(){
    const dialogRef = this.dialog.open(ModifyDeleteLessonComponent, {
      data: {
        lessonId: this.lesson.id,
        teacherId: this.teacherId,
        subject: this.subject,
        topic: this.lesson.topic,
        selectedDate: this.lesson.date
      }
    })

    dialogRef.afterClosed().subscribe(result => {
      if(result === 'delete'){
        this.lessonService.deleteLesson(this.lesson.id).subscribe(
          response => {
            this.lessonDeleted.emit()
          }
        )
      }
      else if(result){
        this.lessonService.modifyLesson(this.lesson.id, this.teacherId, this.subject.id, result.topic, result.selectedDate).subscribe(
          response => {
            this.lessonModified.emit()
          }
        )
      }
    });
  }
}
