import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthGuardService } from '../../services/auth-guard.service';
import { HttpClient } from '@angular/common/http';

@Component({ templateUrl: 'register.component.html' })
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authGuardService: AuthGuardService,
    private httpClient: HttpClient,
  ) {

  }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      repeatpassword: ['', Validators.required]
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;

    // reset alerts on submit

    // stop here if form is invalid
    if (this.registerForm.invalid) {
      return;
    }


    //TODO: vidjeti sa backendom je l postoji user i pw ovaj
    this.loading = true;

    this.httpClient
      .get("localhost:4200/account/register?username=" + this.registerForm.value['username'] + "&email=" + this.registerForm.value["email"] + "&password=" + this.registerForm.value['password'])
      .subscribe(
        data => {
          console.log(data);
        },
        error => {
          console.log(error);
          this.loading = false;
        });
  }
}
