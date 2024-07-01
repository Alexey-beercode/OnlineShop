import {OrderItemRequestDTO} from "./order-item-request.dto";

export interface UpdateOrderRequestDTO {
  userId: string;
  orderItems: OrderItemRequestDTO[];
}
