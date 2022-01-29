export class StudentsGroupViewModel{
    constructor(
        public id: number,
        public teacherPersonId: number,
        public teacherDisplayName: string,
        public title: string,
        public description: string,
        public yearOfStudy: number,
        public studentsDisplayNames: string[]
      ) {}
}