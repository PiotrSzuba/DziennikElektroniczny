import { Component, OnInit } from '@angular/core';
import { PersonViewModel } from 'src/app/models/Person';
import { AccountService } from 'src/app/services/account/account.service';

@Component({
  selector: 'app-attendance',
  templateUrl: './attendance.component.html',
  styleUrls: ['./attendance.component.scss']
})
export class AttendanceComponent implements OnInit {
  person: PersonViewModel = new PersonViewModel();

  constructor(
    private accountService: AccountService
  ) {}

  ngOnInit(): void {
    this.person = this.accountService.getCurrentPersonFromLocalStorage();
  }
}
