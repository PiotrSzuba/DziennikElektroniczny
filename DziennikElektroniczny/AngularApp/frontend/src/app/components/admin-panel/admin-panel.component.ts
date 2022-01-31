import { Component, OnInit, TemplateRef, Type } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ClassroomViewModel } from 'src/app/models/Classroom';
import { PersonViewModel } from 'src/app/models/Person';
import { StudentsGroupViewModel } from 'src/app/models/StudentsGroup';
import { SubjectViewModel } from 'src/app/models/Subject';
import { AccountService } from 'src/app/services/account/account.service';
import { ClassroomService } from 'src/app/services/classroom/classroom.service';
import { PeopleService } from 'src/app/services/people/people.service';
import { StudentsGroupService } from 'src/app/services/studentsGroup/studentsGroup.service';
import { StudentsGroupMemberService } from 'src/app/services/studentsGroupMember/studentsGroupMember.service';
import { SubjectService } from 'src/app/services/subject/subject.service';
import { CreateClassroomDialogComponent } from './create-classroom-dialog/create-classroom-dialog.component';
import { CreatePersonDialogComponent } from './create-person-dialog/create-person-dialog.component';
import { CreateStudentGroupDialogComponent } from './create-student-group-dialog/create-student-group-dialog.component';
import { CreateSubjectDialogComponent } from './create-subject-dialog/create-subject-dialog.component';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss'],
})
export class AdminPanelComponent implements OnInit {
  public persons: PersonViewModel[] = Array();
  public subjects: SubjectViewModel[] = Array();
  public classrooms: ClassroomViewModel[] = Array();
  public studentGroups: StudentsGroupViewModel[] = Array();

  constructor(
    private accountService: AccountService,
    private peopleService: PeopleService,
    private dialog: MatDialog,
    private subjectService: SubjectService,
    private classroomService: ClassroomService,
    private studentGroupService: StudentsGroupService
  ) {}

  public roleList = ['Uczeń', 'Rodzic', 'Nauczyciel', 'Admin'];

  ngOnInit(): void {
    this.reloadPersons();
    this.reloadSubjects();
    this.reloadClassrooms();
    this.reloadStudentGroups();
  }
  private reloadPersons() {
    this.persons = this.accountService.getAllPersons();
  }
  private reloadSubjects() {
    this.subjectService
      .getAllAdminSubjects()
      .subscribe((res) => (this.subjects = res));
  }

  private reloadClassrooms() {
    this.classroomService
      .getClassrooms()
      .subscribe((res) => (this.classrooms = res));
  }
  private reloadStudentGroups() {
    this.studentGroupService
      .getAllStudentGroups()
      .subscribe((res) => (this.studentGroups = res));
  }

  public editPerson(person: PersonViewModel) {
    this.openPersonDialog({ person: person, editMode: true });
  }

  public deletePerson(person: PersonViewModel) {
    this.peopleService
      .deletePerson(person.id)
      .subscribe(() => this.reloadPersons());
  }

  private openPersonDialog(params: object): void {
    const dialogRef = this.dialog.open(CreatePersonDialogComponent, {
      data: params,
    });
    dialogRef.afterClosed().subscribe(() => {
      this.reloadPersons();
    });
  }

  addPerson() {
    this.openPersonDialog({ person: new PersonViewModel(), editMode: false });
  }

  deleteSubject(subject: SubjectViewModel) {
    this.subjectService
      .deleteSubject(subject.id)
      .subscribe(() => this.reloadSubjects());
  }

  editSubject(subject: SubjectViewModel) {
    this.openSubjectDialog({ subject: subject, editMode: true });
  }

  addSubject() {
    this.openSubjectDialog({
      subject: new SubjectViewModel(),
      editMode: false,
    });
  }

  openSubjectDialog(params: object) {
    const dialogRef = this.dialog.open(CreateSubjectDialogComponent, {
      data: params,
    });
    dialogRef.afterClosed().subscribe(() => {
      this.reloadSubjects();
    });
  }

  addClassroom() {
    this.openClassroomDialog({
      classroom: new ClassroomViewModel(),
      editMode: false,
    });
  }
  editClassroom(classroom: ClassroomViewModel) {
    this.openClassroomDialog({ classroom: classroom, editMode: true });
  }
  deleteClassroom(classroom: ClassroomViewModel) {
    this.classroomService
      .deleteClassroom(classroom.id)
      .subscribe(() => this.reloadClassrooms());
  }

  openClassroomDialog(params: object) {
    const dialogRef = this.dialog.open(CreateClassroomDialogComponent, {
      data: params,
    });
    dialogRef.afterClosed().subscribe(() => {
      this.reloadClassrooms();
    });
  }

  public deleteStudentGroup(sG: StudentsGroupViewModel) {
    this.studentGroupService
      .deleteStudentGroup(sG.id)
      .subscribe(() => this.reloadStudentGroups());
  }

  openStudentGroupDialog(params: object) {
    const dialogRef = this.dialog.open(CreateStudentGroupDialogComponent, {
      data: params,
    });
    dialogRef.afterClosed().subscribe(() => {
      this.reloadStudentGroups();
    });
  }

  addStudentGroup() {
    this.openStudentGroupDialog({
      studentGroup: new StudentsGroupViewModel(),
      editMode: false,
    });
  }
  editStudentGroup(studentGroup: StudentsGroupViewModel) {
    this.openStudentGroupDialog({ studentGroup: studentGroup, editMode: true });
  }


}
