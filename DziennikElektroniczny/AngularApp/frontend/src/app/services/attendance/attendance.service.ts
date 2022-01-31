import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiRouteService } from 'src/app/globals/api-route.service';
import { AttendanceViewModel } from 'src/app/models/Attendance';

@Injectable({
  providedIn: 'root'
})
export class AttendanceService {
  private api: string;

  constructor(
    private httpClient: HttpClient,
    private apiRoute: ApiRouteService,
  ) {
    this.api = this.apiRoute.backendRoute();
  }

  public getAttendanceForLesson(lessonId: number){
    let params = new HttpParams().set('lessonId', lessonId)
    return this.httpClient.get<AttendanceViewModel[]>(this.api + 'Attendances', { params: params })
  }

  public getAttendanceForStudent(studentId: number){
    let params = new HttpParams().set('studentId', studentId)
    return this.httpClient.get<AttendanceViewModel[]>(this.api + 'Attendances', { params: params })
  }

  public createStudentAttendance(lessonId: number, studentPersonId: number, wasPresent: number){
    return this.httpClient.post(this.api + 'Attendances', {
      lessonId: lessonId,
      studentPersonId: studentPersonId,
      wasPresent: wasPresent,
      absenceNote: null,
    })
  }

  public updateStudentAttendance(attendanceId: number, lessonId: number, studentPersonId: number, wasPresent: number, absenceNote: string | undefined){
    return this.httpClient.put(this.api + 'Attendances/' + attendanceId.toString(), {
      attendanceId: attendanceId,
      lessonId: lessonId,
      studentPersonId: studentPersonId,
      wasPresent: wasPresent,
      absenceNote: absenceNote,
    })
  }
}
