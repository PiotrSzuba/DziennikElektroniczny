import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { SubjectViewModel } from 'src/app/models/Subject';
import {FormControl} from '@angular/forms';
import { LessonService } from 'src/app/services/lesson/lesson.service';

@Component({
  selector: 'app-add-lesson',
  templateUrl: './add-lesson.component.html',
  styleUrls: ['./add-lesson.component.scss']
})
export class AddLessonComponent implements OnInit {
  @Input() teacherId: number = -1
  @Input() subject: SubjectViewModel = new SubjectViewModel()
  @Output() lessonAdded = new EventEmitter()
  topicControl = new FormControl('');
  topic: string = ''
  selectedDate: Date = new Date()
  topicValid: boolean = true
  formValid: boolean = true

  constructor(private lessonService: LessonService) { }

  ngOnInit(): void {
    this.topicControl.valueChanges.subscribe(
      topic => {
        this.topic = topic
        this.validateTopic()
      }
    )
  }

  private validateTopic(){
    if(this.topic !== '') this.topicValid = true
    else this.topicValid = false
  }

  private validateForm(){
    this.validateTopic()
    this.formValid = this.topicValid
  }

  private isFormValid(): boolean{
    this.validateForm()
    return this.formValid
  }

  public createLesson(){
    if(!this.isFormValid()){
      return
    }

    this.lessonService.createLesson(this.teacherId, this.subject.id, this.topic, this.selectedDate).subscribe(
      response => {
        this.topicControl.setValue('')
        this.topicValid = true
        this.selectedDate = new Date()
        this.lessonAdded.emit()
      }
    )
  }

}
