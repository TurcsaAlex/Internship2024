import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../service/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers:[AuthService]
})
export class LoginComponent {
  loginForm: FormGroup= new FormGroup({
    username: new FormControl('',Validators.required),
    password: new FormControl('',[Validators.required])
  });

  constructor(private auth:AuthService,
              private router:Router
  ) {
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const username = this.loginForm.get('username')?.value;
      const password = this.loginForm.get('password')?.value;

      this.auth.login(
        { username: username, password: password })
        .subscribe({
        next:(r)=>{},
        error:(r)=>{console.log(r);alert("Invalid Login!")
        }
      });
    } else {
      console.log('Form is invalid');
    }
  }
}
