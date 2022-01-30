export class PersonViewModel {
  constructor(
    public id: number = 0,
    public role: number = 1,
    public login: string = '',
    public personalInfoId: number = 1,
    public name: string = '',
    public secondName: string = '',
    public surname: string = '',
    public dateOfBirth: Date = new Date(),
    public phoneNumber: string = '',
    public address: string = '',
    public pesel: string = '',
    public hashedPassword: string | null = null,
    public personId: number | null = null
  ) {}

  equals(other: PersonViewModel): boolean {
    return this.id == other.id;
  }
}
