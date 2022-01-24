import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpParams } from '@angular/common/http';
import { ApiRouteService } from '../../globals/api-route.service';
import { Message } from '../../models/Message';
import { PersonViewModel } from 'src/app/models/Person';
import { AccountService } from '../account/account.service';


@Injectable({
  providedIn: 'root'
})
export class MessagesService {
  private api: string;
  constructor(
    private httpClient: HttpClient,
    private apiRoute: ApiRouteService,
    private accountService: AccountService
  ) {
    this.api = apiRoute.backendRoute();
  }

  public getReceivedMsg(): Message[]{
    return this.getMsg("toPersonId")
  }

  public getSendMsg(): Message[]{
    return this.getMsg("fromPersonId")
  }

  public getMsg(personIdMapper: string): Message[]{
    let params;
    let messages: Message[] = [];
    this.accountService
      .getCurrentLoggedPerson()
      .then((res: PersonViewModel | undefined) => {
        if (res) {
          params = new HttpParams().set(personIdMapper, res.id)
          this.httpClient
          .get<Message[]>(
            this.api + 'Messages',
            { params: params }
          )
          .subscribe(
            (response) => {
              response.forEach(element => {
                messages.push(new Message(
                  element["sendDate"],
                  element["seenDate"],
                  element["fromPersonName"],
                  element["toPersonName"],
                  element["title"],
                  element["content"]
                ))
              });
            }
          )
          return messages
        }
        return messages
      });
    return messages;
  }
}
