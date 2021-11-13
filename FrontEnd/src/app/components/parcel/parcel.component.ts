import { Component, OnInit } from '@angular/core';
import { Parcel } from 'src/app/Models/parcel';
import { Post } from 'src/app/Models/post';
import { ParcelService } from 'src/app/Services/parcel.service';
import { PostService } from 'src/app/Services/post.service';

@Component({
  selector: 'app-parcel',
  templateUrl: './parcel.component.html',
  styleUrls: ['./parcel.component.css']
})
export class ParcelComponent implements OnInit {
  private parcelService: ParcelService
  private postService: PostService
  constructor(parcelService: ParcelService,postService: PostService) {
    this.parcelService = parcelService;
    this.postService = postService;
   }
   public parcels: Parcel[] = []
   public posts: Post[] = []
   public editCustomer:false;
   public FormHeader: string;
   public id: 0;
   public weight: 0;
   public phoneNumber: 0;
   public text: "";
   public postId?: 0;
   public sortId: 0;

  ngOnInit(): void {
    this.parcelService.GetParcels().subscribe((parcelsFromApi) =>{
      this.parcels = parcelsFromApi.sort((a, b) => b.weight - a.weight)
    })
    this.postService.GetPosts().subscribe((postsFromApi) =>{
      this.posts = postsFromApi.sort((a,b) => a.town.localeCompare(b.town));
    })
    console.log(this.posts)
  }
  public addParcel() : void {
    var parcel: Parcel = {
      weight: this.weight,
      phoneNumber: this.phoneNumber,
      text:this.text,
      postId: this.postId
    }
    this.parcelService.AddParcel(parcel).subscribe(() => {
      this.parcelService.GetParcels().subscribe((parcelsFromApi) =>{
        this.parcels = parcelsFromApi.sort((a, b) => b.weight - a.weight)
      })
  
    });
  }

  public updateParcel() : void{
    var parcel: Parcel = {
      id: this.id,
      weight: this.weight,
      phoneNumber: this.phoneNumber,
      text:this.text,
      postId: this.postId
    }
    this.parcelService.UpdateParcel(parcel).subscribe(() => {
      this.parcelService.GetParcels().subscribe((parcelsFromApi) =>{
        this.parcels = parcelsFromApi.sort((a, b) => b.weight - a.weight)
      })
    }
    )
  }

  public filter(sortId) : void{
    this.parcels = this.parcels.filter(obj => obj.post.id == sortId )
  }

  public resetFilter() : void {
    this.parcelService.GetParcels().subscribe((parcelsFromApi) =>{
      this.parcels = parcelsFromApi.sort((a, b) => b.weight - a.weight)
    })
  }

  public deleteParcel(parcel) : void{
    this.parcelService.DeleteParcel(parcel).subscribe(() => {
      this.parcels = this.parcels.filter(obj => obj !== parcel);
    })
  }
  EnableForm=function(){
    this.editCustomer=true;
    this.FormHeader="Create" 
    this.ResetValues();
  }
  ShowForm=function(parcel)  
  {  
    this.editCustomer=true;  
    if(parcel!=null)  
    {  
      this.SetValuesForEdit(parcel)  
      document.getElementById("btn1").removeAttribute("disabled");
      document.getElementById("btn2").setAttribute("disabled","true");
    }  
    else{  
      this.ResetValues();  
    }  
    document.getElementById("btn1").removeAttribute("disabled");
    document.getElementById("btn2").setAttribute("disabled","true");
  }
  SetValuesForEdit=function(parcel)  
  {  
    this.id = parcel.id;
    this.weight = parcel.weight;
    this.phoneNumber = parcel.phoneNumber;
    this.text = parcel.text;
    this.postId = parcel.postId
    this.FormHeader="Edit"  
  }  
  ResetValues(){
    this.id = null;
    this.weight = null;
    this.phoneNumber = null;
    this.text = "";
    this.postId = null;
  }
}
