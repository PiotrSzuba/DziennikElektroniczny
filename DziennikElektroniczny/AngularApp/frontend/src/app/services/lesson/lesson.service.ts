import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiRouteService } from 'src/app/globals/api-route.service';
import { LessonViewModel } from 'src/app/models/Lessons';

@Injectable({
  providedIn: 'root'
})
export class LessonService {
  private api: string;

  constructor(
    private httpClient: HttpClient,
    private apiRoute: ApiRouteService,
  ) {
    this.api = this.apiRoute.backendRoute();
  }

  public getLessonsForSubject(subjectId: number){
    let params = new HttpParams().set('subjectId', subjectId)
    return this.httpClient.get<LessonViewModel[]>(this.api + 'Lessons', { params: params })
  }

  public createLesson(teacherPersonId: number, subjectId: number, topic: string, date: Date){
    return this.httpClient.post(this.api + 'Lessons', {
      teacherPersonId: teacherPersonId,
      subjectId: subjectId,
      topic: topic,
      date: date
    })
  }

  public deleteLesson(lessonId: number){
    return this.httpClient.delete(this.api + 'Lessons/' + lessonId.toString())
  }

  public modifyLesson(lessonId: number, teacherPersonId: number, subjectId: number, topic: string, date: Date){
    return this.httpClient.put(this.api + 'Lessons/' + lessonId, {
      lessonId: lessonId,
      teacherPersonId: teacherPersonId,
      subjectId: subjectId,
      topic: topic,
      date: date
    })
  }
}
