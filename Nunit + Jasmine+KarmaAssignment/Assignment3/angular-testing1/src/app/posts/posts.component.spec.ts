import { ComponentFixture,async, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { PostService } from './post.service';

import { PostsComponent } from './posts.component';
import * as Rx from 'rxjs';
import { delay } from "rxjs/operators";
import { RouterTestingModule } from '@angular/router/testing';
import { HttpClientTestingModule } from "@angular/common/http/testing";

describe('PostsComponent', () => {
  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        HttpClientTestingModule
      ],
      declarations: [
        PostsComponent
      ],
      providers : [
        PostService
      ]
    }).compileComponents();
  }));



  it('should call getPostDetails and get response as empty array', fakeAsync(() => {
    const fixture = TestBed.createComponent(PostsComponent);
    const component = fixture.debugElement.componentInstance;
    const service = fixture.debugElement.injector.get(PostService);
    let spy_getPosts = spyOn(service,"getPosts").and.callFake(() => {
      return Rx.of([]).pipe(delay(100));
    });
    component.getPostDetails();
    tick(100);
    expect(component.postDetails).toEqual([]);
  })) 
  it('should call getPostDetails and get response as array', fakeAsync(() => {
    const fixture = TestBed.createComponent(PostsComponent);
    const component = fixture.debugElement.componentInstance;
    const service = fixture.debugElement.injector.get(PostService);
    let spy_getPosts = spyOn(service,"getPosts").and.callFake(() => {
      return Rx.of([{postId : 100}]).pipe(delay(2000));
    });
    component.getPostDetails();
    tick(1000);
    expect(component.showLoadingIndicator).toEqual(true);
    tick(1000);
    expect(component.showLoadingIndicator).toEqual(false);
    expect(component.postDetails).toEqual([{postId : 100}]);
  }))
  
});
