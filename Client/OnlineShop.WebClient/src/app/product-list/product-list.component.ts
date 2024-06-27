import { Component } from '@angular/core';
import { IProduct } from '../models/IProduct';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent {

  productList: IProduct [] = [];

  addToCart(productId: string):void {
  }

  getProductByCategory(cateId: number) {
  }
}


