import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { ApiRouteService } from '../../globals/api-route.service';
import { Router } from '@angular/router';
import { StudentsGroupViewModel } from 'src/app/models/StudentsGroup';

@Injectable({
  providedIn: 'root',
})
export class StudentsGroupService {
  private api: string;
  constructor(
    private httpClient: HttpClient,
    private apiRoute: ApiRouteService,
    private router: Router
  ) {
    this.api = apiRoute.backendRoute();
  }

  public getStudentsGroups(): StudentsGroupViewModel[] {
    let studentsGroups: StudentsGroupViewModel[] = [];
    this.httpClient
      .get<StudentsGroupViewModel[]>(this.api + 'StudentsGroups')
      .subscribe((response) => {
        response.forEach((element) => {
          studentsGroups.push(
            new StudentsGroupViewModel(
              element['id'],
              element['teacherPersonId'],
              element['teacherDisplayName'],
              element['title'],
              element['description'],
              element['yearOfStudy'],
              element['studentsDisplayNames']
            )
          );
        });
      });
    return studentsGroups;
  }

  public getAllStudentGroups() {
    return this.httpClient.get<StudentsGroupViewModel[]>(
      this.api + 'StudentsGroups'
    );
  }

  public addStudentGroup(studentGroup: StudentsGroupViewModel) {
    return this.httpClient.post<StudentsGroupViewModel>(
      this.api + 'StudentsGroups',
      studentGroup
    );
  }
  public updateStudentGroup(studentGroup: StudentsGroupViewModel) {
    studentGroup.studentsGroupId = studentGroup.id;
    return this.httpClient.put<StudentsGroupViewModel>(
      this.api + 'StudentsGroups/' + studentGroup.id,
      studentGroup 
    );
  }

  public deleteStudentGroup(id: number) {
    return this.httpClient.delete(this.api + 'StudentsGroups');
  }
}
