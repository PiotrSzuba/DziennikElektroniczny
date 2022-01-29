import { GradeViewModel } from "./Grade";

export class SubjectViewModel {
  constructor(
    public id: number,
    public subjectInfoId: number,
    public subjectName: string,
    public teacherPersonId: number,
    public teacherName: string,
    public studentsGroupId: number,
    public studentsGroupName: string,
    public classRoomId: number,
    public classRoomName: string,
    public classRoomFloor: string,
    public classRoomBuilding: string,
    public isExpanded?: boolean,
    public grades?: GradeViewModel[],
  ) {}
}
