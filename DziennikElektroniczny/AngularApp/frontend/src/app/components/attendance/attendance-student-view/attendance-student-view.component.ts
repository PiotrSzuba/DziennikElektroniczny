import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { forkJoin, Observable } from 'rxjs';
import { AttendanceViewModel } from 'src/app/models/Attendance';
import { AttendanceService } from 'src/app/services/attendance/attendance.service';
import { StatisticsService } from 'src/app/services/statistics/statistics.service';
import { AddNoteComponent } from '../../notes/add-note/add-note.component';

export interface AttendanceElement {
  attendanceId: number;
  subjectName: string;
  date: string;
  attendance: string;
  absentNote: string;
  makeNote: boolean;
}

export interface MakeNoteInfo {
  disabled: boolean;
  checked: boolean;
}

@Component({
  selector: 'app-attendance-student-view',
  templateUrl: './attendance-student-view.component.html',
  styleUrls: ['./attendance-student-view.component.scss']
})

export class AttendanceStudentViewComponent implements OnInit {
  @Input() studentId: number = -1;
  @Input() parentView: boolean = false;
  dataSource = new MatTableDataSource<AttendanceElement>();
  displayedColumns: string[] = ['subjectName', 'date', 'attendance', 'absentNote'];
  makeNoteInfo: Map<number, MakeNoteInfo> = new Map<number, MakeNoteInfo>()
  attendancesInfo: Map<number, AttendanceViewModel> = new Map<number, AttendanceViewModel>()
  makeNoteCounter: number = 0
  makeNoteAll: boolean = false
  buttonDisabled: boolean = true

  constructor(private attendanceService: AttendanceService,
              private statisticService: StatisticsService,
              private dialog: MatDialog) {}

  ngOnInit(): void {
    if(this.parentView) this.displayedColumns = ['subjectName', 'date', 'attendance', 'absentNote', 'makeNote']
    this.loadData()
  }

  public loadData(){
    this.dataSource = new MatTableDataSource<AttendanceElement>();
    this.makeNoteInfo = new Map<number, MakeNoteInfo>()
    this.attendancesInfo = new Map<number, AttendanceViewModel>()
    this.makeNoteCounter= 0
    this.makeNoteAll = false
    this.buttonDisabled = true

    this.attendanceService.getAttendanceForStudent(this.studentId).subscribe(
      response => {
        let data: AttendanceElement[] = []
        response.sort((a, b) => Date.parse(a.lessonDate) - Date.parse(b.lessonDate))
        const datepipe: DatePipe = new DatePipe('en-US')
        let date, attendance: string
        let tempDate: string | undefined
        let disabled: boolean

        response.forEach(
          element => {
            tempDate = datepipe.transform(Date.parse(element.lessonDate), 'dd.MM.YYYY', 'UTC+2')?.toString()
            if(tempDate) date = tempDate
            else date = 'error'
            if(element.wasPresent){
              attendance = 'Obecny'
              disabled = true
            }
            else if(element.absenceNote){
              attendance = 'Nieobecność usprawiedliwiona'
              disabled = true
            }
            else{
              attendance = 'Nieobecny'
              disabled = false
            }
            data.push({
              attendanceId: element.id,
              subjectName: element.subjectName,
              date: date,
              attendance: attendance,
              absentNote: element.absenceNote,
              makeNote: false})
            this.makeNoteInfo.set(element.id, {disabled: disabled, checked: false})
            this.attendancesInfo.set(element.id, new AttendanceViewModel(
              element.id,
              element.studentPersonId,
              element.studentDisplayName,
              element.lessonId,
              element.subjectName,
              element.lessonDate,
              element.wasPresent,
              element.absenceNote
            ))
          }
        )
        this.dataSource.data = data
      }
    )
  }

  public getFreq(){
    let atts: AttendanceViewModel[] = []
    for(let value of this.attendancesInfo.values()) atts.push(value)
    return this.statisticService.calculateFrequency(atts)
  }

  public isMakeNoteDisabled(attendanceId: number): boolean{
    let disabled: boolean | undefined = this.makeNoteInfo.get(attendanceId)?.disabled
    if(disabled !== undefined) return disabled
    else return false 
  }

  public makeNoteChanged(attendanceId: number, newValue?: boolean){
    let makeNote: MakeNoteInfo | undefined = this.makeNoteInfo.get(attendanceId)
    if(makeNote && !makeNote.disabled){
      if(newValue === undefined){
        this.makeNoteAll = false
        if(makeNote.checked){
          this.makeNoteCounter--
        }
        else{
          this.makeNoteCounter++
        }
        makeNote.checked = !makeNote.checked
      }
      else if(newValue === true && makeNote.checked !== true){
        this.makeNoteCounter++
        makeNote.checked = true
      }
      else if(newValue === false && makeNote.checked !== false){
        this.makeNoteCounter--
        makeNote.checked = false
      }

      if(this.makeNoteCounter > 0) this.buttonDisabled = false
      else this.buttonDisabled = true
    }
  }

  public makeNoteChangeAll(){
    for(let key of this.makeNoteInfo.keys()){
      this.makeNoteChanged(key, this.makeNoteAll)
    }
  }

  public isMakeNoteChecked(attendanceId: number): boolean{
    let checked: boolean | undefined = this.makeNoteInfo.get(attendanceId)?.checked
    if(checked !== undefined) return checked
    else return false 
  }

  public openMakeNoteModal(){
    const dialogRef = this.dialog.open(AddNoteComponent)

    dialogRef.afterClosed().subscribe(result => {
      console.log(result)
      if(typeof result === 'string'){
        this.makeNote(result)
      }
    });
  }

  public makeNote(absenceNote: string){
    let requests: Observable<Object>[] = []
    for(let [attendanceId, makeNoteInfo] of this.makeNoteInfo){
      if(makeNoteInfo.checked === true){
        console.log(attendanceId)
        let attendance: AttendanceViewModel | undefined = this.attendancesInfo.get(attendanceId)
        if(attendance !== undefined){
          let request = this.attendanceService.updateStudentAttendance(
            attendanceId,
            attendance.lessonId,
            attendance.studentPersonId,
            Number(attendance.wasPresent),
            absenceNote
            )
          requests.push(request)
        }
      }
    }
    forkJoin(requests).subscribe(
      responses => {
        this.loadData()
      }
    )
  }
}
