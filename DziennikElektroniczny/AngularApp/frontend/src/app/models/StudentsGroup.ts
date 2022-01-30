import { StudentsGroupMemberViewModel } from './StudentsGroupMember';

export class StudentsGroupViewModel {
  constructor(
    public id: number = 0,
    public teacherPersonId: number = 0,
    public teacherDisplayName: string = '',
    public title: string = '',
    public description: string = '',
    public yearOfStudy: number = 0,
    public studentsDisplayNames: string[] = [],
    public studentsGroupId: number = 0,
  ) 
  {}
}
