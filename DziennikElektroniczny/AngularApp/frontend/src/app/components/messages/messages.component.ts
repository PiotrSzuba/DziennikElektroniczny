import { Component, OnInit } from '@angular/core';
import { Message } from 'src/app/models/Message';
import { PersonViewModel } from 'src/app/models/Person';
import { AccountService } from 'src/app/services/account/account.service';
import { MessagesService } from 'src/app/services/messages/messages.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {
  receivedMsg: Message[];
  sendMsg: Message[];
  persons: PersonViewModel[];

  constructor(private messagesService: MessagesService, private accountService: AccountService) {
    this.receivedMsg = [];
    this.sendMsg = [];
    this.persons = [];
  }

  ngOnInit(): void {
    this.receivedMsg = this.messagesService.getReceivedMsg();
    this.sendMsg = this.messagesService.getSendMsg();
    this.persons = this.accountService.getAllPersons();
  }

  public refreshReceivedMsg(){
    this.receivedMsg = this.messagesService.getReceivedMsg();
  }

  public refreshSentMsg(){
    this.sendMsg = this.messagesService.getSendMsg();
  }
}
