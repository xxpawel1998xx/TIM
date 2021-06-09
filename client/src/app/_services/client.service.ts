import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Car } from '../_models/car';
import { Client } from '../_models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  baseUrl = environment.apiUrl;
  clients: Client[] = [];
  cars: Car[] = [];

  constructor(private http: HttpClient) { }

  getCars() {
    if (this.cars.length > 0) { return of(this.cars); }
    return this.http.get<Car[]>(this.baseUrl + 'car').pipe(
      map(cars => {
        this.cars = cars;
        return cars;
      })
    );
  }

  SelectCar(userId: number, carId: number){
    return this.http.post(this.baseUrl + 'client/' + userId + '/pick/' + carId, {});
  }

  UnselectCar(userId: number, carId: number){
    return this.http.post(this.baseUrl + 'client/' + userId + '/unpick/' + carId, {});
  }


}
