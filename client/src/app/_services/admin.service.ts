import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Car } from '../_models/car';
import { Client } from '../_models/client';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  baseUrl = environment.apiUrl;
  clients: Client[] = [];
  cars: Car[] = [];

  constructor(private http: HttpClient) { }

  
  // addCar( car: string, brand: string, fuelType: string, price, year, mileage) {
  //   const form = new FormData();
  //   form.append('car', car);
  //   form.append('brand', brand);
  //   form.append('fuelType', fuelType);
  //   form.append('price', price);
  //   form.append('year', year);
  //   form.append('mileage', mileage);
  //   return this.http.post<Car>(this.baseUrl + 'car/add', form);
  // }

  addCar(model: any) { 
    return this.http.post<Car>(this.baseUrl + 'car/add', model).pipe(
      map((response: Car) => {
       const car = response;
       return car;
     })
   );
  }

  delCar(carId: number){
    return this.http.delete(this.baseUrl + 'car/delete/' + carId);
  }

  updateCar(car: Car, carId: number){
    return this.http.put(this.baseUrl + 'car/update/' + carId, car).pipe(
      map(() => {
        const index = this.cars.indexOf(car);
        this.cars[index] = car;
      })
    );
  }

  getCarById(carId){
    return this.http.get(this.baseUrl + 'car/' + carId);
  }

  getUsers(){
    return this.http.get<Client[]>(this.baseUrl + 'admin/users').pipe(
      map(users => {
        this.clients = users;
        return users;
      })
    )
  }

}
