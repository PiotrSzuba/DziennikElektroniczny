import { Component, Input, OnInit } from '@angular/core';
import {FormControl} from '@angular/forms';
import {Observable} from 'rxjs';
import {map, startWith} from 'rxjs/operators';
import { PersonViewModel } from 'src/app/models/Person';
import {CdkDragDrop, moveItemInArray} from '@angular/cdk/drag-drop';
import { MessagesService } from 'src/app/services/messages/messages.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-send-message',
  templateUrl: './send-message.component.html',
  styleUrls: ['./send-message.component.scss']
})
export class SendMessageComponent implements OnInit {
  @Input() persons: PersonViewModel[] = [];
  receiversControl: FormControl = new FormControl();
  topicControl: FormControl = new FormControl("");
  contentControl: FormControl = new FormControl("");
  options: string[] = ['One', 'Two', 'Three'];
  filteredReceivers: Observable<string[]> = new Observable<string[]>();
  selectedReceivers: PersonViewModel[] = [];
  receiverValid: boolean = true
  topicValid: boolean = true
  contentValid: boolean = true

  constructor(private messagesService: MessagesService, private router: Router) {}

  ngOnInit(): void {
    this.filteredReceivers = this.receiversControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value)),
    );
    this.receiversControl.valueChanges.subscribe( receiver => {
      let person = this.persons.find(person => (person.name + ' ' + person.surname) === receiver)
      if(person && this.selectedReceivers.filter(p => p.id === person?.id).length === 0){
        this.selectedReceivers.push(person)
        this.receiversControl.setValue('')
        this._validateReceivers()
      }
    })
    this.topicControl.valueChanges.subscribe(() => this._validateTopic())
    this.contentControl.valueChanges.subscribe(() => this._validateContent())
  }

  private _filter(value: string): string[] {
    const filterValue = value.toLowerCase();
    let filteredHints: string[] = []
    this.persons.filter(person => (person.name + ' ' + person.surname).toLowerCase().includes(filterValue)).forEach((element) => {
      filteredHints.push(element.name + ' ' + element.surname)
    })
    return filteredHints;
  }

  public removeSelectedReceiver(receiver: PersonViewModel){
    const index = this.selectedReceivers.indexOf(receiver)
    if(index >= 0){
      this.selectedReceivers.splice(index, 1)
    }
    this._validateReceivers()
  }

  private _validateReceivers(){
    this.receiverValid =  this.selectedReceivers.length != 0
  }

  private _getTopic(): string{
    return this.topicControl.value
  }

  private _getContent(): string{
    return this.contentControl.value
  }

  private _validateTopic(){
    this.topicValid = this._getTopic().length != 0
  }

  private _validateContent(){
    this.contentValid = this._getContent().length != 0
  }

  private _validateForm(){
    this._validateReceivers()
    this._validateTopic()
    this._validateContent()
  }

  private _isFormValid(){
    this._validateForm()
    return this.receiverValid && this.topicValid && this.contentValid
  }

  private _clear(){
    this.selectedReceivers = []
    this.topicControl.setValue('')
    this.contentControl.setValue('')
    this.topicValid = true
    this.contentValid = true
  }

  public send(){
    if(!this._isFormValid()){
      return
    }
    this.messagesService.sendMsg(this.selectedReceivers, this._getTopic(), this._getContent())
    this._clear()
  }
}
