import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, switchMap, throwError } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private baseUrl="/api/user";
  private imageUrl="/api/Image";
  private selectedUserId:number=0;
  constructor(private http:HttpClient) { }
  private getToken(){
    return ''+localStorage.getItem("authToken");
  }

  setUserId(id:number){
    this.selectedUserId=id;
  }
  getUserId():number{
    return this.selectedUserId;
  }

  getAll(){
    return this.http.get<any>(this.baseUrl+"/all",{}).pipe(
      map((response: User[]) => {
        console.log(response);
        return response;
      })
    );
  }

  getUser(id:number){
    return this.http.get<any>(this.baseUrl+"/"+id,{}).pipe(
      map((response: User[]) => {
        return response.at(0);
      })
    );
  }

  updateUser(user:User){
    console.log(user);
    return this.http.put<any>(this.baseUrl,user,{}).pipe(
      map((response: any) => {
        console.log(response);
      })
    );
  }

  updateUserWithPicture(user: User) {
    if (user.profilePictureData) {
      return this.uploadPicture(user.profilePictureData).pipe(
        switchMap((response: any) => {
          console.log('Image uploaded successfully:', response);
          user.profilePicturePath = response.filePath;
          return this.http.put<any>(this.baseUrl, user, {
          });
        }),
        map((response: any) => {
          console.log('User updated successfully:', response);
          return response;
        }),
        catchError((e: any) => {
          console.error('Error updating user:', e);
          return throwError(e);
        })
      );
    }
  
    return this.http.put<any>(this.baseUrl, user, {})
    .pipe(
      map((response: any) => {
        console.log('User updated successfully:', response);
        return response;
      }),
      catchError((e: any) => {
        console.error('Error updating user:', e);
        return throwError(e);
      })
    );
  }
  
  createUser(user:User){
    return this.http.post<any>(this.baseUrl,user,{}).pipe(
      map((response: any) => {
        console.log(response);
      })
    );
  }

  deleteUser(id:number){
    return this.http.delete<any>(this.baseUrl+"/"+id,{}).pipe(
      map((response: any) => {
        console.log(response)
      })
    );
  }


  getImage(imagePath:string){
      return this.http.get(this.imageUrl +'/'+ imagePath,{
        headers:{
          "Authorization": this.getToken()
        },
        responseType: "blob"
      }).pipe(
        map((r)=>{
          return r;
          // console.log(r);
        })
      );
  }

  uploadPicture(capturedImage: string): Observable<any> {
    const imageData = capturedImage.replace('data:image/png;base64,', '');
    const blob = this.base64ToBlob(imageData, 'image/png');
  
    const formData = new FormData();
    formData.append('image', blob, 'captured-image.png');
  
    // Return an observable from the image upload
    return this.http.post<any>(this.imageUrl + `/upload`, formData, {})
    .pipe(
      map((response: any) => {
        console.log('Image uploaded successfully:', response);
        return response;
      }),
      catchError((e: any) => {
        console.error('Error uploading image:', e);
        return throwError(e);
      })
    );
  }
  
  private base64ToBlob(base64Data: string, contentType: string): Blob {
    const byteCharacters = atob(base64Data);
    const byteArrays = [];
  
    for (let offset = 0; offset < byteCharacters.length; offset += 512) {
      const slice = byteCharacters.slice(offset, offset + 512);
  
      const byteNumbers = new Array(slice.length);
      for (let i = 0; i < slice.length; i++) {
        byteNumbers[i] = slice.charCodeAt(i);
      }
  
      const byteArray = new Uint8Array(byteNumbers);
      byteArrays.push(byteArray);
    }
  
    return new Blob(byteArrays, { type: contentType });
  }
}
