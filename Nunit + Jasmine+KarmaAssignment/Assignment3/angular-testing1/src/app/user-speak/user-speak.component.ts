import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-user-speak',
  templateUrl: './user-speak.component.html',
  styleUrls: ['./user-speak.component.css']
})
export class UserSpeakComponent implements OnInit {
  @Input() name: string;
  @Output() readonly speak = new EventEmitter<string>();

  constructor() { }

  ngOnInit(): void {
  }
  
 
  sayHello() {
      this.speak.emit('Hello');
  }

  sayGoodbye() {
      this.speak.emit('Goodbye');
  }
}
