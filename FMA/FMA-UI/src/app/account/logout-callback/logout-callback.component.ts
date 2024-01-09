import { Component, OnInit, inject } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logout-callback',
  templateUrl: './logout-callback.component.html',
  styleUrls: ['./logout-callback.component.scss']
})
export class LogoutCallbackComponent implements OnInit {

  router = inject(Router)
  authService = inject(AuthService)

  ngOnInit(): void {
    this.router.navigate(['/landing'], { replaceUrl: true });
  }
}
