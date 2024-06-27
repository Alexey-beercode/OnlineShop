import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  apiUrl: string = 'https://localhost:7095/api/product'

  constructor(private http: HttpClient) { }

  getAllProduct() : Observable<any>
  {
    return this.http.get(this.apiUrl + "GetAllAsync")
  }
}
