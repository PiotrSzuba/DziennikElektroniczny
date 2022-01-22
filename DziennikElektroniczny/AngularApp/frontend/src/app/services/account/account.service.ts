import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  constructor(private httpClient: HttpClient) {}

  public login(login: string, password: string) {
    this.httpClient
      .post('http://localhost:56849/api/Login', { login:login, password: password })
      .toPromise()
      .then((res) => {
        debugger;
      });
  }
}
// todo logowanie, powitalna strona, navbar