import { Component, OnInit, Input } from '@angular/core';
import { Message } from 'src/app/models/Message';

@Component({
  selector: 'app-messages-display',
  templateUrl: './messages-display.component.html',
  styleUrls: ['./messages-display.component.scss']
})
export class MessagesDisplayComponent implements OnInit {
  @Input() messages: Message[] = [];
  @Input() received: boolean = true;
  constructor() {}

  ngOnInit(): void {} 
}
