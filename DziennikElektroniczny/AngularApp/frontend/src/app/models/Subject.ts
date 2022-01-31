import { GradeViewModel } from "./Grade";

export class SubjectViewModel {
  constructor(
    public id: number = -1,
    public subjectInfoId: number = -1,
    public subjectName: string = '',
    public teacherPersonId: number = -1,
    public teacherName: string = '',
    public studentsGroupId: number = -1,
    public studentsGroupName: string = '',
    public classRoomId: number = -1,
    public classRoomName: string = '',
    public classRoomFloor: string = '',
    public classRoomBuilding: string = '',
    public isExpanded?: boolean,
    public grades?: GradeViewModel[],
  ) {}
}
