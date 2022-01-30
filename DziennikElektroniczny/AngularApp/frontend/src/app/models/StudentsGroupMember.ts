export class StudentsGroupMemberViewModel{
    constructor(
        public id: number,
        public studentsGroupId: number,
        public studentsGroupName: string,
        public studentPersonId: number,
        public studentDisplayName: string
      ) {}
}