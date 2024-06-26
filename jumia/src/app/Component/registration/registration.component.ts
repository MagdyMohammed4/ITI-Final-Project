import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RegistrationService } from '../../Services/registration.service';
import { RegisterDto } from '../../ViewModels/register-dto';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [FormsModule,CommonModule ,TranslateModule,RouterLink],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent  implements OnInit{
  user:RegisterDto={} as RegisterDto
  isArabic: boolean = localStorage.getItem('isArabic') === 'true';
  constructor( private _registrationService :RegistrationService ,
    private  translate: TranslateService,private router:Router )
  {

  }
  ngOnInit(): void {
    this.translate.onLangChange.subscribe((Event)=>{
      this.isArabic = Event.lang === 'ar'
    })
  }
  

  register(username: string, email: string, password: string, confirmpass: string ,phonenumber :string) {
    if (password !== confirmpass) {
   
      alert("Password and Confirm Password do not match.");
      return; 
    }
    this._registrationService.register(username, email, password, confirmpass,phonenumber).subscribe({
      next: (res) => {
        console.log(res)
        alert("Successfully registered!");
        this.router.navigate(['/SignIn']);
      },
      error: (err) => {
        console.error(err);
        alert("Error occurred while registering. Please try again.");
      }
    });




}}
