import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { GRADE_VALUES } from 'src/app/constants';

export interface DialogData {
  gradeId: number;
  gradeValue: string;
  studentDisplayName: string;
  subjectDisplayName: string;
}

@Component({
  selector: 'app-delete-modify-grade-modal',
  templateUrl: './delete-modify-grade-modal.component.html',
  styleUrls: ['./delete-modify-grade-modal.component.scss']
})
export class DeleteModifyGradeModalComponent implements OnInit {
  gradeValues: string[] = GRADE_VALUES;
  selectedValue: string;
  updateDisabled: boolean = true;

  constructor(@Inject(MAT_DIALOG_DATA) public data: DialogData) {
    this.selectedValue = data.gradeValue
  }

  ngOnInit(): void {
  }

  public gradeChanged(event: any){
    this.updateDisabled = false
    this.selectedValue = event.value;
  }

}
