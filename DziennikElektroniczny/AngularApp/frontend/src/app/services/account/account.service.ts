import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { ApiRouteService } from '../../globals/api-route.service';
import { Router } from '@angular/router';
import { PersonViewModel } from 'src/app/models/Person';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  private api: string;
  constructor(
    private httpClient: HttpClient,
    private apiRoute: ApiRouteService,
    private router: Router
  ) {
    this.api = apiRoute.backendRoute();
  }

  public login(login: string, password: string) {
    return this.httpClient
      .post(
        this.api + 'Login',
        { login: login, password: password },
        { observe: 'response' }
      )
      .toPromise()
      .then((res: HttpResponse<any> | undefined) => {
        if (res && res.status === 200) {
          localStorage.setItem('JWT', res.body.token);
          this.router.navigate(['']);
          this.getCurrentLoggedPerson().then((res) => {
            if (res) {
              localStorage.setItem('person', JSON.stringify(res));
            }
          });
        }

        return res;
      });
  }
 public getCurrentPersonFromLocalStorage(): PersonViewModel {
    const stringifiedPerson: string = localStorage.getItem('person') as string;
    return JSON.parse(stringifiedPerson);
  }

  public getCurrentLoggedPerson() {
    return this.httpClient
      .options<PersonViewModel>(this.api + 'People')
      .toPromise();
  }

  public getPerson(personId: number){
    const params = new HttpParams().set('id', personId)
    return this.httpClient.get<PersonViewModel[]>(this.api + 'People', { params: params })
  }

  public getAllPersons(): PersonViewModel[] {
    let persons: PersonViewModel[] = [];
    this.httpClient
      .get<PersonViewModel[]>(this.api + 'People')
      .subscribe((response) => {
        response.forEach((element) => {
          persons.push(
            new PersonViewModel(
              element['id'],
              element['role'],
              element['login'],
              element['personalInfoId'],
              element['name'],
              element['secondName'],
              element['surname'],
              element['dateOfBirth'],
              element['phoneNumber'],
              element['address'],
              element['pesel']
            )
          );
        });
        return response;
      });
    return persons;
  }
}
