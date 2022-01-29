export class GradeViewModel {
  constructor(
    public gradeId: number,
    public studentPersonId: number,
    public studentDisplayName: string,
    public teacherPersonId: number,
    public teacherDisplayName: string,
    public subjectId: number,
    public subjectName: string,
    public value: string,
    public date: Date
  ) {}
}
