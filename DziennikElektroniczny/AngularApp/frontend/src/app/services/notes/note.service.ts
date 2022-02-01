import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiRouteService } from 'src/app/globals/api-route.service';
import {NoteViewModel} from 'src/app/models/Note'

@Injectable({
    providedIn: 'root'
  })
export class NoteService {
    private api: string;
    constructor(private httpClient: HttpClient, private apiRoute: ApiRouteService,) {
        this.api = apiRoute.backendRoute();
    }

    public getNotes(){
        return this.httpClient.get<NoteViewModel[]>(this.api + 'Notes');        
    }

    public getNotesStudent(studentId: number) {
        let params = new HttpParams().set('studentId', studentId)
        return this.httpClient.get<NoteViewModel[]>(this.api + 'Notes', { params: params })
    }

    public getNotesTeacher(teacherId: number) {
        let params = new HttpParams().set('teacherId', teacherId)
        return this.httpClient.get<NoteViewModel[]>(this.api + 'Notes', { params: params })
    }

    public postNote(description: String,date: Date,teacherPersonId: number,studentPersonId: number){
        return this.httpClient
        .post(this.api + 'Notes',
        {description: description, date: date, teacherPersonId: teacherPersonId, studentPersonId: studentPersonId});
    }

    public editNote(id: number,description: String,date: Date,teacherPersonId: number,studentPersonId: number){
        return this.httpClient.put(this.api + 'Notes/' + id,
        {NoteId: id, description: description, date: date, teacherPersonId: teacherPersonId, studentPersonId});
    }

    public deleteNote(id: number){
        return this.httpClient
        .delete(this.api + 'notes/' + id);
      }
}