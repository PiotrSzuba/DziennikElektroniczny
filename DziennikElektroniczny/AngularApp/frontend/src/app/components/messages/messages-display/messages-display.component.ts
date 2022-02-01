import { Component, OnInit, Input } from '@angular/core';
import { Message } from 'src/app/models/Message';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-messages-display',
  templateUrl: './messages-display.component.html',
  styleUrls: ['./messages-display.component.scss']
})
export class MessagesDisplayComponent implements OnInit {
  @Input() messages: Message[] = [];
  @Input() received: boolean = true;
  constructor(public datepipe: DatePipe,) {}

  ngOnInit(): void {} 

  formatDate(date: string): any {
    return this.datepipe.transform(date, 'dd.MM.yyyy HH:mm','UTC +1');
  }
}
