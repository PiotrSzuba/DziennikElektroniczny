export class Message{
    constructor(
        public sendDate: string,
        public seenDate: string,
        public fromPersonName: string,
        public toPersonName: string,
        public title: string,
        public content: string
    ) {}
}