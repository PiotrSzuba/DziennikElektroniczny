import { Component } from '@angular/core';
import { AccountService } from './services/account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  constructor(private accountService: AccountService) {}
  title = 'frontend';
  login() {
    this.accountService.login('Admin', '1234');
  }
}
