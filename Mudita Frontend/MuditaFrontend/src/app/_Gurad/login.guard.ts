import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})


export class LoginGuard implements CanActivate {
 

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const token = sessionStorage.getItem("jwt") as string;
    if(token==null){
      this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
      return false;
    }
    return true;
    }
  constructor(private router: Router) { }     
} 

