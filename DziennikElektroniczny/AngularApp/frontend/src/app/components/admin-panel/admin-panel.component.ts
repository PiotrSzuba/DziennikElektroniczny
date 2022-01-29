
import { Component, OnInit, TemplateRef, Type } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { PersonViewModel } from 'src/app/models/Person';
import { AccountService } from 'src/app/services/account/account.service';
import { PeopleService } from 'src/app/services/people/people.service';
import { CreatePersonDialogComponent } from './create-person-dialog/create-person-dialog.component';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrls: ['./admin-panel.component.scss'],
})
export class AdminPanelComponent implements OnInit {
  public persons: PersonViewModel[] = Array();
  constructor(
    private accountService: AccountService,
    private peopleService: PeopleService,
    private dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.reloadPersons();
  }
  private reloadPersons() {
    this.persons = this.accountService.getAllPersons();
  }

  public editPerson(person: PersonViewModel) {
    this.openPersonDialog({ person: person, editMode: true });
  }

  public deletePerson(person: PersonViewModel) {
    this.peopleService
      .deletePerson(person.id)
      .subscribe(() => this.reloadPersons());
  }

  private openPersonDialog(params: object): void {
    const dialogRef = this.dialog.open(CreatePersonDialogComponent, {
      data: params,
    });
    dialogRef.afterClosed().subscribe((result) => {

    });
  }

  addPerson(){
    this.openPersonDialog({ person: new PersonViewModel(), editMode: false });
  }
}
