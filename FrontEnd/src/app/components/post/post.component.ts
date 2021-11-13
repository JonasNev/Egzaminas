import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/Models/post';
import { PostService } from 'src/app/Services/post.service';
@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  private postService: PostService
  constructor(postService: PostService) {
    this.postService = postService;
   }
   public posts: Post[] = [];
   public editCustomer:false;
   public FormHeader: string;
   public id: 0;
   public town: "";
   public capacity: 0;
   public code: "";
   ngOnInit(): void {
    this.postService.GetPosts().subscribe((postsFromApi) =>{
      this.posts = postsFromApi.sort((a,b) => a.code.localeCompare(b.code));
    })
  }
  public addPost() : void {
    var post: Post = {
      town: this.town,
      capacity: this.capacity,
      code: this.code
    }
    this.postService.AddPost(post).subscribe((addedPost) => {
      post.id = addedPost.id;
      this.posts.push(post)
      this.posts.sort((a,b) => a.code.localeCompare(b.code));
    });
  }

  public updatePost() : void{
    var post: Post = {
      id: this.id,
      town: this.town,
      capacity: this.capacity,
      code: this.code
    }
    this.postService.UpdatePost(post).subscribe(() => {
      this.postService.GetPosts().subscribe((postsFromApi) =>{
        this.posts = postsFromApi.sort((a,b) => a.code.localeCompare(b.code));
      })
    })
  }

  public deletePost(post) : void{
    this.postService.DeletePost(post).subscribe(() => {
      this.posts = this.posts.filter(obj => obj !== post);
    })
  }
  EnableForm=function(){
    this.editCustomer=true;
    this.FormHeader="Create" 
    this.ResetValues(); 
  }
  ShowForm=function(post)  
  {  
    this.editCustomer=true;  
    if(post!=null)  
    {  
      this.SetValuesForEdit(post)  
      document.getElementById("btn1").removeAttribute("disabled");
      document.getElementById("btn2").setAttribute("disabled","true");
    }  
    else{  
      this.ResetValues();  
    }  
  }
  SetValuesForEdit=function(post)  
  {  
    this.id = post.id;
    this.town = post.town;
    this.capacity = post.capacity;
    this.code = post.code;
    this.FormHeader="Edit"  
  }  
  ResetValues(){
    this.id = null
    this.town = null
    this.capacity = null
    this.code = null 
  }
}
