import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent implements OnInit {
  public userLoginAttemptCount = 0;
  public isMaxAttempt = false;

  public constructor(private _http: HttpClient) { }

  ngOnInit(): void {

  }
   public async authenticateUser()  {
      return new Promise(resolve => {
          resolve(1);
      }).then((res: number) => {

          if (this.userLoginAttemptCount < 5) {
              this.userLoginAttemptCount += res;
          } else {
              this.isMaxAttempt = true;
          }

      });
  }
  public async checkStatus() {
    return this._http.get<any>('https://httpstat.us/200').toPromise();
}

}
