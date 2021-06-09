import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddCarComponent } from './car_actions/add-car/add-car.component';
import { CarsComponent } from './cars/cars.component';
import { AdminGuard } from './_guards/admin.guard';
import { UserCarsComponent } from './car_actions/user-cars/user-cars.component';
import { AuthGuard } from './_guards/auth.guard';
import { UpdateCarComponent } from './car_actions/update-car/update-car.component';
import { SearchCarComponent } from './car_actions/search-car/search-car.component';

const routes: Routes = [
  {path: 'cars', component: CarsComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AdminGuard],
    children: [
      {path: 'addcar', component: AddCarComponent},
      {path: 'update-car/:id', component: UpdateCarComponent},
      {path: 'search-car', component: SearchCarComponent}
    ]
  },
  // {path: 'identifiedInf', component: IdentifiedInfrastructureComponent, canActivate: [AuthGuard]},
  // {path: 'loginPanel', component: LoginRegisterComponent},
  {path: 'mycar', component: UserCarsComponent, canActivate: [AuthGuard]},
  {path: 'cars', component: CarsComponent},
  {path: '**', component: CarsComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
