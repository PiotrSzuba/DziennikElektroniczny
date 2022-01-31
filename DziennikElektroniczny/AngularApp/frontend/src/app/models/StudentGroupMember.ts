export class StudentGroupMemberViewModel {
  constructor(
    public id: number = -1,
    public studentsGroupId: number = -1,
    public studentsGroupName: string = '',
    public studentPersonId: number = -1,
    public studentDisplayName: string = ''
  ) {}
}
