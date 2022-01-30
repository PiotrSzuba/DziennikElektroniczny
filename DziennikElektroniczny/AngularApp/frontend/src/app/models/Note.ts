export class NoteViewModel{
    constructor(
        public id: number,
        public description: String,
        public date: Date,
        public teacherPersonId: number,
        public teacherDisplayName: string,
        public studentPersonId: number,
        public studentDisplayName: string,
      ) {}
}