import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiRouteService } from 'src/app/globals/api-route.service';
import { PersonViewModel } from 'src/app/models/Person';
import { AccountService } from '../account/account.service';

@Injectable({
  providedIn: 'root',
})
export class PersonalDataService {
  private api: string;
  constructor(
    private httpClient: HttpClient,
    private apiRoute: ApiRouteService,
    private accountService: AccountService
  ) {
    this.api = apiRoute.backendRoute();
  }

  updatePersonalData(personalDataId: number, person: PersonViewModel) {
    return this.httpClient.put(
      this.api + 'PersonalInfos/' + personalDataId,
      person
    );
  }

  createPersonalData(person: PersonViewModel) {
    return this.httpClient.post<PersonViewModel>(
      this.api + 'PersonalInfos',
      person
    );
  }
}
