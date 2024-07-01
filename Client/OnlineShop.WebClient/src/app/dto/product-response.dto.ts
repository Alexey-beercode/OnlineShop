import { CategoryResponseDto } from './category-response.dto';

export interface ProductResponseDTO {
  id: string;
  name: string;
  price: number;
  description: string;
  category: CategoryResponseDto;
}
