import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from './models/Product';
import { Pagenation } from './models/Pagenation';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'clientSide';
  products: Product[] = [];

  /**
   *
   */
  constructor(private http: HttpClient) {
  }
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.http.get<Pagenation<Product[]>>('https://localhost:5001/api/Products?pageSize=50').subscribe({
      next: (res: any) => this.products = res.data,
      error: error => console.log(error),
      complete: () =>{
        console.log('completed');
      }
    })
    
  }
}
