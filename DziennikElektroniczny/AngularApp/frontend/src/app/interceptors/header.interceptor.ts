import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpErrorResponse,
} from '@angular/common/http';
import { catchError, map, Observable, pipe, throwError } from 'rxjs';
import { Router } from '@angular/router';

@Injectable()
export class HeaderInterceptor implements HttpInterceptor {
  constructor(private router: Router) {}

  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    const JWT = localStorage.getItem('JWT') || '';
    return next.handle(request.clone({ setHeaders: { JWT } })).pipe(
      catchError((requestError) => {
        if (requestError.status == 401) {
          this.router.navigate(['login']);
        }
        
        return throwError(() => requestError);
      })
    );
  }
}
