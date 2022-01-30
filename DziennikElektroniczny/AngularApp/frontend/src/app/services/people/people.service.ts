import { HttpClient,HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiRouteService } from 'src/app/globals/api-route.service';
import { AccountService } from '../account/account.service';
import {PersonViewModel} from 'src/app/models/Person'


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

  public getPerson(id:number){
    let person: PersonViewModel[] = [];
    let params = new HttpParams();
    params = params.append("id",id);
    this.httpClient
    .get<PersonViewModel[]>(
      this.api + 'People',
      {params:params}
    )
    .subscribe(
      (response) => {
        response.forEach(element => {
            person.push(new PersonViewModel(
            element["id"],
            element["role"],
            element["login"],
            element["personalInfoId"],
            element["name"],
            element["secondName"],
            element["surname"],
            element["dateOfBirth"],
            element["phoneNumber"],
            element["address"],
            element["pesel"]
          ))
        });
      }
    )
    return person;
  }
}
