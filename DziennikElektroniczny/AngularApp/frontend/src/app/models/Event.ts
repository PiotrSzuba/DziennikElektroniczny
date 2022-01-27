export class EventViewModel{
    constructor(
        public id: number,
        public title: string,
        public description: string,
        public endDate: Date,
        public startDate: Date,
        public participators: string[]
      ) {}
}