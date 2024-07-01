import { UserResponseDTO } from './user-response.dto';
import { OrderItemResponseDTO } from './order-item-response.dto';

export interface OrderResponseDTO {
  id: string;
  orderDate: Date;
  user: UserResponseDTO;
  orderItems: OrderItemResponseDTO[];
}
