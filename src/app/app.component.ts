import { Component, OnInit } from '@angular/core';
import {Http, Response} from '@angular/http';
import {AppService} from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
title = 'SportsStore';
list: any;
// tslint:disable-next-line: deprecation
constructor(private http: Http) {}
ngOnInit(): void {
this.http.get('http://localhost:5000/api/valuec/').subscribe(result => {
this.list = result;
console.log(result);
});
}
}
