import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ProductListComponent } from './product-list/product-list.component';
import { CheckoutComponent } from './checkout/checkout.component';

export const routes: Routes = [
  // { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },

  {
    path:'',
    redirectTo:'home',
    pathMatch: 'full'
},
{
    path:'home',
    component:ProductListComponent
},
{
    path:'checkout',
    component:CheckoutComponent
},
{
    path:'**',
    component:ProductListComponent
}
];

export class AppRoutingModule { }