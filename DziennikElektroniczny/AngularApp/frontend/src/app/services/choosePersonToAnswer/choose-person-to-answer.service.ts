import { Injectable } from '@angular/core';
import { PersonViewModel } from 'src/app/models/Person';

@Injectable({
  providedIn: 'root',
})
export class ChoosePersonToAnswerService {
  private luckyNumber: number;
  constructor() {
    const today = new Date();
    this.luckyNumber =
      today.getDay() * today.getMonth() * today.getFullYear() + today.getDay();
    this.luckyNumber = this.luckyNumber % 30;
  }

  public choosePerson(studentsInClassCount: number, presenceList: number[]) {
    let pickedNumber =
      Math.round(Math.random() * Number.MAX_SAFE_INTEGER) %
      studentsInClassCount;
    while (pickedNumber == this.luckyNumber || presenceList[pickedNumber] == 0) {
      pickedNumber =
        Math.round(Math.random() * Number.MAX_SAFE_INTEGER) %
        studentsInClassCount;
    }
    return pickedNumber;
  }

  public getLuckyNumber() {
    return this.luckyNumber + 1;
  }
}
