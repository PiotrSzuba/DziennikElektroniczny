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
  public async getEventsList(){
    let events: EventViewModel[] = [];
    this.httpClient
    .get<EventViewModel[]>(
      this.api + 'events'
    )
    .subscribe(
      (response) => {
        response.forEach(element => {
          events.push(new EventViewModel(
            element["id"],
            element["title"],
            element["description"],
            element["endDate"],
            element["startDate"],
            element["participators"]
          ))
        });
        return events;
      }, (err) => {
      setTimeout(() => {},100)
      }
    )
    
    return events;
  }

  public deleteEvent(id: number){
    this.httpClient
    .delete(
      this.api + 'events/' + id)
      .subscribe();
  }

  public postEvent(title: String, description: String, endDate: Date, startDate: Date){
    this.httpClient
    .post(this.api + 'events'
    ,{Title: title, Description: description, EndDate: endDate, StartDate: startDate})
    .subscribe();
  }

  public putEvent(id: number, title: String, description: String, endDate: Date, startDate: Date){
    this.httpClient
    .put(
      this.api + 'events/' + id
      ,{EventId: id,Title: title, Description: description,EndDate: endDate,StartDate: startDate}
    )
    .subscribe();
  }

}
