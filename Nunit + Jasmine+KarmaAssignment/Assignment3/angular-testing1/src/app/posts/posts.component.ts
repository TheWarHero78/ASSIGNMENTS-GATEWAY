import { Component, OnInit } from '@angular/core';
import { PostService } from './post.service';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {

  postDetails;
  showLoadingIndicator;
  constructor(private service : PostService){
    this.postDetails = [];
  }

  ngOnInit() {
  
    this.getPostDetails();
  }

  getPostDetails(){
    this.showLoadingIndicator = true;
    this.service.getPosts().subscribe((response : []) => {
      this.showLoadingIndicator = false;
      if(response && response.length > 0) {
        this.postDetails = response;
      } else {
        this.postDetails = [];
      }
    })
  }
}
