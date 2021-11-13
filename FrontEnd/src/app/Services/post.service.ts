import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Post } from '../Models/post';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  private http: HttpClient;
  constructor(http: HttpClient) {
    this.http = http;
   }
   public GetPosts(): Observable<Post[]> {
    return this.http.get<Post[]>("https://localhost:44379/api/Post");
  }
  public AddPost(post: Post): Observable<Post>{
    return this.http.post<Post>("https://localhost:44379/api/Post", post);
  }
  public DeletePost(post: Post): Observable<Post> {
    const url = `https://localhost:44379/api/Post/${post.id}`;
    return this.http.delete<Post>(url);
  }
  public UpdatePost(post: Post) : Observable<Post> {
    return this.http.put<Post>(`https://localhost:44379/api/Post/${post.id}`, post)
  }
}
