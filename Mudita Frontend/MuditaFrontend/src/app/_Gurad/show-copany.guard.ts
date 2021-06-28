import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate,Router,RouterStateSnapshot, UrlTree,ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShowCopanyGuard implements CanActivate {
  constructor(private router:Router,private path:ActivatedRoute){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      debugger;
      // console.log(this.path.snapshot.url[0])
      var test=this.router.url
      var folder = window.location.pathname;
      let URl = folder.split('/')
      const comId= parseInt(URl[3]) 
     const com=parseInt(sessionStorage.getItem("companyId"));
     if(comId!=com||!com)
     {
        this.router.navigateByUrl('/notfound')
        return false;
     }
     return true
    }
}
