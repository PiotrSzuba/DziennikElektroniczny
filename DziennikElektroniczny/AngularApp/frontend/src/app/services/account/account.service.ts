import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
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
        }

        return res;
      });
  }

  public getCurrentLoggedPerson() {

    return this.httpClient.options<PersonViewModel>(this.api + 'People').toPromise();
  }
}
// todo logowanie, powitalna strona, navbar
