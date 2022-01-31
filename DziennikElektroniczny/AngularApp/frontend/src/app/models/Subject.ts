import { GradeViewModel } from './Grade';

export class SubjectViewModel {
  constructor(
    public id: number = 0,
    public subjectInfoId: number = 0,
    public subjectName: string = '',
    public teacherPersonId: number = 0,
    public teacherName: string = '',
    public studentsGroupId: number = 0,
    public studentsGroupName: string = '',
    public classRoomId: number = 0,
    public classRoomName: string = '',
    public classRoomFloor: string = '',
    public classRoomBuilding: string = '',
    public isExpanded?: boolean,
    public grades?: GradeViewModel[],
    public subjectId: number = 0,
    public subjectDescription: string = '',
  ) {}
}
