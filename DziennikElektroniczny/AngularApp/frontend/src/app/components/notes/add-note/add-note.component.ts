import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.scss']
})
export class AddNoteComponent implements OnInit {
  contentControl: FormControl = new FormControl('')
  content: string = ''
  contentValid: boolean = true 
  buttonDisbled: boolean = true

  constructor() { }

  ngOnInit(): void {
    this.contentControl.valueChanges.subscribe(
      content => {
        this.content = content
        this.validate()
      }
    )
  }

  private validate(){
    if(this.content !== '') this.contentValid = true
    else this.contentValid = false

    this.buttonDisbled = !this.contentValid
  }

}
