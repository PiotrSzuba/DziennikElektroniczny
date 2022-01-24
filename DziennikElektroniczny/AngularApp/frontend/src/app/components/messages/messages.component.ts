import { Component, OnInit } from '@angular/core';
import { Message } from 'src/app/models/Message';
import { MessagesService } from 'src/app/services/messages/messages.service';

@Component({
  selector: 'app-messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {
  receivedMsg: Message[];
  sendMsg: Message[];

  constructor(private messagesService: MessagesService) {
    this.receivedMsg = [];
    this.sendMsg = [];
  }

  ngOnInit(): void {
    this.receivedMsg = this.messagesService.getReceivedMsg();
    this.sendMsg = this.messagesService.getSendMsg();
  }
}
