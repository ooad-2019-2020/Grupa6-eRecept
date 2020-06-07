import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthGuardService } from '../../services/auth-guard.service';
import { HttpClient } from '@angular/common/http';

@Component({ templateUrl: 'login.component.html' })
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
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
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });

    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }

  onSubmit() {
    this.submitted = true;

    // reset alerts on submit

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }


    //TODO: vidjeti sa backendom je l postoji user i pw ovaj
    this.loading = true;

    this.httpClient
      .get("localhost:4200/account/login?username=" + this.loginForm.value['username'] + "&password=" + this.loginForm.value['password'])
      .subscribe(
        (data: boolean) => {
          this.authGuardService.isLoggedIn = data;
          if (data === true) {
            this.router.navigate([""]);
          }
        },
        error => {
          console.log(error);
          this.loading = false;
        });
  }
}
