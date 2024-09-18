import { Component, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../service/auth.service';
import { Router } from '@angular/router';
import { ToastService } from '../../service/toast.service';

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
              private toastService:ToastService
  ) {
  }

  onSubmit(template:TemplateRef<any>) {
    if (this.loginForm.valid) {
      const username = this.loginForm.get('username')?.value;
      const password = this.loginForm.get('password')?.value;

      this.auth.login(
        { username: username, password: password })
        .subscribe({
        next:(r)=>{},
        error:(r)=>{
          console.log(r);
          this.toastService.show({ template, classname: 'bg-danger text-light', delay: 5000 ,data:"Invalid Login!" });
          this.loginForm.reset();
        }
      });
    } else {
      console.log('Form is invalid');
    }
  }
}
