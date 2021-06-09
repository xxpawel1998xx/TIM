import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { Car } from 'src/app/_models/car';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { AdminService } from 'src/app/_services/admin.service';
import { ClientService } from 'src/app/_services/client.service';

@Component({
  selector: 'app-update-car',
  templateUrl: './update-car.component.html',
  styleUrls: ['./update-car.component.css']
})
export class UpdateCarComponent implements OnInit {
  cars: Car[];
  car: any;
  user: User;
  model: any = {};
 
  constructor(private clientService: ClientService, private accountService: AccountService, 
    private adminService: AdminService, private route: ActivatedRoute,  private router: Router) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
    });
  }
  ngOnInit(): void {
    this.loadCar();
  }

  
  loadCar(){
    this.adminService.getCarById(this.route.snapshot.paramMap.get('id')).pipe(take(1)).subscribe((car) => {
      this.car = car;
      
    });
  }


  updateCar(carId){
    this.adminService.updateCar(this.car, carId).subscribe(() => {
      location.replace('/addcar');
      
    });
  }
}
