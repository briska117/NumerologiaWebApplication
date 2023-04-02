import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { NumericalAnalisys } from '../models/models';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  baseUrl: string;
  http: HttpClient;
  numericalAnalisys!: NumericalAnalisys
  constructor(httpe: HttpClient, @Inject('BASE_URL') baseUrltag: string) {
    this.baseUrl = baseUrltag;
    this.http = httpe;
  }
  
  addItem(ting: any) {
    console.log('ouput event');
    console.log(ting);
    this.http.post<NumericalAnalisys>(this.baseUrl + 'weatherforecast', ting).subscribe(result => {
      console.log(result);
      this.numericalAnalisys = result;
    }, (error: any) => console.error(error));
  }
}
