import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { CarsComponent } from './cars/cars.component';
import { AddCarComponent } from './car_actions/add-car/add-car.component';
import { SearchCarComponent } from './car_actions/search-car/search-car.component';
import { UserCarsComponent } from './car_actions/user-cars/user-cars.component';
import { UpdateCarComponent } from './car_actions/update-car/update-car.component';
import { FileUploadModule } from 'ng2-file-upload';
import { HasRoleDirective } from './_directives/has-role.directive';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CarsComponent,
    AddCarComponent,
    SearchCarComponent,
    UserCarsComponent,
    UpdateCarComponent,
    HasRoleDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    BrowserAnimationsModule,
    FileUploadModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
