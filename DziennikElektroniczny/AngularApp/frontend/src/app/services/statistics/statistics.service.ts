import { Injectable } from '@angular/core';
import { GRADE_VALUES_NUMERIC_AND_WAGE } from 'src/app/constants';
import { AttendanceViewModel } from 'src/app/models/Attendance';
import { GradeViewModel } from 'src/app/models/Grade';

@Injectable({
  providedIn: 'root',
})
export class StatisticsService {
  constructor() {}

  public calculateGradeAverage(grades: GradeViewModel[]) {
    let sum: number = 0;
    let wageSum: number = 0;
    grades.forEach((myGrade) => {
      const grade = this.getGrade(myGrade.value);
      sum += grade.numeric;
      wageSum += grade.wage;
    });
    return sum / wageSum;
  }

  private getGrade(value: string) {
    let grade = GRADE_VALUES_NUMERIC_AND_WAGE.find(
      (grade) => grade.value == value
    );
    return grade!;
  }

  public calculateFrequency(attendances: AttendanceViewModel[]) {
    const allCount = attendances.length;
    let presentCount = 0;
    attendances.forEach((at) => {
      if (at.wasPresent || at.absenceNote) presentCount++;
    });
    return presentCount / allCount * 100;
  }
}
