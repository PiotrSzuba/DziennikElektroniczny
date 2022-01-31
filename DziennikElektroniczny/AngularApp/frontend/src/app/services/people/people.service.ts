import { HttpClient,HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { ApiRouteService } from 'src/app/globals/api-route.service';
import { PersonViewModel } from 'src/app/models/Person';
import { AccountService } from '../account/account.service';
import { PersonalDataService } from '../personalData/personal-data.service';


@Injectable({
  providedIn: 'root',
})
export class PeopleService {
  private api: string;
  constructor(
    private httpClient: HttpClient,
    private apiRoute: ApiRouteService,
    private accountService: AccountService,
    private personalDataService: PersonalDataService
  ) {
    this.api = apiRoute.backendRoute();
  }

  public deletePerson(id: number) {
    return this.httpClient.delete(this.api + 'People/' + id);
  }

  public editPerson(person: PersonViewModel) {
    person.personId = person.id;
    person.hashedPassword = '0';
    return this.httpClient.put<PersonViewModel>(
      this.api + 'People/' + person.id,
      { Id: person.id }
    );
  }

  public addPerson(person: PersonViewModel) {
    person.personalInfoId = 0;
    return this.personalDataService.createPersonalData(person).pipe(
      map((res) => {
        person.personalInfoId = res.personalInfoId;
        person.personId = 0;
        return this.httpClient.post<PersonViewModel>(
          this.api + 'People',
          person
        );
      })
    );
  }
  public getAllTeachers() {
    // "I know that this solution is bad, but i have to time to do this properly." ~ Paulo Coehlo
    return this.getAllPersons().pipe(
      map((persons) => {
        return persons.filter((p) => p.role == 3);
      })
    );
  }
  public getAllStudents() {
    return this.getAllPersons().pipe(
      map((persons) => {
        return persons.filter((p) => p.role == 1);
      })
    );
  }
  public getAllPersons() {
    return this.httpClient.get<PersonViewModel[]>(this.api + 'People');
  }


  public getPerson(id: number) {
    let params = new HttpParams().set('id', id)
    return this.httpClient.get<PersonViewModel[]>(this.api + 'People', { params: params })
  }

}
