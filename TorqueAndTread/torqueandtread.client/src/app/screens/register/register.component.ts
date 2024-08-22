import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../service/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerForm: FormGroup= new FormGroup({
    username: new FormControl('',Validators.required),
    password: new FormControl('',[Validators.required]),
    email:new FormControl('',[Validators.required,Validators.email]),
    name:new FormControl('',[Validators.required])
  });

  constructor(private router:Router,private auth:AuthService) {
  }

  onSubmit() {
    if (this.registerForm.valid) {
      const username = this.registerForm.get('username')?.value;
      const password = this.registerForm.get('password')?.value;
      const email = this.registerForm.get('email')?.value;
      const name = this.registerForm.get('name')?.value;
      console.log('Username:', username);
      console.log('Password:', password);
      this.auth.register({
        username:username,
        password:password,
        name:name,
        email:email
      }).subscribe({
        next:()=>{
          console.log("yipeee");
          this.router.navigateByUrl("/login")
        },
        error:()=>{alert('IOI')}
      });


    } else {
      console.log('Form is invalid');
    }
  }
}
