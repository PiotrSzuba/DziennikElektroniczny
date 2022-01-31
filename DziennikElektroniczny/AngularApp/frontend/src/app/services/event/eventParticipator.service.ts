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

    public getEventParticipator(personId: number){
        let params = new HttpParams();
        params = params.append("personId",personId);
        return this.httpClient.get<EventParticipatorViewModel[]>(this.api + 'EventParticipators',{params:params});
    }

    public getEventsParticipators(){
      return this.httpClient.get<EventParticipatorViewModel[]>(this.api + 'EventParticipators')
  }
  public postEventsParticipator(eventId: number,personId: number){
    return this.httpClient.post(this.api + 'EventParticipators',{EventId: eventId, PersonId: personId});
  }
  public deleteEventsParticipator(id: number){
    return this.httpClient
    .delete(this.api + 'EventParticipators/' + id);
  }
}