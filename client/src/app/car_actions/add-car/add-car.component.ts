import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { FileUploader } from 'ng2-file-upload';
import { take } from 'rxjs/operators';
import { Car } from 'src/app/_models/car';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { AdminService } from 'src/app/_services/admin.service';
import { ClientService } from 'src/app/_services/client.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-add-car',
  templateUrl: './add-car.component.html',
  styleUrls: ['./add-car.component.css']
})
export class AddCarComponent implements OnInit {
  cars: Car[];
  car: Car;
  user: User;
  model: any = {};
  uploader: FileUploader;
  hasBaseDropzoneOver = false;
  baseUrl = environment.apiUrl;
  carU: Car;
 

  public previewPath: any;
 
  constructor(private clientService: ClientService, private accountService: AccountService, private adminService: AdminService, public sanitizer: DomSanitizer) {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.user = user;
      
    });
  }

  ngOnInit(): void {
    
    this.loadCars();
    this.getCurrentUser();
    this.initializeUploader();
    
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



  addCar(){
    this.adminService.addCar(this.model).subscribe(() => {
      window.location.reload();
    });
  }
  delCar(carId: number){
    this.adminService.delCar(carId).subscribe(() => {
      window.location.reload();
    });
  }


  getCurrentUser(){
    this.accountService.currentUser$.subscribe(user => {
     
    }, error => {
        console.log(error);
    });
    
  }

  fileOverBase(e: any) {
    this.hasBaseDropzoneOver = e;
  }


  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'car/add',
      authToken: 'Bearer ' + this.user.token,
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024,
    });

    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
      this.previewPath = this.sanitizer.bypassSecurityTrustUrl((window.URL.createObjectURL(file._file)));
      
    },
    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        const photo = JSON.parse(response);
        this.model?.carPhotoUrl?.push(photo);
      }
      location.reload();
    };

    this.uploader.onBeforeUploadItem = (file) => {
      this.uploader.options.additionalParameter = { 
        car: this.model.car,
        brand: this.model.brand,
        mileage: this.model.mileage,
        fuelType: this.model.fuelType,
        year: this.model.year,
        price: this.model.price,
      }
    };
  }
  
  onKey1(event: any) {
    this.model.car = event.target.value;
    
  }

  onKey2(event: any) {
    this.model.brand = event.target.value;
    
  }

  onKey3(event: any) {
    this.model.mileage = event.target.value;
    
  }

  onKey4(event: any) {
    this.model.fuelType = event.target.value;
    
  }

  
  onKey5(event: any) {
    this.model.year = event.target.value;
    
  }

  onKey6(event: any) {
    this.model.price = event.target.value;
    
  }


}
