import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiRouteService } from 'src/app/globals/api-route.service';
import { SubjectViewModel } from 'src/app/models/Subject';
import { AccountService } from '../account/account.service';

@Injectable({
  providedIn: 'root',
})
export class SubjectService {
  private api: string;
  constructor(
    private httpClient: HttpClient,
    private apiRoute: ApiRouteService,
    private accountService: AccountService
  ) {
    this.api = this.apiRoute.backendRoute();
  }

  public getAllMySubjects(studentId: number) {
    return this.httpClient.get<SubjectViewModel[]>(
      this.api +
        'Subjects/GetStudentSubjects/' +
        studentId
    );
  }

  public getAllTeacherSubjects(techerId: number) {
    let params = new HttpParams().set('teacherId', techerId)
    return this.httpClient.get<SubjectViewModel[]>(this.api + 'Subjects', { params: params })
  }
}
