import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpParams } from '@angular/common/http';
import { ApiRouteService } from '../../globals/api-route.service';
import { Message } from '../../models/Message';
import { PersonViewModel } from 'src/app/models/Person';
import { AccountService } from '../account/account.service';
import { catchError, map } from 'rxjs';


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
      .then((response: PersonViewModel | undefined) => {
        if (response) {
          params = new HttpParams().set(personIdMapper, response.id)
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

  public sendMsg(toPersons: PersonViewModel[], title: string, content: string){
    this.httpClient.post(this.api + 'MessageContents', {title: title, content: content})
    .pipe(
      map((response: any) => response['messageContentId'])
    )
    .subscribe(
      messageContentId => this._sendMsgForPersons(toPersons, messageContentId)
    )
  }

  private _sendMsgForPersons(toPersons: PersonViewModel[], messageContentId: number){
    this.accountService
      .getCurrentLoggedPerson()
      .then((response: PersonViewModel | undefined) => {
        if (response) {
          toPersons.forEach(element => {
            this.httpClient.post(this.api + 'Messages',
            {messageContentId: messageContentId, fromPersonId: response.id, toPersonId: element.id})
            .subscribe()
          })
        }
      });
  }
}
