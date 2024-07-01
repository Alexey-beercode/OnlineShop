import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderItemResponseDTO } from '../dto/order-item-response.dto';
import { OrderItemRequestDTO } from '../dto/order-item-request.dto';

@Injectable({
  providedIn: 'root'
})
export class OrderItemService {
  private apiUrl = 'http://your-api-url/api/orderitems';

  constructor(private http: HttpClient) { }

  getOrderItems(): Observable<OrderItemResponseDTO[]> {
    return this.http.get<OrderItemResponseDTO[]>(this.apiUrl);
  }

  createOrderItem(orderItem: OrderItemRequestDTO): Observable<OrderItemResponseDTO> {
    return this.http.post<OrderItemResponseDTO>(this.apiUrl, orderItem);
  }
}
