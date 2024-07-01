import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderResponseDTO } from '../dto/order-response.dto';
import { CreateOrderRequestDTO } from '../dto/create-order-request.dto';
import { UpdateOrderRequestDTO } from '../dto/update-order-request.dto';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private apiUrl = 'http://your-api-url/api/orders';

  constructor(private http: HttpClient) { }

  getOrders(): Observable<OrderResponseDTO[]> {
    return this.http.get<OrderResponseDTO[]>(this.apiUrl);
  }

  createOrder(order: CreateOrderRequestDTO): Observable<OrderResponseDTO> {
    return this.http.post<OrderResponseDTO>(this.apiUrl, order);
  }

  updateOrder(id: string, order: UpdateOrderRequestDTO): Observable<OrderResponseDTO> {
    return this.http.put<OrderResponseDTO>(`${this.apiUrl}/${id}`, order);
  }
}
