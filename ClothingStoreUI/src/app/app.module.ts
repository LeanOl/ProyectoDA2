import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainMenuOptionsComponent } from './components/main-menu-options/main-menu-options.component';
import { LoginFormComponent } from './components/session/login-form/login-form.component';
import { ProductItemComponent } from './components/product/product-item/product-item.component';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductDetailComponent } from './components/product/product-detail/product-detail.component';
import { AdminMenuComponent } from './components/menu/admin-menu/admin-menu.component';
import { MainMenuComponent } from './components/menu/main-menu/main-menu.component';
import { NotLoggedMenuComponent } from './components/menu/not-logged-menu/not-logged-menu.component';
import { UserMenuComponent } from './components/menu/user-menu/user-menu.component';
import { UserItemComponent } from './components/user/user-item/user-item.component';
import { UserListComponent } from './components/user/user-list/user-list.component';
import { UserManagementComponent } from './components/user/user-management/user-management.component';
import { CartItemComponent } from './components/cart/cart-item/cart-item.component';
import { CartMenuComponent } from './components/cart/cart-menu/cart-menu.component';
import { CartInfoComponent } from './components/cart/cart-info/cart-info.component';
import { RegisterFormComponent } from './components/session/register-form/register-form.component';
import { PurchaseListComponent } from './components/purchase/purchase-list/purchase-list.component';
import { PurchaseItemComponent } from './components/purchase/purchase-item/purchase-item.component';
import { PurchaseProductComponent } from './components/purchase/purchase-product/purchase-product.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CreateProductComponent } from './components/product/create-product/create-product.component';

@NgModule({
  declarations: [
    AppComponent,
    MainMenuOptionsComponent,
    LoginFormComponent,
    ProductItemComponent,
    ProductListComponent,
    ProductDetailComponent,
    AdminMenuComponent,
    MainMenuComponent,
    NotLoggedMenuComponent,
    UserMenuComponent,
    UserItemComponent,
    UserListComponent,
    UserManagementComponent,
    CartItemComponent,
    CartMenuComponent,
    CartInfoComponent,
    RegisterFormComponent,
    PurchaseListComponent,
    PurchaseItemComponent,
    PurchaseProductComponent,
    CreateProductComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
