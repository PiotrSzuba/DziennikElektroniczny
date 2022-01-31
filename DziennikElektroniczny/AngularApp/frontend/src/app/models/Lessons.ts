export class LessonViewModel {
  constructor(
    public id: number = -1,
    public teacherPersonId: number = -1,
    public teacherName: string = '',
    public subjectId: number = -1,
    public subjectName: string = '',
    public topic: string = '',
    public date: string = '',
  ) {}
}