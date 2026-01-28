import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable, tap } from "rxjs";
import { AppModule } from "../app/app.module";
import { Router } from "@angular/router";

export class AuthInterceptor implements HttpInterceptor {
  constructor(private router: Router) { }

  public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(req).pipe(tap(() => { },
      (err: any) => {
        if (err instanceof HttpErrorResponse) {
          if (err.status !== 401) {
            return;
          }
          this.router.navigate([''])
        }
      }));
  }
}
