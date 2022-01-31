import { Component, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { PersonViewModel } from 'src/app/models/Person';
import { StudentsGroupService } from 'src/app/services/studentsGroup/studentsGroup.service';
import { StudentsGroupMemberService } from 'src/app/services/studentsGroupMember/studentsGroupMember.service';
import { AccountService } from 'src/app/services/account/account.service';
import { MessagesService } from 'src/app/services/messages/messages.service';
import {PeopleService} from 'src/app/services/people/people.service';
import { StudentsGroupViewModel } from 'src/app/models/StudentsGroup';
import { StudentsGroupMemberViewModel } from 'src/app/models/StudentsGroupMember';
import {NoteViewModel} from 'src/app/models/Note'
import {NoteService} from 'src/app/services/notes/note.service';
import { DatePipe } from '@angular/common';
import { ParentService } from 'src/app/services/parent/parent.service';
import { Parent } from 'src/app/models/Parent';

export interface CheckBoxes {
    name: string;
    completed: boolean;
    color: ThemePalette;
    subtasks?: CheckBoxes[];
  }

@Component({
    selector: 'app-notes',
    templateUrl: './notes.component.html',
    styleUrls: ['./notes.component.scss']
  })

export class NotesComponent implements OnInit {

    creatingNewNote: boolean = false;
    createNewButtonName: String = "Stwórz";
    userId: Number = 0;
    userRole: Number = 0;
    minRole: Number = 3;
    newDescription: String = "";
    classCheckBoxes: CheckBoxes[] = Array();
    allStudentGroup: boolean[] = Array();
    studentsGroups: StudentsGroupViewModel[] = this.studentsGroupService.getStudentsGroups();
    studentsGroupMembers: StudentsGroupMemberViewModel[] = this.StudentsGroupMemberService.getStudentsGroupMembers();
    allNotes: NoteViewModel[] = Array();
    parents: Parent[] = Array();
    selectedReceivers: PersonViewModel[] = Array();
    allComplete: boolean = false;
    
    constructor(
        private studentsGroupService: StudentsGroupService,
        private StudentsGroupMemberService: StudentsGroupMemberService,
        private peopleService: PeopleService,
        private accountService: AccountService,
        private messagesService: MessagesService, 
        private noteService: NoteService,
        private parentService: ParentService,
        public datepipe: DatePipe,){

    };



    ngOnInit(){
      this.accountService
      .getCurrentLoggedPerson()
      .then((res: PersonViewModel | undefined) => {
        if (res) {
          this.userId = res.id;
          this.userRole = res.role;
          //this.userId = 2; //testy
          //this.userRole = 1; //testy
          this.getNoteSList();
        }
      });
    }

    getNoteSList(){
        if(this.userRole <= 2){
              this.noteService.getNotesStudent(parseInt(this.userId.toString())).subscribe((res) => (this.allNotes = res));
        }
        if(this.userRole == 3){
          this.noteService.getNotesTeacher(parseInt(this.userId.toString())).subscribe((res) => (this.allNotes = res));
        }

        if(this.userRole == 4){
            this.noteService.getNotes().subscribe((res) => (this.allNotes = res));
        }
    }

    getParents(studentId: number){
        this.parentService.getParentsStudId(studentId).subscribe((res) => (this.parents = res));
    }

    checkRole(): boolean {
        if(this.userRole >= this.minRole){
          return true;
        }
        else{
          return false;
        }
      }

    async createNote(){
        if(this.creatingNewNote){
            for(let i = 0; i < this.classCheckBoxes.length; i++){
                if(this.classCheckBoxes[i].subtasks!.length > 0){
                    for(let j = 0; j < this.classCheckBoxes[i].subtasks!.length; j++){
                        if(this.classCheckBoxes[i].subtasks![j].completed){
                            var personId = this.getPersonId(this.classCheckBoxes[i].subtasks![j].name);
                            if(personId > 0){
                               this.peopleService.getPerson(parseInt(personId.toString())).subscribe((res) =>{
                                (this.selectedReceivers = res);
                                this.messagesService.sendMsg(this.selectedReceivers, "Uwaga", "Nowa uwaga na koncie ucznia");
                                this.noteService.postNote(this.newDescription,new Date(),parseInt(this.userId.toString()),parseInt(personId.toString()))
                                .subscribe((res) => window.location.reload());
                                });
                            }
                        }
                    }
                }
            }
            this.cancelCreateNote();
            return;
        }
        this.checkBoxesCreator();
        this.creatingNewNote = true;
        this.createNewButtonName = "Akceptuj";
    }

    getPersonId(personName: String): Number{
        for(let i = 0; i < this.studentsGroupMembers.length; i++){
          if(this.studentsGroupMembers[i].studentDisplayName.toLowerCase().includes(personName.toLowerCase())){
            return this.studentsGroupMembers[i].studentPersonId;
          }
        }
        return 0;
    }

    cancelCreateNote(){
        this.creatingNewNote = false;
        this.createNewButtonName = "Stwórz";
        this.classCheckBoxes = [];
    }

    onSubmitNewNote(){
        return this.newDescription;
    }

    deleteNote(id: Number){
      this.noteService.deleteNote(parseInt(id.toString())).subscribe((res) =>  window.location.reload());
    }

    checkBoxesCreator(){
        for(let i = 0; i < this.studentsGroups.length; i++)
        {
          var subCheckBoxes: CheckBoxes[] = [];
          for(let j = 0; j < this.studentsGroups[i].studentsDisplayNames.length;j++){
            var newStudent: CheckBoxes = {
              name: this.studentsGroups[i].studentsDisplayNames[j],
              completed: false, 
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

    formatDate(date: Date): any {
        return this.datepipe.transform(date, 'dd.MM.yyyy HH:mm','UTC +1');
      }
}
