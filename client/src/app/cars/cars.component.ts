import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { Car } from 'src/app/_models/car';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { ClientService } from 'src/app/_services/client.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {
  cars: Car[];
  car: Car;
  user: User;
  constructor(private clientService: ClientService, private accountService: AccountService) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    });
  }

  ngOnInit(): void {
    this.loadCars();
    this.getCurrentUser();
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


  getCurrentUser(){
    this.accountService.currentUser$.subscribe(user => {
    }, error => {
        console.log(error);
    });
  }
}
