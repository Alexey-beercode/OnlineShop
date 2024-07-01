import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CategoriesCollectionResponseDTO } from "../dto/categories-collection-response.dto";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private apiUrl = 'http://your-api-url/api/categories';

  constructor(private http: HttpClient) { }

  getCategories(): Observable<CategoriesCollectionResponseDTO> {
    return this.http.get<CategoriesCollectionResponseDTO>(this.apiUrl);
  }
}
