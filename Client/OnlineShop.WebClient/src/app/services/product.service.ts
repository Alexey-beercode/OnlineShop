import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ProductResponseDTO } from '../dto/product-response.dto';
import { ProductRequestDTO } from '../dto/product-request.dto';
import { ProductUpdateRequestDTO } from '../dto/product-update-request.dto';
import { ProductsCollectionResponseDTO } from '../dto/products-collection-response.dto';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = 'https://localhost:7095/api/product';

  constructor(private http: HttpClient) { }

  getProducts(): Observable<ProductsCollectionResponseDTO> {
    return this.http.get<ProductsCollectionResponseDTO>(`${this.apiUrl}/get-all`);
  }

  getProduct(id: string): Observable<ProductResponseDTO> {
    return this.http.get<ProductResponseDTO>(`${this.apiUrl}/get/${id}`);
  }

  createProduct(product: ProductRequestDTO): Observable<ProductResponseDTO> {
    return this.http.post<ProductResponseDTO>(`${this.apiUrl}/create`, product);
  }

  updateProduct(id: string, product: ProductUpdateRequestDTO): Observable<ProductResponseDTO> {
    return this.http.put<ProductResponseDTO>(`${this.apiUrl}/update`, product);
  }

  deleteProduct(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/delete/${id}`);
  }
}
