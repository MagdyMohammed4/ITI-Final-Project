import { Routes } from '@angular/router';
import { HomeComponent } from './Component/home/home.component';
import { ProductComponent } from './Component/product/product.component';
import { SignInComponent } from './Component/sign-in/sign-in.component';
import { OrdersComponent } from './Component/orders/orders.component';
import { DelivaryComponent } from './Component/delivary/delivary.component';
import { MyAccountComponent } from './Component/my-account/my-account.component';
import { CartComponent } from './Component/cart/cart.component';
import { authGuard } from './guards/auth.guard';
import { ShippmentComponent } from './Component/shippment/shippment.component';
<<<<<<< HEAD
import { PaymentComponent } from './Component/payment/payment.component';
=======
import { RegistrationComponent } from './Component/registration/registration.component';
>>>>>>> origin/Develop
export const routes: Routes = [
    {path:'',redirectTo:'/Home',pathMatch:'full'},
    {path:'Home',component:HomeComponent},
    {path:'Product',component:ProductComponent},
    {path:'SignIn',component:SignInComponent},
    {path:'Registeration',component:RegistrationComponent},
    {path:'Order',component:OrdersComponent , canActivate:[authGuard]},  //
    {path:'Delivary',component:DelivaryComponent},
    {path:'MyAccount',component:MyAccountComponent , canActivate:[authGuard]},  //
    {path:'Cart',component:CartComponent},
    {path:'shippment',component:ShippmentComponent,canActivate:[authGuard]},
    {path:'Payment',component:PaymentComponent,canActivate:[authGuard]},
   // {path:'CartProduct',component:CartwithProductComponent},
   // {path:'test',component:TestComponent},


];
