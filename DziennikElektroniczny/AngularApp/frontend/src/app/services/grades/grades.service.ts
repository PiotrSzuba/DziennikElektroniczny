import { query } from '@angular/animations';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiRouteService } from 'src/app/globals/api-route.service';
import { GradeViewModel } from 'src/app/models/Grade';
import { SubjectViewModel } from 'src/app/models/Subject';
import { AccountService } from '../account/account.service';

@Injectable({
  providedIn: 'root',
})
export class GradesService {
  private api: string;
  constructor(
    private httpClient: HttpClient,
    private apiRoute: ApiRouteService,
    private accountService: AccountService
  ) {
    this.api = this.apiRoute.backendRoute();
  }

  public getStudentGradesFromSubject(subjectId: number, studentId: number) {
    let queryString = '?subjectId=' + subjectId;
    queryString =
      queryString +
      '&studentId=' +
      studentId;
    return this.httpClient.get<GradeViewModel[]>(
      this.api + 'Grades/' + queryString
    );
  }

  public getGradesFromSubject(subjectId: number) {
    let params = new HttpParams().set('subjectId', subjectId)
    return this.httpClient.get<GradeViewModel[]>(this.api + 'Grades', { params: params })
  }

  public addGrade(teacherPersonId: number, studentPersonId: number, subjectId: number, value: string){
    return this.httpClient.post(this.api + 'Grades', {
      teacherPersonId: teacherPersonId,
      studentPersonId: studentPersonId,
      subjectId: subjectId,
      value: value,
    })
  }

  public deleteGrade(gradeId: number){
    return this.httpClient.delete(this.api + 'Grades/' + gradeId.toString())
  }

  public updateGrade(gradeId: number, gradeValue: string, subjectId: number, studentPersonId: number, teacherPersonId: number,){
    return this.httpClient.put(this.api + 'Grades/' + gradeId.toString(), {
      gradeId: gradeId,
      value: gradeValue,
      subjectId: subjectId,
      studentPersonId: studentPersonId,
      teacherPersonId: teacherPersonId
    })
  }
}
