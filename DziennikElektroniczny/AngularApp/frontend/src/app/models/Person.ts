export class PersonViewModel {
  constructor(
    public id: number = 0,
    public role: number = 0,
    public login: string = '',
    public personalInfoId: number = 1,
    public name: string = '',
    public secondName: string = '',
    public surname: string = '',
    public dateOfBirth: Date = new Date(),
    public phoneNumber: string = '',
    public address: string = '',
    public pesel: string = ''
  ){}

  equals(other: PersonViewModel): boolean {
    return this.id == other.id
  }
}
