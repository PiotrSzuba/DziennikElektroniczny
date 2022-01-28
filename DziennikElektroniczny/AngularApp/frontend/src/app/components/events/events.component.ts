import { Component, OnInit } from '@angular/core';
import { EventViewModel } from 'src/app/models/Event';
import { EventParticipatorViewModel } from 'src/app/models/EventParticipator';
import { EventService } from 'src/app/services/event/event.service';
import { EventParticipatorService } from 'src/app/services/event/eventParticipator.service';
import { DatePipe } from '@angular/common';
import { DateAdapter } from '@angular/material/core';
import { FormControl } from '@angular/forms';
import * as moment from 'moment';

@Component({
    selector: 'app-events',
    templateUrl: './events.component.html',
    styleUrls: ['./events.component.scss']
  })
  export class EventsComponent implements OnInit {
    eventsList: EventViewModel[];
    filteredEventsList: EventViewModel[];
    participatorsEvents: EventParticipatorViewModel[];
    eventTitleSearch: String;
    eventDescriptionSearch: String;
    userId: Number;
    userRole: Number;
    minRole: Number;
    showRestricted: Boolean;
    createEventButtonName: String;
    createEventButtonCreateName: String;
    createEventButtonAcceptName: String;
    creatingNewEvent: Boolean;
    newTitle: String;
    newDescription: String;
    editEventButtonEditName: String;
    editEventButtonAcceptName: String;
    editedTitle: String;
    editedDescription: String;
    editingEvent: boolean;
    deletingEvent: boolean;
    editingDivOpen: Number;
    showEditFormId: boolean[];
    editButtonName: String[];
    deleteButtonName: String;
    editCancelButtonName: String;
    deleteCancelButtonName: String[];
    startDate: Date;
    endDate: Date;
    newStartDateForm = new FormControl();
    newEndDateForm = new FormControl();
    newStartTimeForm = new FormControl();
    newEndTimeForm = new FormControl();
    editStartDateForm = new FormControl();
    editEndDateForm = new FormControl();
    editStartTimeForm = new FormControl();
    editEndTimeForm = new FormControl(); 
    startTime: Date;
    endTime: Date;
    participationFilterValue: boolean;

  constructor(
    private eventService: EventService,
    private eventParticipatorService: EventParticipatorService,
    public datepipe: DatePipe, 
    private dateAdapter: DateAdapter<Date>) {
      this.dateAdapter.setLocale('pl-PL'); 
      this.eventsList = [];
      this.filteredEventsList = [];
      this.participatorsEvents = [];
      this.eventTitleSearch = "";
      this.eventDescriptionSearch = "";
      this.userId = 0;
      this.userRole = 0;
      this.minRole = 3;
      this.showRestricted = false;
      this.createEventButtonCreateName = "Stwórz";
      this.createEventButtonAcceptName = "Akceptuj";
      this.createEventButtonName = this.createEventButtonCreateName;
      this.creatingNewEvent = false;
      this.newTitle = "";
      this.newDescription = "";
      this.deleteButtonName = "Usuń";
      this.editCancelButtonName = "Anuluj";
      this.deleteCancelButtonName = [];
      this.editEventButtonEditName = "Edytuj";
      this.editEventButtonAcceptName = "Akceptuj";
      this.editedTitle = "";
      this.editedDescription = "";
      this.editingEvent = false;
      this.deletingEvent = false;
      this.editingDivOpen = -1;
      this.showEditFormId = [];
      this.editButtonName = [];
      this.startDate = new Date();
      this.endDate = new Date();
      this.startTime = new Date();
      this.endTime = new Date();
      this.participationFilterValue = false;
  }

  //wpisywanie ludzi i wypisywanie

  resolveFixer() {
    return new Promise(resolve => {
      setTimeout(() => {
        resolve('Jak to dziala');
      }, 1000);
    });
  }

  async ngOnInit(){
    this.userId = 5;
    this.userRole = 4;
    this.eventsList = await this.eventService.getEventsList();
    this.participatorsEvents = this.eventParticipatorService.getEventParticipator(parseInt(this.userId.toString()));
    await this.resolveFixer();
    if(this.userRole < this.minRole){
      var tempList: EventViewModel[] = [];
      for(let i = 0; i < this.participatorsEvents.length; i++){
        for(let j = 0; j < this.eventsList.length; j++){
          if(this.eventsList[j].id == this.participatorsEvents[i].eventId){
            tempList.push(this.eventsList[j]);
            break;
          }
        }
      }
      this.eventsList = tempList;
    }
    this.filteredEventsList = this.eventsList;
    this.filteredEventsList = this.filteredEventsList.sort((a, b) => +new Date(b.startDate) - +new Date(a.startDate));
    this.setShowEditFormId();
  }

  setShowEditFormId(){
    for(let i = 0; i < this.eventsList.length; i++)
    {
      this.showEditFormId[this.eventsList[i].id] = false;
      this.editButtonName[this.eventsList[i].id] = this.editEventButtonEditName;
      this.deleteCancelButtonName[this.eventsList[i].id] = this.deleteButtonName;
    }
    this.editingEvent = false;
    this.editingDivOpen = -1;
  }

  checkRole(): boolean {
    if(this.userRole >= this.minRole){
      return true;
    }
    else{
      return false;
    }
  }

  formatDate(date: Date): any {
    return this.datepipe.transform(date, 'dd.MM.yyyy HH:mm');
  }

  onSubmitTitle(){
    return this.eventTitleSearch;
  }

  onSubmitDescription(){
    return this.eventDescriptionSearch;
  }

  search(){
    this.filteredEventsList = this.eventsList.filter(s => s.title
      .toLowerCase()
      .includes(this.eventTitleSearch.toString().toLowerCase()));
    this.filteredEventsList = this.filteredEventsList.filter(s =>s.description
      .toLowerCase()
      .includes(this.eventDescriptionSearch.toString().toLowerCase()));
    if(this.participationFilterValue){
      var tempList: EventViewModel[] = [];
      for(let i = 0; i < this.participatorsEvents.length; i++){
        for(let j = 0; j < this.filteredEventsList.length; j++){
          if(this.filteredEventsList[j].id == this.participatorsEvents[i].eventId){
            tempList.push(this.filteredEventsList[j]);
            break;
          }
        }
      }
      this.filteredEventsList = tempList;
      tempList = [];  
    }
    this.filteredEventsList = this.filteredEventsList.sort((a, b) => +new Date(b.endDate) - +new Date(a.endDate));
  }

  createEvent(){
    this.setShowEditFormId();
    if(this.creatingNewEvent){
      if(this.newTitle.length == 0){
        alert(" Pole tytuł jest puste ! ");
        return;
      }
      if(this.newDescription.length == 0){
        alert(" Pole opis jest puste ! ");
        return;
      }
      this.onSubmitNewEvent();
      if(this.startDate < new Date()){
        alert(" Data startowa powinna być minimalnie aktualna");
        return; 
      }
      if(this.startDate > this.endDate){     

        alert(" Data startowa powinna być wcześniej niż końcowa");
        return; 
      }
      this.eventService.postEvent(this.newTitle,this.newDescription, this.endDate,this.startDate);
      this.cancelCreateEvent();
      window.location.reload();
      return;
    }
    this.showRestricted = true;
    this.creatingNewEvent = true;
    this.createEventButtonName = this.createEventButtonAcceptName;
  }

  cancelCreateEvent(){
    this.showRestricted = false;
    this.creatingNewEvent = false;
    this.createEventButtonName = "Stwórz";
  }

  onSubmitNewEvent(){
    this.startDate = this.newStartDateForm.value;
    this.endDate = this.newEndDateForm.value;
    let start = this.newStartTimeForm.value;
    let end  = this.newEndTimeForm.value;

    let parsedDate = moment(start,"HH:mm").toDate();
    this.startDate.setHours(parsedDate.getHours());
    this.startDate.setMinutes(parsedDate.getMinutes());

    parsedDate = moment(end,"HH:mm").toDate();
    this.endDate.setHours(parsedDate.getHours());
    this.endDate.setMinutes(parsedDate.getMinutes());
  }

  onSubmitEditEvent(){
    this.startDate = this.editStartDateForm.value;
    this.endDate = this.editEndDateForm.value;
    let start = this.editStartTimeForm.value;
    let end  = this.editEndTimeForm.value;

    let date = new Date(this.startDate);
    let formatedDate = moment(start,"HH:mm").toDate();
    date.setHours(formatedDate.getHours());
    date.setMinutes(formatedDate.getMinutes());
    this.startDate = date;

    date = new Date(this.endDate);
    formatedDate = moment(end,"HH:mm").toDate();
    date.setHours(formatedDate.getHours());
    date.setMinutes(formatedDate.getMinutes());
    this.endDate = date;
  }

  signIn(eventId: Number){
    alert("signIn" + eventId.toString());  
  }

  signOut(eventId: Number){
    alert("signOut" + eventId.toString());  
  }

  editEvent(eventId: Number,index: number){
    if(this.editingDivOpen == -1){
      this.editStartDateForm = new FormControl(this.eventsList[index].startDate);
      this.editEndDateForm = new FormControl(this.eventsList[index].endDate);
      let dateS = new Date(this.eventsList[index].startDate);
      let dateE = new Date(this.eventsList[index].endDate);
      this.editStartTimeForm = new FormControl(dateS.getHours() + ":" + dateS.getMinutes());
      this.editEndTimeForm = new FormControl(dateE.getHours() + ":" + dateE.getMinutes());
      this.editingDivOpen = eventId;
      this.editButtonName[parseInt(eventId.toString())] = this.editEventButtonAcceptName;
      this.deleteCancelButtonName[parseInt(eventId.toString())] = this.editCancelButtonName;
      this.editedTitle = this.eventsList[index].title;
      this.editedDescription = this.eventsList[index].description;
    }
    if(eventId != this.editingDivOpen){
      this.editStartDateForm = new FormControl(this.eventsList[index].startDate);
      this.editEndDateForm = new FormControl(this.eventsList[index].endDate);
      let dateS = new Date(this.eventsList[index].startDate);
      let dateE = new Date(this.eventsList[index].endDate);
      this.editStartTimeForm = new FormControl(dateS.getHours() + ":" + dateS.getMinutes());
      this.editEndTimeForm = new FormControl(dateE.getHours() + ":" + dateE.getMinutes());
      this.showEditFormId[parseInt(this.editingDivOpen.toString())] = false;
      this.editButtonName[parseInt(this.editingDivOpen.toString())] = this.editEventButtonEditName;
      this.deleteCancelButtonName[parseInt(this.editingDivOpen.toString())] = this.deleteButtonName;
      this.editingDivOpen = eventId;
      this.editingEvent = true;
      this.showEditFormId[parseInt(eventId.toString())] = true;
      this.editButtonName[parseInt(eventId.toString())] = this.editEventButtonAcceptName;
      this.deleteCancelButtonName[parseInt(eventId.toString())] = this.editCancelButtonName;
      this.editedTitle = this.eventsList[index].title;
      this.editedDescription = this.eventsList[index].description;
      return;
    }
    this.cancelCreateEvent();
    if(this.editingEvent){
      if(this.editedTitle.length == 0){
        alert(" Pole tytuł jest puste ! ");
        return;
      }
      if(this.editedDescription.length == 0){
        alert(" Pole opis jest puste ! ");
        return;
      }
      this.onSubmitEditEvent();
      if(this.startDate < new Date()){
        alert(" Data startowa powinna być minimalnie aktualna");
        return; 
      }
      if(this.startDate > this.endDate){     

        alert(" Data startowa powinna być wcześniej niż końcowa");
        return; 
      }
      this.eventService.putEvent(parseInt(eventId.toString()),this.editedTitle,this.editedDescription, this.endDate,this.startDate );
      this.editingDivOpen = eventId;
      this.editButtonName[parseInt(eventId.toString())] = this.editEventButtonEditName;
      window.location.reload();
    }
    this.editingEvent = true;
    this.editingDivOpen = eventId;
    this.showEditFormId[parseInt(eventId.toString())] = true;

  }

  deleteEvent(eventId: Number){
    if(this.editingEvent){
        this.cancelCreateEvent();
        this.setShowEditFormId();
        return;
    }
    if(this.deletingEvent){
      this.eventService.deleteEvent(parseInt(eventId.toString()));
      window.location.reload();
      this.setShowEditFormId(); 
    }
    this.deletingEvent = true;
    this.deleteCancelButtonName[parseInt(eventId.toString())] = "Na pewno ?"; 
  }

  participationFilter(){
    this.participationFilterValue = !this.participationFilterValue;
    this.search();
  }

  checkIfParticipator(eventId: number,index: number): boolean{
    if(this.participationFilterValue){
      for(let i = 0; i < this.participatorsEvents.length; i++){
        if(this.participatorsEvents[i].eventId == eventId){
          return true;
        }
      }
    } 
    return false;
  }
}