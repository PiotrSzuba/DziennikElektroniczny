import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/services/account/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  public login: string = '';
  public password: string = '';
  constructor(private accountService: AccountService) {}

  public loginMe() {
    this.accountService.login(this.login, this.password)
  }

  ngOnInit(): void {}
}
