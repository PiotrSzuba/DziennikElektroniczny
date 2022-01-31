import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
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
    private apiRoute: ApiRouteService
  ) {
    this.api = this.apiRoute.backendRoute();
  }

  public getAllMySubjects(studentId: number) {
    return this.httpClient.get<SubjectViewModel[]>(
      this.api + 'Subjects/GetStudentSubjects/' + studentId
    );
  }

  public getAllTeacherSubjects(techerId: number) {
    let params = new HttpParams().set('teacherId', techerId);
    return this.httpClient.get<SubjectViewModel[]>(this.api + 'Subjects', {
      params: params,
    });
  }

  public getAllAdminSubjects() {
    return this.httpClient.get<SubjectViewModel[]>(this.api + 'Subjects');
  }

  public addSubject(subject: SubjectViewModel) {
    return this.httpClient
      .post<SubjectViewModel>(this.api + 'SubjectInfos', {
        ...subject,
        title: subject.subjectName,
        description: subject.subjectDescription,
      })
      .pipe(
        map((res) => {
          debugger
          subject.subjectInfoId = res.subjectInfoId;
          return this.httpClient.post<SubjectViewModel>(
            this.api + 'Subjects',
            subject
          );
        })
      );
  }

  public updateSubject(subject: SubjectViewModel) {
    return this.httpClient
      .put<SubjectViewModel>(
        this.api + 'SubjectInfos/' + subject.subjectInfoId,
        {
          ...subject,
          title: subject.subjectName,
          description: subject.subjectDescription,
        }
      )
      .pipe(
        map((res) => {
          subject.subjectId = subject.id;
          return this.httpClient.put<SubjectViewModel>(
            this.api + 'Subjects/' + subject.id,
            subject
          );
        })
      );
  }

  public deleteSubject(id: number) {
    return this.httpClient.delete(this.api + 'Subjects/' + id);
  }
}
