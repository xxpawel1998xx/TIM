import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { Car } from 'src/app/_models/car';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { ClientService } from 'src/app/_services/client.service';

@Component({
  selector: 'app-user-cars',
  templateUrl: './user-cars.component.html',
  styleUrls: ['./user-cars.component.css']
})
export class UserCarsComponent implements OnInit {

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
    
  }

  loadCars(){
    this.clientService.getCars().subscribe(cars => {
      this.cars = cars;
    });
  }

  UnselectCar(carId: number){
    this.clientService.UnselectCar(this.user.id, carId).subscribe(success =>{
      window.location.reload();
    });
    
  }

}
