import { Component, OnInit } from '@angular/core';
import { PersonViewModel } from 'src/app/models/Person';
import { AccountService } from 'src/app/services/account/account.service';
import { ChoosePersonToAnswerService } from 'src/app/services/choosePersonToAnswer/choose-person-to-answer.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit {
  public roleList = ['Uczeń', 'Rodzic', 'Nauczyciel', 'Admin'];
  public luckyNumberVal;
  public account: PersonViewModel = new PersonViewModel();
  constructor(private accountService: AccountService, private luckyNumber: ChoosePersonToAnswerService) {
    this.luckyNumberVal = this.luckyNumber.getLuckyNumber();
  }

  ngOnInit(): void {
    this.accountService
      .getCurrentLoggedPerson()
      .then((res: PersonViewModel | undefined) => {
        if (res) {
          this.account = res;
        }
      });
  }
}
