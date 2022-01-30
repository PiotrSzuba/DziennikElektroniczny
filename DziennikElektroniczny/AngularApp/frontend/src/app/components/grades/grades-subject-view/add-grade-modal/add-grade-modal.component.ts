import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GRADE_VALUES } from 'src/app/constants';

export interface DialogData {
  studentId: number;
  studentDisplayName: string,
  subjectId: number;
  subjectDisplayName: string;
}

@Component({
  selector: 'app-add-grade-modal',
  templateUrl: './add-grade-modal.component.html',
  styleUrls: ['./add-grade-modal.component.scss']
})
export class AddGradeModalComponent implements OnInit {
  gradeValues: string[] = GRADE_VALUES;
  selectedValue: string = "";

  constructor(@Inject(MAT_DIALOG_DATA) public data: DialogData) { }

  ngOnInit(): void {}

  public gradeChanged(event: any){
    this.selectedValue = event.value;
  }

}
