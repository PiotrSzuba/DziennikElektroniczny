import { Component, OnInit } from '@angular/core';
import { EventViewModel } from 'src/app/models/Event';
import { EventParticipatorViewModel } from 'src/app/models/EventParticipator';
import { StudentsGroupViewModel } from 'src/app/models/StudentsGroup';
import { StudentsGroupMemberViewModel } from 'src/app/models/StudentsGroupMember';
import { EventService } from 'src/app/services/event/event.service';
import { EventParticipatorService } from 'src/app/services/event/eventParticipator.service';
import {StudentsGroupService} from 'src/app/services/studentsGroup/studentsGroup.service';
import {StudentsGroupMemberService} from 'src/app/services/studentsGroupMember/studentsGroupMember.service';
import { DatePipe } from '@angular/common';
import { DateAdapter, ThemePalette } from '@angular/material/core';
import { FormControl } from '@angular/forms';
import * as moment from 'moment';
import { PersonViewModel } from 'src/app/models/Person';
import { AccountService } from 'src/app/services/account/account.service';
import { MessagesService } from 'src/app/services/messages/messages.service';
import {PeopleService} from 'src/app/services/people/people.service';

export interface CheckBoxes {
  name: string;
  completed: boolean;
  color: ThemePalette;
  subtasks?: CheckBoxes[];
}

@Component({
    selector: 'app-events',
    templateUrl: './events.component.html',
    styleUrls: ['./events.component.scss']
  })

  export class EventsComponent implements OnInit {
    eventsList: EventViewModel[] = [];
    classCheckBoxes: CheckBoxes[] = [];
    filteredEventsList: EventViewModel[] = [];
    participatorsEvents: EventParticipatorViewModel[] = [];
    eventsParticipators: EventParticipatorViewModel[] = [];
    filteredEventsParticipators: EventParticipatorViewModel[] = [];
    studentsGroups: StudentsGroupViewModel[] = [];
    studentsGroupMembers: StudentsGroupMemberViewModel[] = [];
    eventTitleSearch: String = "";
    eventDescriptionSearch: String = "";
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
    managingParticipants: boolean[];
    manageButtonName: String[];
    manageButtonManageName: String;
    manageButtonAcceptName: String;
    allComplete: boolean = false;
    allStudentGroup: boolean[] = [];
    selectedReceivers: PersonViewModel[] = [];

  constructor(
    private eventService: EventService,
    private eventParticipatorService: EventParticipatorService,
    private studentsGroupService: StudentsGroupService,
    private StudentsGroupMemberService: StudentsGroupMemberService,
    private peopleService: PeopleService,
    private accountService: AccountService,
    private messagesService: MessagesService,
    public datepipe: DatePipe, 
    private dateAdapter: DateAdapter<Date>) {
      this.dateAdapter.setLocale('pl-PL');
      this.participatorsEvents = [];
      this.eventsParticipators = [];
      this.studentsGroups = [];
      this.studentsGroupMembers = [];
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
      this.managingParticipants = [];
      this.manageButtonName = [];
      this.manageButtonManageName = "Zarządzaj uczestnikami";
      this.manageButtonAcceptName = "Akceptuj";
      this.classCheckBoxes = [];
  }

  ngOnInit(){
    this.accountService
    .getCurrentLoggedPerson()
    .then((res: PersonViewModel | undefined) => {
      if (res) {
        this.userId = res.id;
        this.userRole = res.role;
      }
    });
    //this.userId = 4; //testy
    //this.userRole = 1; //testy
    this.eventParticipatorService.getEventParticipator(parseInt(this.userId.toString())).subscribe(res => this.participatorsEvents = res);
    this.studentsGroups = this.studentsGroupService.getStudentsGroups();
    this.studentsGroupMembers = this.StudentsGroupMemberService.getStudentsGroupMembers();
    this.eventParticipatorService.getEventsParticipators().subscribe(res => this.eventsParticipators = res);

    this.eventService.getEventsList().subscribe(res => 
      {
        this.eventsList = res;
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
      });
  }

  setShowEditFormId(){
    for(let i = 0; i < this.eventsList.length; i++)
    {
      this.showEditFormId[this.eventsList[i].id] = false;
      this.editButtonName[this.eventsList[i].id] = this.editEventButtonEditName;
      this.deleteCancelButtonName[this.eventsList[i].id] = this.deleteButtonName;
      this.manageButtonName[this.eventsList[i].id] = this.manageButtonManageName;
      this.managingParticipants[this.eventsList[i].id] = false;
    }
    this.editingEvent = false;
    this.editingDivOpen = -1;
    this.classCheckBoxes = [];
    this.allStudentGroup = [];
  }

  checkRole(): boolean {
    if(this.userRole >= this.minRole){
      return true;
    }
    else{
      return false;
    }
  }

  formatDate(date: Date) {
    return this.datepipe.transform(date, 'dd.MM.yyyy HH:mm','UTC +1');
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
      if(this.startDate > this.endDate){     

        alert(" Data startowa powinna być wcześniej niż końcowa");
        return; 
      }
      this.cancelCreateEvent();
      this.eventService.postEvent(this.newTitle,this.newDescription, this.endDate,this.startDate).subscribe(res => window.location.reload());
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

  manageParticipants(eventId: Number){
    if(this.managingParticipants[parseInt(eventId.toString())]){
      for(let i = 0; i < this.classCheckBoxes.length; i++){
        if(this.classCheckBoxes[i].subtasks!.length > 0){
          for(let j = 0; j < this.classCheckBoxes[i].subtasks!.length; j++){
            var statusBefore = this.setParticipationStatus(this.classCheckBoxes[i].subtasks![j].name);
            if(this.classCheckBoxes[i].subtasks![j].completed != statusBefore){
              var personId = this.getPersonId(this.classCheckBoxes[i].subtasks![j].name);
              if(this.classCheckBoxes[i].subtasks![j].completed){
                if(personId > 0){
                  this.peopleService.getPerson(parseInt(personId.toString())).subscribe((res) =>{
                    this.selectedReceivers = res;
                    this.messagesService.sendMsg(this.selectedReceivers, "Zapisany do wydarzenia", "Zostałeś zapisany do wydarzenia: " + this.getEventName(eventId));
                    this.eventParticipatorService.postEventsParticipator(parseInt(eventId.toString()),parseInt(personId.toString()))
                    .subscribe(res => { });
                });
                }
              }
              else{
                var participatorId = this.getParticipatorId( this.classCheckBoxes[i].subtasks![j].name)
                if( participatorId > 0){
                  this.peopleService.getPerson(parseInt(personId.toString())).subscribe((res) =>{
                    this.selectedReceivers = res;
                    this.messagesService.sendMsg(this.selectedReceivers, "Wypisany z wydarzenia", "Zostałeś wypisany z wydarzenia: " + this.getEventName(eventId));
                });
                this.eventParticipatorService.deleteEventsParticipator(parseInt(participatorId.toString()))
                .subscribe((res) => { window.location.reload()});
                }
              }
            }
          }
        }
      }
      this.cancelManageParticipants(eventId);
      window.location.reload();
      return;
    }
    this.setShowEditFormId();
    this.cancelCreateEvent();
    this.managingParticipants[parseInt(eventId.toString())] = true;
    this.manageButtonName[parseInt(eventId.toString())] = this.manageButtonAcceptName;
    this.filteredEventsParticipators = this.eventsParticipators.filter(s => s.eventId == eventId);
    this.checkBoxesCreator();
  }

  getPersonId(personName: String): Number{
    for(let i = 0; i < this.studentsGroupMembers.length; i++){
      if(this.studentsGroupMembers[i].studentDisplayName.toLowerCase().includes(personName.toLowerCase())){
        return this.studentsGroupMembers[i].studentPersonId;
      }
    }
    return 0;
  }

  getEventName(eventId: Number): String{
    for(let i = 0; i < this.eventsList.length; i++){
      if(this.eventsList[i].id == eventId){
        return this.eventsList[i].title;
      }
    }
    return "error";  
  }

  getParticipatorId(personName: String): Number{
    for(let i = 0; i < this.filteredEventsParticipators.length; i++){
      if(this.filteredEventsParticipators[i].personName.toLowerCase().includes(personName.toLowerCase())){
        return this.filteredEventsParticipators[i].id;
      }
    }
    return 0;
  }

  cancelManageParticipants(eventId: Number){
    this.manageButtonName[parseInt(eventId.toString())] = this.manageButtonManageName;
    this.managingParticipants[parseInt(eventId.toString())] = false;
    this.classCheckBoxes = [];
    this.allStudentGroup = [];
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
    this.setDefaultManageButtonName();
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
      if(this.startDate > this.endDate){     

        alert(" Data startowa powinna być wcześniej niż końcowa");
        return; 
      }
      this.eventService.putEvent(parseInt(eventId.toString()),this.editedTitle,this.editedDescription, this.endDate,this.startDate )
      .subscribe(res => window.location.reload());
      this.editingDivOpen = eventId;
      this.editButtonName[parseInt(eventId.toString())] = this.editEventButtonEditName;
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
      this.eventService.deleteEvent(parseInt(eventId.toString())).subscribe((res) => window.location.reload());
      this.setShowEditFormId(); 
    }
    this.deletingEvent = true;
    this.deleteCancelButtonName[parseInt(eventId.toString())] = "Na pewno ?"; 
  }

  setDefaultManageButtonName(){
    for(let i = 0; i < this.eventsList.length; i++)
    {
      this.manageButtonName[this.eventsList[i].id] = this.manageButtonManageName;
      this.managingParticipants[this.eventsList[i].id] = false;
    }
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

  setParticipationStatus(personName: String): boolean{
    for(let i = 0; i < this.filteredEventsParticipators.length; i++){
      if(this.filteredEventsParticipators[i].personName.toLowerCase().includes(personName.toLowerCase())){
        return true;
      }
    }
  
    return false;
  }

  checkBoxesCreator(){
    for(let i = 0; i < this.studentsGroups.length; i++)
    {
      var subCheckBoxes: CheckBoxes[] = [];
      for(let j = 0; j < this.studentsGroups[i].studentsDisplayNames.length;j++){
        var newStudent: CheckBoxes = {
          name: this.studentsGroups[i].studentsDisplayNames[j],
          completed: this.setParticipationStatus(this.studentsGroups[i].studentsDisplayNames[j]), 
          color: 'warn'
        };
        subCheckBoxes.push(newStudent);
      }
      var newClass: CheckBoxes = {
        name: this.studentsGroups[i].title,
        completed: false,
        color: 'warn',
        subtasks: subCheckBoxes
      };
      this.classCheckBoxes.push(newClass);
      this.allStudentGroup[i] = false;
    }  
  }

  updateAllComplete(index: number) {
    this.allStudentGroup[index] = this.classCheckBoxes[index].subtasks != null && this.classCheckBoxes[index].subtasks!.every(t => t.completed);
  }

  someComplete(index: number): boolean {
    if (this.classCheckBoxes[index].subtasks == null) {
      return false;
    }
    return this.classCheckBoxes[index].subtasks!.filter(t => t.completed).length > 0 && !this.allComplete;
  }

  setAll(completed: boolean,index: number){
    this.allStudentGroup[index] = completed;
    if (this.classCheckBoxes[index].subtasks == null) {
      return;
    }
    this.classCheckBoxes[index].subtasks!.forEach(t => (t.completed = completed));
  }
}