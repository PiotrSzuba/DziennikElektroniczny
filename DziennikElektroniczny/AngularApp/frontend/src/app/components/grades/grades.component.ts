import { Component, OnInit } from '@angular/core';
import { PersonViewModel } from 'src/app/models/Person';
import { AccountService } from 'src/app/services/account/account.service';

@Component({
  selector: 'app-grades',
  templateUrl: './grades.component.html',
  styleUrls: ['./grades.component.scss'],
})
export class GradesComponent implements OnInit {
  person: PersonViewModel = new PersonViewModel();

  constructor(
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.person = this.accountService.getCurrentPersonFromLocalStorage();
  }
}
