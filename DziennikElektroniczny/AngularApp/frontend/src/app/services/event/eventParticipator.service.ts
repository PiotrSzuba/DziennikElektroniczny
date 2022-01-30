import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { ApiRouteService } from '../../globals/api-route.service';
import { Router } from '@angular/router';
import { EventParticipatorViewModel } from 'src/app/models/EventParticipator';

@Injectable({
    providedIn: 'root'
  })

  export class EventParticipatorService {
    private api: string;
    constructor(
      private httpClient: HttpClient,
      private apiRoute: ApiRouteService,
      private router: Router
    ) {
      this.api = apiRoute.backendRoute();
    }

    public getEventParticipator(personId: number): EventParticipatorViewModel[]{
        let participatorEvents: EventParticipatorViewModel[] = [];
        let params = new HttpParams();
        params = params.append("personId",personId);
        this.httpClient
        .get<EventParticipatorViewModel[]>(
          this.api + 'EventParticipators',
          {params:params}
        )
        .subscribe(
          (response) => {
            response.forEach(element => {
                participatorEvents.push(new EventParticipatorViewModel(
                element["id"],
                element["eventId"],
                element["eventName"],
                element["personId"],
                element["personName"]
              ))
            });
          }
        )
        return participatorEvents;
    }

    public getEventsParticipators(): EventParticipatorViewModel[]{
      let participatorEvents: EventParticipatorViewModel[] = [];
      let params = new HttpParams();
      this.httpClient
      .get<EventParticipatorViewModel[]>(
        this.api + 'EventParticipators',
        {params:params}
      )
      .subscribe(
        (response) => {
          response.forEach(element => {
              participatorEvents.push(new EventParticipatorViewModel(
              element["id"],
              element["eventId"],
              element["eventName"],
              element["personId"],
              element["personName"]
            ))
          });
        }
      )
      return participatorEvents;
  }
  public postEventsParticipator(eventId: number,personId: number){
    this.httpClient
    .post(this.api + 'EventParticipators',
    {EventId: eventId, PersonId: personId})
    .subscribe();
  }
  public deleteEventsParticipator(id: number){
    this.httpClient
    .delete(
      this.api + 'EventParticipators/' + id)
    .subscribe();
  }
}