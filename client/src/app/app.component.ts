import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit, signal } from '@angular/core'; // Add signal to imports

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [], // Add RouterOutlet here if needed
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  private http = inject(HttpClient);
  protected title = 'Dating App';
  protected members = signal<any[]>([]); // Now signal is properly imported

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/members').subscribe({
      next: (response: any) => {
        console.log('Members received:', response);
        this.members.set(response); // Use .set() to update the signal
      },
      error: (error) => console.log(error),
      complete: () => console.log('Completed the http request')
    });
  }
}
