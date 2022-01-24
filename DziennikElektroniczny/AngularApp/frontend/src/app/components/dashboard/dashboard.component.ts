import { Component, OnInit } from '@angular/core';
import { PersonViewModel } from 'src/app/models/Person';
import { AccountService } from 'src/app/services/account/account.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  public message: string = '';
  constructor(private accountService: AccountService) {}

  ngOnInit(): void {
    this.accountService
      .getCurrentLoggedPerson()
      .then((res: PersonViewModel | undefined) => {
        if (res) {
          this.message = 'Witaj ' + res.name + ' ' + res.surname + '!';
        }
      });
  }
}
