import { Component, EventEmitter, Inject, OnInit, Output } from '@angular/core';
import { Form, FormControl } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SubjectViewModel } from 'src/app/models/Subject';

export interface DialogData {
  lessonId: number,
  teacherId: number,
  subject: SubjectViewModel;
  topic: string;
  selectedDate: Date;
}

export interface FormData {
  topic: string,
  selectedDate: Date
}

@Component({
  selector: 'app-modify-delete-lesson',
  templateUrl: './modify-delete-lesson.component.html',
  styleUrls: ['./modify-delete-lesson.component.scss']
})
export class ModifyDeleteLessonComponent implements OnInit {
  lessonId: number
  teacherId: number
  subject: SubjectViewModel
  @Output() lessonAdded = new EventEmitter()
  topicControl: FormControl
  formData: FormData
  topicValid: boolean = true
  formValid: boolean = true

  constructor(@Inject(MAT_DIALOG_DATA) public data: DialogData) {
    this.lessonId = data.lessonId
    this.teacherId = data.teacherId
    this.subject = data.subject
    this.formData = {topic: data.topic, selectedDate: data.selectedDate}
    this.topicControl = new FormControl(data.topic);
  }

  ngOnInit(): void {
    this.topicControl.valueChanges.subscribe(
      topic => {
        this.formData.topic = topic
        this.validateForm()
      }
    )
  }

  private validateTopic(){
    if(this.formData.topic !== '') this.topicValid = true
    else this.topicValid = false
  }

  private validateForm(){
    this.validateTopic()
    this.formValid = this.topicValid
  }
}
