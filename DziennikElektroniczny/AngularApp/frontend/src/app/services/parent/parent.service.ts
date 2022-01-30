import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiRouteService } from 'src/app/globals/api-route.service';
import { Parent } from 'src/app/models/Parent';

@Injectable({
  providedIn: 'root'
})
export class ParentService {
  private api: string;
  constructor(private httpClient: HttpClient, private apiRoute: ApiRouteService,) {
    this.api = apiRoute.backendRoute();
  }

  public getParents(parentId: number) {
    let params = new HttpParams().set('id', parentId)
    return this.httpClient.get<Parent[]>(this.api + 'Parents', { params: params })
  }

  public getParentsStudId(studentPersonId: number) {
    let params = new HttpParams().set('studentPersonId', studentPersonId)
    return this.httpClient.get<Parent[]>(this.api + 'Parents', { params: params })
  }
}
