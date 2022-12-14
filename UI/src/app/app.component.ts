import { Component, ElementRef, OnInit, QueryList, ViewChildren } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import {DomSanitizer, SafeHtml}  from "@angular/platform-browser";
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'jsonToAngular';
  htmlview: SafeHtml | undefined;
  alphas:any; 
  serverElements = [{type:'server',name:'TestServer',content:'Just Test!'}];
  PersonList=[];

  constructor (private http: HttpClient,private sanitizer:DomSanitizer) {
    //this.htmlview=this.sanitizer.bypassSecurityTrustHtml(this.arrBirds);
    //console.log(this.htmlview)
   }


   ngOnInit () {
    this.fetchPosts();
  }
  
  private fetchPosts() {
    this.http
      .get('https://localhost:7060/api/ProductAPI/SendFormModule')
      .pipe(
        map(responseData => {
          
          this.alphas=responseData as string
          this.htmlview=this.sanitizer.bypassSecurityTrustHtml(this.alphas);
          //console.log(this.alphas)
         // console.log(this.htmlview) 
           
        })
      )
      .subscribe(posts => {
        // ...
        //console.log("Hello");
      });
  }
  sendToAPI(){

    this.http
      .post(
        'https://localhost:7060/api/ProductAPI/GetFormModule',
        this.PersonList
      )
      .subscribe(responseData => {
        console.log(responseData);
      });
    //console.log(form['value']);
  }
 // fullValue:any;
  //fullValueJson:any;


  onSubmit(form:NgForm){
   // this.fullValue=document.getElementById('data').querySelectorAll('input').item(0).value;
    //console.log(this.fullValue);
    for(var i=0;i<document
      .getElementById('data')
      .querySelectorAll('input')
      .length-1; i++){

    var keyID=document
      .getElementById('data')
      .querySelectorAll('input')
      .item(i).id;

    var value=document
      .getElementById('data')
      .querySelectorAll('input')
      .item(i).value;

    const person={};

    person[keyID]=value;

    this.PersonList.push(person);

}
this.sendToAPI();
     }


}

