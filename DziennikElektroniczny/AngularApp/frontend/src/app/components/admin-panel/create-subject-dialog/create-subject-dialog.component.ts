import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ClassroomViewModel } from 'src/app/models/Classroom';
import { PersonViewModel } from 'src/app/models/Person';
import { SubjectViewModel } from 'src/app/models/Subject';
import { ClassroomService } from 'src/app/services/classroom/classroom.service';
import { PeopleService } from 'src/app/services/people/people.service';
import { PersonalDataService } from 'src/app/services/personalData/personal-data.service';
import { SubjectService } from 'src/app/services/subject/subject.service';
import { CreatePersonDialogComponent } from '../create-person-dialog/create-person-dialog.component';

@Component({
  selector: 'app-create-subject-dialog',
  templateUrl: './create-subject-dialog.component.html',
  styleUrls: ['./create-subject-dialog.component.scss'],
})
export class CreateSubjectDialogComponent implements OnInit {
  public subject: SubjectViewModel;
  public editMode: boolean;
  public pageTitle: string;
  public teachers: PersonViewModel[] = Array();
  public classrooms: ClassroomViewModel[] = Array();
  constructor(
    public dialogRef: MatDialogRef<CreateSubjectDialogComponent>,
    private peopleService: PeopleService,
    private classroomService: ClassroomService,
    private subjectService: SubjectService,
    @Inject(MAT_DIALOG_DATA)
    public data: {
      editMode: boolean;
      subject: SubjectViewModel;
    }
  ) {
    this.subject = JSON.parse(JSON.stringify(data.subject));
    this.pageTitle =
      data.editMode === true ? 'Edycja przedmiotu' : 'Dodawanie przedmiotu';
    this.editMode = data.editMode;
  }

  ngOnInit(): void {
    this.peopleService
      .getAllTeachers()
      .subscribe((teach) => (this.teachers = teach));
    this.classroomService
      .getClassrooms()
      .subscribe((classrooms) => (this.classrooms = classrooms));
  }

  onCancel() {
    this.dialogRef.close();
  }
  onSave() {
    if (this.editMode) {
      //this.subjectService.updateSubject().
    } else {
    }
    this.dialogRef.close();
  }
  currentSelectedTeacher() {
    const selectedTeacher = this.teachers.filter(
      (t) => t.id == this.subject.teacherPersonId
    );
    if (selectedTeacher.length) return selectedTeacher[0];
    else return new PersonViewModel();
  }
  currentSelectedClassroom() {
    const selectedClassroom = this.classrooms.filter(
      (c) => c.id == this.subject.classRoomId
    );
    if (selectedClassroom.length) return selectedClassroom[0];
    else return new ClassroomViewModel();
  }
}
