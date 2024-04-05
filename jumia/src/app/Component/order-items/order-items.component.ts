import { Component, OnInit } from '@angular/core';
import { APIOrderServiceService } from '../../Services/apiorder-service.service';
import { IOrderItems } from '../../Models/iorder-items';
import { ActivatedRoute, Router } from '@angular/router';
import { IOrder } from '../../Models/i-order';

@Component({
  selector: 'app-order-items',
  standalone: true,
  imports: [],
  templateUrl: './order-items.component.html',
  styleUrl: './order-items.component.css'
})
export class OrderItemsComponent implements OnInit{
  OrderItems:IOrderItems[]=[] as IOrderItems[]
  constructor(private _OrderService:APIOrderServiceService,private route: ActivatedRoute,
    private router:Router
  ){}
  ordId:number=0
  ItemsNumber:number=0
  showAlert1: boolean = false;
  showAlert2: boolean = false;
 // ordStatus: number = 0;
  order: IOrder  = {} as IOrder;
  ngOnInit(): void {
    this.ordId = Number(this.route.snapshot.paramMap.get('ordId'));
  //  this.ordStatus = Number(this.route.snapshot.paramMap.get('status'));
    console.log('Order ID:', this.ordId);
   // console.log('Order Status:', this.ordStatus);

    this._OrderService.GetOrder(this.ordId).subscribe(order => {
      this.order = order;
      console.log(this.order);
    });

    this._OrderService.GetOrderItems(this.ordId).subscribe(OrderItems => {
     this.OrderItems=OrderItems
     this.ItemsNumber=OrderItems.length
    });

   
   }
   
   cancelOrder(){
    console.log(this.order.status);
    if(this.order.status>=2){
      this.showAlert1 = true;
    }
    else{
      this.order.status=4
      this._OrderService.UpdateOrder(this.order).subscribe(order => {
        this.order=order
        
        });
        this.showAlert2 = true;
        //this.router.navigate(['/OrderDetails']);
       
    }
    
   }
  
   closeAlert() {
    this.showAlert1 = false;
    this.showAlert2 = false;
  }
}
