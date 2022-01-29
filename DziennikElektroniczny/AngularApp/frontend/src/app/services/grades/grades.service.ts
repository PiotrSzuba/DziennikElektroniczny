import { query } from '@angular/animations';
import { HttpClient } from '@angular/common/http';
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

  public getStudentGradesFromSubject(subjectId: number) {
    let queryString = '?subjectId=' + subjectId;
    queryString =
      queryString +
      '&studentId=' +
      this.accountService.getCurrentPersonFromLocalStorage().id;
    return this.httpClient.get<GradeViewModel[]>(
      this.api + 'Grades/' + queryString
    );
  }
}
