import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { catchError, map, Observable } from 'rxjs';
import { PersonViewModel } from 'src/app/models/Person';
import { StudentsGroupViewModel } from 'src/app/models/StudentsGroup';
import { StudentsGroupMemberViewModel } from 'src/app/models/StudentsGroupMember';
import { PeopleService } from 'src/app/services/people/people.service';
import { PersonalDataService } from 'src/app/services/personalData/personal-data.service';
import { StudentsGroupService } from 'src/app/services/studentsGroup/studentsGroup.service';
import { StudentsGroupMemberService } from 'src/app/services/studentsGroupMember/studentsGroupMember.service';
import { CreatePersonDialogComponent } from '../create-person-dialog/create-person-dialog.component';

@Component({
  selector: 'app-create-student-group-dialog',
  templateUrl: './create-student-group-dialog.component.html',
  styleUrls: ['./create-student-group-dialog.component.scss'],
})
export class CreateStudentGroupDialogComponent implements OnInit {
  pageTitle: string;
  studentGroup: StudentsGroupViewModel;
  editMode: boolean;
  studentGroupMembers: StudentsGroupMemberViewModel[] = [];
  allStudents: PersonViewModel[] = [];
  alreadyEnrolledStudents: PersonViewModel[] = [];
  teachers: PersonViewModel[] = [];

  constructor(
    public dialogRef: MatDialogRef<CreatePersonDialogComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: {
      editMode: boolean;
      studentGroup: StudentsGroupViewModel;
    },
    private peopleService: PeopleService,
    private personalDataService: PersonalDataService,
    private studentGroupService: StudentsGroupService,
    private studentGroupMemberService: StudentsGroupMemberService
  ) {
    this.studentGroup = JSON.parse(JSON.stringify(data.studentGroup));
    this.pageTitle =
      data.editMode === true ? 'Edycja klasy' : 'Dodawanie klasy';
    this.editMode = data.editMode;
  }

  ngOnInit(): void {
    this.getStudentGroupMembers().subscribe(() => {
      debugger;
      this.peopleService.getAllStudents().subscribe(
        (students) => {
          this.allStudents = students;
          this.alreadyEnrolledStudents = this.allStudents.filter((student) => {
            const studentGroupMember = this.studentGroupMembers.find(
              (groupMember) => groupMember.studentPersonId == student.id
            );
            return studentGroupMember != undefined;
          });
        }
      );
    },
    (err) => {
      debugger;
      this.peopleService.getAllStudents().subscribe((students) => {
        this.allStudents = students;
      });
    });
    this.peopleService.getAllTeachers().subscribe((te) => (this.teachers = te));
  }

  private getStudentGroupMembers() {
    return this.studentGroupMemberService
      .getStudentGroupMembersByGroupId(this.studentGroup.id)
      .pipe(
        map((members) => {
          this.studentGroupMembers = members;
        })
      );
  }

  onCancel() {
    this.dialogRef.close();
  }
  public onSave() {
    if (this.editMode) {
      this.studentGroupService
        .updateStudentGroup(this.studentGroup)
        .subscribe((res) => {
          this.onCancel();
        });
    } else {
      this.studentGroupService
        .addStudentGroup(this.studentGroup)
        .subscribe((res) => {
          this.onCancel();
        });
    }
  }

  // this is running after updating alreadyEnrolledStudents list
  public changeSelection(data: any) {
    const updatedPerson: PersonViewModel = data.value;
    // if element is on the list means that was added
    const added =
      this.alreadyEnrolledStudents.find(
        (already) => already.id == updatedPerson.id
      ) != undefined;
    if (added) {
      this.saveGroupMember(updatedPerson);
    } else {
      this.deleteGroupMember(updatedPerson);
    }
  }

  private deleteGroupMember(person: PersonViewModel) {
    const studentGroupMember = this.studentGroupMembers.find(
      (groupMember) => groupMember.studentPersonId == person.id
    );
    if (studentGroupMember) {
      this.studentGroupMemberService
        .deleteStudentGroupMember(studentGroupMember.id)
        .subscribe(() => {
          this.getStudentGroupMembers();
        });
    } else return;
  }
  private saveGroupMember(person: PersonViewModel) {
    this.studentGroupMemberService
      .addStudentGroupMember(this.studentGroup.id, person.id)
      .subscribe((res) => {
        this.getStudentGroupMembers();
      });
  }
  currentSelectedTeacher() {
    const selectedTeacher = this.teachers.filter(
      (t) => t.id == this.studentGroup.teacherPersonId
    );
    if (selectedTeacher.length) return selectedTeacher[0];
    else return new PersonViewModel();
  }
}
