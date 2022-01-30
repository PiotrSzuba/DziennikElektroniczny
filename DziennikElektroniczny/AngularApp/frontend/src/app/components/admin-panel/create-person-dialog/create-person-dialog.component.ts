import { Component, Inject, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { PersonViewModel } from 'src/app/models/Person';
import { PeopleService } from 'src/app/services/people/people.service';
import { PersonalDataService } from 'src/app/services/personalData/personal-data.service';

@Component({
  selector: 'app-create-person-dialog',
  templateUrl: './create-person-dialog.component.html',
  styleUrls: ['./create-person-dialog.component.scss'],
})
export class CreatePersonDialogComponent implements OnInit {
  pageTitle: string;
  person: PersonViewModel;
  editMode: boolean;

  constructor(
    public dialogRef: MatDialogRef<CreatePersonDialogComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: {
      editMode: boolean;
      person: PersonViewModel;
    },
    private peopleService: PeopleService,
    private personalDataService: PersonalDataService
  ) {
    this.person = JSON.parse(JSON.stringify(data.person));
    this.pageTitle = data.editMode === true ? 'Edycja osoby' : 'Dodwanie osoby';
    this.editMode = data.editMode;
  }

  public roleList = ['Uczeń', 'Rodzic', 'Nauczyciel', 'Admin'];
  ngOnInit(): void {}

  onCancel() {
    this.dialogRef.close();
  }

  onSave() {
    if (this.data.editMode) {
      this.personalDataService
        .updatePersonalData(this.person.personalInfoId, this.person)
        .subscribe((res) => {
          this.dialogRef.close();
        });
    } else {
      this.peopleService.addPerson(this.person).subscribe((res) => {
        res.subscribe((res) => {
          this.dialogRef.close();
        });
      });
    }
  }
}
