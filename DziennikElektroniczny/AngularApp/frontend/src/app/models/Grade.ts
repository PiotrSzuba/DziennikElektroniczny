export class GradeViewModel {
  constructor(
    public id: number,
    public studentPersonId: number,
    public studentDisplayName: string,
    public teacherPersonId: number,
    public teacherDisplayName: string,
    public subjectId: number,
    public subjectName: string,
    public value: string,
    public date: Date,
  ) {}
}
