import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './core/models/user';
import { UserService } from './core/services/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  users: User[] = [];

  constructor(private userService: UserService) {}

  ngOnInit() {

    this.userService.allUsersQuery().subscribe( (users) => {
      this.users = users as User[];
      console.log(users)
    });
    this.userService.allDataQuery().subscribe( (data) => console.log(data));
  }


}
