import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  baseUrl: string;
  http: HttpClient;
  constructor(httpe: HttpClient, @Inject('BASE_URL') baseUrltag: string) {
    this.baseUrl = baseUrltag;
    this.http = httpe;
  }
  
  addItem(ting: any) {
    console.log('ouput event');
    console.log(ting);
    this.http.post<any>(this.baseUrl + 'weatherforecast', ting).subscribe(result => {
      console.log(result);
    }, (error: any) => console.error(error));
  }
}
