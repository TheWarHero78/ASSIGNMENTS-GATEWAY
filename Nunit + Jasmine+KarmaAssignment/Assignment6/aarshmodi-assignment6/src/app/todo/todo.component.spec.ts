import { HttpClient, HttpHandler } from '@angular/common/http';
import { ComponentFixture, discardPeriodicTasks, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { timer } from 'rxjs';
import { of } from 'rxjs/internal/observable/of';
import { mapTo } from 'rxjs/operators';
import { Todo } from '../todo.model';
import { TodoService } from '../todo.service';

import { TodoComponent } from './todo.component';

describe('TodoComponent', () => {
  let component: TodoComponent;
  let fixture: ComponentFixture<TodoComponent>;
  let todoService: TodoService;
  const Todo_ob: Todo = {
    userId: 1,
    id: 1,
    title: "delectus aut autem",
    completed: false
  }


  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TodoComponent],
      providers: [
        TodoService, { provide: HttpClient, useValue: {} }
      ]
    })
      .compileComponents();
    todoService = TestBed.get(TodoService);
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TodoComponent);
    component = fixture.componentInstance;
    //fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call getAllTodos to apiService', fakeAsync(() => {
    const todos: Todo[] = [
      {
        userId: 1,
        id: 1,
        title: "delectus aut autem",
        completed: false
      }
    ]
    spyOn(todoService, 'getAllTodo').and.returnValue(timer(1000).pipe(mapTo(todos)));
    component.getAllTodo();
    component.todos$.subscribe(todos => {
      expect(todos).toHaveSize(1);
    });
    tick(1000);
    discardPeriodicTasks();
  }));

  it('should call fetchData from apiService', fakeAsync(() => {
    spyOn(todoService, 'getTodo').withArgs(1).and.returnValue(timer(1000).pipe(mapTo(Todo_ob)));
    component.ngOnInit();
    component.todo$.subscribe(todos => {
      expect(todos).toEqual(Todo_ob);
    });
    tick(1000);
    discardPeriodicTasks();
  }));

  it('should call updateData to apiService', fakeAsync(() => {
    const uTodo_ob: Todo = {
      userId: 1,
      id: 1,
      title: "aarsh",
      completed: true
    }
    spyOn(todoService, 'updateTodo').withArgs(1, uTodo_ob).and.returnValue(timer(1000).pipe(mapTo(uTodo_ob)));
    component.updateTodo();
    component.todo$.subscribe(todos => {
      expect(todos).toEqual(uTodo_ob);
    });
    tick(1000);
    discardPeriodicTasks();
  }));

  it('should call deletData to apiService', fakeAsync(() => {

    spyOn(todoService, 'deleteTodo').withArgs(1).and.returnValue(timer(1000).pipe(mapTo(Todo_ob)));
    component.deleteTodo();
    component.todo$.subscribe(todos => {
      expect(todos).toBe(Todo_ob);
    });
    tick(1000);
    discardPeriodicTasks();
  }));


});
