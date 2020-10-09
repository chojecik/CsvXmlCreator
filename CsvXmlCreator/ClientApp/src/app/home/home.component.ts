import { Component, ViewChild } from '@angular/core';
import { TextService } from '../services/text.service';
import { FormModel } from '../models/form-model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent{
  @ViewChild('textForm', { static: false }) textForm;
  //type = '1'; //setting default value of radio buttons to XML
  isTextSerialized: boolean = false;
  serializedText: string;

  constructor(
    private textService: TextService) { }

  postText({ value }: { value: FormModel }) {
    this.textService.postText(value)
      .subscribe(
        response => {
          this.isTextSerialized = true;
          this.serializedText = response.response;
        })
  }

  clear() {
    this.isTextSerialized = false;
    this.serializedText = "";
    this.textForm.reset();
  }

  download() {
    var model = new FormModel();
    model.input = this.serializedText;
    model.type = this.textForm.form.value.type;

    this.textService.downloadFile(model)
      .subscribe(
        res => {
          const data = window.URL.createObjectURL(res);
          var link = document.createElement('a');
          link.href = data;
          link.download = "file";
          link.dispatchEvent(new MouseEvent('click', { bubbles: true, cancelable: true, view: window }));
          setTimeout(function () {
            window.URL.revokeObjectURL(data);
            link.remove();
          }, 100);
        })
  }
}
