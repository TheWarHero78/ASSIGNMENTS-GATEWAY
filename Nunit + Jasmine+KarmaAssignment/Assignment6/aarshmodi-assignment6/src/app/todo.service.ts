import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';
import { Todo } from './todo.model';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  todoUrl = "https://jsonplaceholder.typicode.com/todos";
  promiseResult:any;
  constructor(private http: HttpClient) { }

  getAllTodo():Observable<Todo[]>{
    return this.http.get<Todo[]>(this.todoUrl).pipe(catchError(this.handleError('getUsers', [])));
  }

  getTodo(id: number) :Observable<Todo>{
    return this.http.get<Todo>(this.todoUrl+"/"+id).pipe(catchError(this.handleError<Todo>('getTodo id=${id}')));
  }

  updateTodo(id: number,t:Todo) :Observable<Todo>{
    return this.http.put<Todo>(this.todoUrl+"/"+id,t).pipe(catchError(this.handleError<Todo>('updateTodo id=${id}')));
  }

  deleteTodo(id: number) :Observable<Todo>{
    return this.http.delete<Todo>(this.todoUrl+"/"+id).pipe(catchError(this.handleError<Todo>('deleteTodo id=${id}')));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error); // log to console instead
      console.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
}
