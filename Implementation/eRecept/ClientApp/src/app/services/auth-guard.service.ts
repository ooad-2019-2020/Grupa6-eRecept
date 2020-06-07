import { Injectable } from '@angular/core';
import { CanActivate } from '@angular/router';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate {

  public isLoggedIn = true;
  public userId = -1;

  constructor(
    private router: Router
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    // not logged in so redirect to login page with the return url
    if (!this.isLoggedIn) {
      this.router.navigate(['login'], { queryParams: { returnUrl: state.url } });
      return false;
    } else { return true; }
  }
}
