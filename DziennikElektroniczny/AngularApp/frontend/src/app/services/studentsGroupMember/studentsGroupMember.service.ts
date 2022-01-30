import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { ApiRouteService } from '../../globals/api-route.service';
import { Router } from '@angular/router';
import { StudentsGroupMemberViewModel } from 'src/app/models/StudentsGroupMember';

@Injectable({
    providedIn: 'root'
  })

  export class StudentsGroupMemberService {
    private api: string;
    constructor(
      private httpClient: HttpClient,
      private apiRoute: ApiRouteService,
      private router: Router
    ) {
      this.api = apiRoute.backendRoute();
    }

    public getStudentsGroupMembers(): StudentsGroupMemberViewModel[]{
        let studentsGroups: StudentsGroupMemberViewModel[] = [];
        this.httpClient
        .get<StudentsGroupMemberViewModel[]>(
          this.api + 'StudentsGroupMembers',
        )
        .subscribe(
          (response) => {
            response.forEach(element => {
                studentsGroups.push(new StudentsGroupMemberViewModel(
                element["id"],
                element["studentsGroupId"],
                element["studentsGroupName"],
                element["studentPersonId"],
                element["studentDisplayName"]
              ))
            });
          }
        )
        return studentsGroups;
    }
  }