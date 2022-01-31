export class AttendanceViewModel {
    constructor(
        public id: number = -1,
        public studentPersonId: number = -1,
        public studentDisplayName: string = '',
        public lessonId: number = -1,
        public subjectName: string = '',
        public lessonDate: string = '',
        public wasPresent: boolean = false,
        public absenceNote: string = '',
    ) {}
}
