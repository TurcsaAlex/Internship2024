import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, ViewChild, OnInit, inject, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-webcam',
  templateUrl: './webcam.component.html',
  styleUrls: ['./webcam.component.css']
})


export class WebcamComponent implements OnInit {
  @ViewChild('video') videoElement!: ElementRef;
  @ViewChild('canvas') canvas!: ElementRef;
  capturedImage: string | null = null;
	activeModal = inject(NgbActiveModal);

  constructor(){}

  ngOnInit() {
    this.startWebcam();
  }

  startWebcam() {
    navigator.mediaDevices.getUserMedia({ video: true })
      .then((stream) => {
        this.videoElement.nativeElement.srcObject = stream;
      })
      .catch((error) => {
        console.error("Error accessing webcam: ", error);
      });
  }
  retry(){
    this.capturedImage=null;
    this.startWebcam();
  }

  takePicture() {
    const canvasElement = this.canvas.nativeElement;
    const videoElement = this.videoElement.nativeElement;

    canvasElement.width = videoElement.videoWidth;
    canvasElement.height = videoElement.videoHeight;

    const context = canvasElement.getContext('2d');
    context.drawImage(videoElement, 0, 0, canvasElement.width, canvasElement.height);

    this.capturedImage = canvasElement.toDataURL('image/png');
  }

  downloadPicture() {
    if (this.capturedImage) {
      this.activeModal.close(this.capturedImage);
    }
  }
}
