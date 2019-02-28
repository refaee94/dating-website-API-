import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
  values: any;

// tslint:disable-next-line: deprecation
  constructor(private http: Http) { }

  ngOnInit() {

    this.http.get('http://localhost:5000/api/valuec').subscribe(result => {
this.values = result.json();
console.log(result);
  });

}}
