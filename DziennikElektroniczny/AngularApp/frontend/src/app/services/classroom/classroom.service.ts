import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiRouteService } from 'src/app/globals/api-route.service';
import { ClassroomViewModel } from 'src/app/models/Classroom';
import { AccountService } from '../account/account.service';

@Injectable({
  providedIn: 'root',
})
export class ClassroomService {
  private api: string;
  constructor(
    private httpClient: HttpClient,
    private apiRoute: ApiRouteService,
    private accountService: AccountService
  ) {
    this.api = apiRoute.backendRoute();
  }

  getClassrooms() {
    return this.httpClient.get<ClassroomViewModel[]>(this.api + 'Classrooms');
  }
  deleteClassroom(id: number) {
    return this.httpClient.delete(this.api + 'Classrooms/' + id);
  }
  addClassroom(classroom: ClassroomViewModel) {
    return this.httpClient.post<ClassroomViewModel>(
      this.api + 'Classrooms',
      classroom
    );
  }
  updateClassroom(classroom: ClassroomViewModel) {
    classroom.classroomId = classroom.id;
    return this.httpClient.put<ClassroomViewModel>(
      this.api + 'Classrooms/' + classroom.id,
      classroom
    );
  }
}
