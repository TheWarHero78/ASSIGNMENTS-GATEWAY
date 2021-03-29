import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-host-component',
  templateUrl: './host-component.component.html',
  styleUrls: ['./host-component.component.css']
})
export class HostComponentComponent implements OnInit {

  @Input() public phone: string;

  constructor() { }

  ngOnInit() { 
    if(!this.phone) {
      this.phone = 'not specified';
    }
  }

}
