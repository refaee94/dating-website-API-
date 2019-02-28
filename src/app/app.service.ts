
import {Injectable} from '@angular/core';
import {Http, Response, Headers, RequestOptions} from '@angular/http';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
@Injectable()
export class AppService {
private greetUrl = 'api/Hello';
constructor(private _http: Http) {}
sayHello(): Observable<any> {
return this._http.get(this.greetUrl).pipe(map((response: Response) => {
return response.text();
}));
}}
