import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { ApiRouteService } from '../../globals/api-route.service';
import { Router } from '@angular/router';
import { EventViewModel } from 'src/app/models/Event';
@Injectable({
  providedIn: 'root'
})
export class EventService {
  private api: string;
  constructor(
    private httpClient: HttpClient,
    private apiRoute: ApiRouteService,
    private router: Router
  ) {
    this.api = apiRoute.backendRoute();
  }
  public getEventsList(){
    return this.httpClient.get<EventViewModel[]>(this.api + 'events');
  }

  public deleteEvent(id: number){
    return this.httpClient
    .delete(
      this.api + 'events/' + id);
  }

  public postEvent(title: String, description: String, endDate: Date, startDate: Date){
    return this.httpClient
    .post(this.api + 'events'
    ,{Title: title, Description: description, EndDate: endDate, StartDate: startDate});
  }

  public putEvent(id: number, title: String, description: String, endDate: Date, startDate: Date){
    return this.httpClient
    .put(this.api + 'events/' + id,
    {EventId: id,Title: title, Description: description,EndDate: endDate,StartDate: startDate});
  }

}
