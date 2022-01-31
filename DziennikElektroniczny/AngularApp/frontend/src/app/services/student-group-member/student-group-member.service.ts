import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiRouteService } from 'src/app/globals/api-route.service';
import { StudentGroupMemberViewModel } from 'src/app/models/StudentGroupMember';

@Injectable({
  providedIn: 'root'
})
export class StudentGroupMemberService {
  private api: string;

  constructor(
    private httpClient: HttpClient,
    private apiRoute: ApiRouteService,
  ) {
    this.api = this.apiRoute.backendRoute();
  }

  public getStudentGroupMembers(studentGroupId: number){
    let params = new HttpParams().set('groupId', studentGroupId)
    return this.httpClient.get<StudentGroupMemberViewModel[]>(this.api + 'StudentsGroupMembers', { params: params })
  }
}
