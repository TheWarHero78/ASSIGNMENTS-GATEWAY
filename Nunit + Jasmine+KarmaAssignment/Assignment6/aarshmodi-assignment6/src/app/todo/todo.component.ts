import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { Todo } from '../todo.model';
import { TodoService } from '../todo.service';
@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {
  todo$: Observable<Todo>;
  todos$: Observable<Todo[]>;
  constructor(private todoService: TodoService) { }

  ngOnInit(): void {
    this.todo$ = this.todoService.getTodo(1);
  }

  updateTodo(){
    const uTodo_ob: Todo = {
      userId: 1,
      id: 1,
      title: "aarsh",
      completed: true
    }
    this.todo$ = this.todoService.updateTodo(1, uTodo_ob);
  }

   deleteTodo() {

    this.todo$ = this.todoService.deleteTodo(1);
  }

    getAllTodo() {
    this.todos$ =  this.todoService.getAllTodo();
  }


}
