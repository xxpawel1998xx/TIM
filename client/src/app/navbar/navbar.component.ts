import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  model: any = {};
  constructor(public accountService: AccountService, private toastr: ToastrService, private router: Router) { }

  ngOnInit(): void {
  }

  login(){
    this.accountService.login(this.model).subscribe(response => {
      location.replace('/cars');
    }, error =>{
     this.toastr.error('Wprowadzono niepoprawne dane');
    });
   }

   logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
 
  getCurrentUser(){
    this.accountService.currentUser$.subscribe(user => {
    }, error => {
        console.log(error);
    });
  }

}
