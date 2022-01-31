import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/services/account/account.service';

@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrls: ['./my-account.component.scss'],
})
export class MyAccountComponent implements OnInit {
  public newPassword: string = '';
  constructor(private accountService: AccountService) {}

  ngOnInit(): void {}

  changePassword() {
    this.accountService.changePassword(this.newPassword).subscribe(() => {this.newPassword = ""});
  }
}
