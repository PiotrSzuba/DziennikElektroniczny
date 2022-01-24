import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ApiRouteService {
  public port: string;
  constructor() {
    this.port = '56849';
  }

  backendRoute(): string {
    return 'http://localhost:' + this.port + '/api/';
  }
}
