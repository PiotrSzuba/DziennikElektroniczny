import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiRouteService } from 'src/app/globals/api-route.service';
import { AccountService } from '../account/account.service';

@Injectable({
  providedIn: 'root',
})
export class PeopleService {
  private api: string;
  constructor(
    private httpClient: HttpClient,
    private apiRoute: ApiRouteService,
    private accountService: AccountService
  ) {
    this.api = apiRoute.backendRoute();
  }

  public deletePerson(id:number){
    return this.httpClient.delete(this.api + "People/" + id);
  }
}
