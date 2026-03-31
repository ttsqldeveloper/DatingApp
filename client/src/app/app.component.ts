import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet], // Add RouterOutlet here
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
private http = inject(HttpClient);
protected title = 'Dating App';
protected members: any;
    ngOnInit(): void {
     this.http.get('https://localhost:5001/api/members').subscribe({
       next: response => this.members = response,
       error: error => console.log(error),
       complete: () => console.log('Completed the http request')
})
    }

}
