import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/services/account/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit {

  constructor(private router: Router,
    private accountService:AccountService) {}

  ngOnInit(): void {}

  public logout() {
    localStorage.removeItem('JWT');
    localStorage.removeItem('person');
    this.redirectToLoginPage();
  }
  private redirectToLoginPage(): void {
    this.router.navigate(['login']);
  }

  public loggedAsAdmin(){
    return this.accountService.getCurrentPersonFromLocalStorage()?.role === 4;
  }
}
