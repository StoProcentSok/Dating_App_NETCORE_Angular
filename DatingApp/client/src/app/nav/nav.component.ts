import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model : any = {};
  loggedIn: boolean = false;

  constructor(private accountSetvice: AccountService) { }

  ngOnInit(): void {
    console.log(this.loggedIn);
  }

  login() {
    this.accountSetvice.login(this.model).subscribe(response => {
      console.log(response);
      
      this.loggedIn = true;
      console.log(this.loggedIn);
    }, error => {
      console.log(error);
    });
  }

}
