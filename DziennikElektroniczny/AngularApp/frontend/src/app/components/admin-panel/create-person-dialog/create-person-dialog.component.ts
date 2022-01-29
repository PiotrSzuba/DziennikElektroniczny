import { Component, Inject, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PersonViewModel } from 'src/app/models/Person';

@Component({
  selector: 'app-create-person-dialog',
  templateUrl: './create-person-dialog.component.html',
  styleUrls: ['./create-person-dialog.component.scss'],
})
export class CreatePersonDialogComponent implements OnInit {
  pageTitle: string;
  person: PersonViewModel;

  constructor(
    public dialogRef: MatDialogRef<CreatePersonDialogComponent>,
    @Inject(MAT_DIALOG_DATA)
    public data: { editMode: boolean; person: PersonViewModel }
  ) {
    this.person = JSON.parse(JSON.stringify(data.person));
    this.pageTitle = data.editMode === true ? 'Edycja osoby' : 'Dodwanie osoby';

  }

  ngOnInit(): void {}

  onCancel(){
    this.dialogRef.close();
  }
}
