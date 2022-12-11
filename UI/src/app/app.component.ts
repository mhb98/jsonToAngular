import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import {DomSanitizer, SafeHtml}  from "@angular/platform-browser";


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
          console.log(this.alphas)
         // console.log(this.htmlview)
          
        })
      )
      .subscribe(posts => {
        // ...
        console.log("Hello");
      });
  }
}

