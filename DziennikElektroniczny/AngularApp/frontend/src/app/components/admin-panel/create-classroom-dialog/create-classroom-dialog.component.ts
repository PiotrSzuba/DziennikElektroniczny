import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ClassroomViewModel } from 'src/app/models/Classroom';
import { PersonViewModel } from 'src/app/models/Person';
import { ClassroomService } from 'src/app/services/classroom/classroom.service';
import { PeopleService } from 'src/app/services/people/people.service';
import { PersonalDataService } from 'src/app/services/personalData/personal-data.service';
import { CreatePersonDialogComponent } from '../create-person-dialog/create-person-dialog.component';

@Component({
  selector: 'app-create-classroom-dialog',
  templateUrl: './create-classroom-dialog.component.html',
  styleUrls: ['./create-classroom-dialog.component.scss'],
})
export class CreateClassroomDialogComponent implements OnInit {
  public classroom: ClassroomViewModel;
  public editMode: boolean;
  public pageTitle: string;
  constructor(
    public dialogRef: MatDialogRef<CreateClassroomDialogComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: {
      editMode: boolean;
      classroom: ClassroomViewModel;
    },
    private classroomService: ClassroomService,
    private personalDataService: PersonalDataService
  ) {
    this.classroom = JSON.parse(JSON.stringify(data.classroom));
    this.pageTitle = data.editMode === true ? 'Edycja osoby' : 'Dodwanie osoby';
    this.editMode = data.editMode;
  }

  ngOnInit(): void {}

  onSave() {
    if (this.editMode) {
      this.classroomService.updateClassroom(this.classroom).subscribe(() => {
        this.onCancel();
      });
    } else {
      this.classroomService.addClassroom(this.classroom).subscribe(() => {
        this.onCancel();
      });
    }
  }
  onCancel() {
    this.dialogRef.close();
  }
}
