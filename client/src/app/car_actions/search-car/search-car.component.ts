import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { Car } from 'src/app/_models/car';
import { Client } from 'src/app/_models/client';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { AdminService } from 'src/app/_services/admin.service';
import { ClientService } from 'src/app/_services/client.service';

@Component({
  selector: 'app-search-car',
  templateUrl: './search-car.component.html',
  styleUrls: ['./search-car.component.css']
})
export class SearchCarComponent implements OnInit {

  cars: Car[];
  clients: Client[];
  car: Car;
  user: User;
  constructor(private clientService: ClientService, private accountService: AccountService, private adminService: AdminService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    });
  }

  ngOnInit(): void {
    this.loadCars();
    this.getCurrentUser();
    this.getClients();
  }

  loadCars(){
    this.clientService.getCars().subscribe(cars => {
      this.cars = cars;
    });
  }

  
  selectCar(carId: number){
    this.clientService.SelectCar(this.user.id, carId).subscribe(() =>{
      window.location.reload();
    });
    
  }
  getClients(){
    this.adminService.getUsers().subscribe(clients => {
      this.clients = clients;
    })
  }


  getCurrentUser(){
    this.accountService.currentUser$.subscribe(user => {
    }, error => {
        console.log(error);
    });
  }

}
