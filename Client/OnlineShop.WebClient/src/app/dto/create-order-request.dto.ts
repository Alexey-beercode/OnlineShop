import {OrderItemRequestDTO} from "./order-item-request.dto";
import {UserRequestDTO} from "./user-request.dto";

export
interface CreateOrderRequestDTO {
  user: UserRequestDTO;
  orderItems: OrderItemRequestDTO[];
}
