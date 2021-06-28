import { NgModule } from '@angular/core';
import {ConfirmDialogModule} from 'primeng/confirmdialog';
import {InputTextModule} from 'primeng/inputtext';
import {InputNumberModule} from 'primeng/inputnumber';
import {InputTextareaModule} from 'primeng/inputtextarea';
import {InputMaskModule} from 'primeng/inputmask';

import {ButtonModule} from 'node_modules/primeng/button';
import {CardModule} from 'node_modules/primeng/card';
import {DropdownModule} from 'primeng/dropdown';
import {CalendarModule} from 'primeng/calendar';
import {DialogModule} from 'primeng/dialog';
import {PaginatorModule} from 'primeng/paginator';

import {RadioButtonModule} from 'primeng/radiobutton';
import {PasswordModule} from 'primeng/password';
import {ProgressBarModule} from 'primeng/progressbar';
import { ChipModule } from 'primeng/chip';
import {ChipsModule} from 'primeng/chips';
import {AutoCompleteModule} from 'primeng/autocomplete';
import {ToastModule} from 'primeng/toast';
import {RippleModule} from 'primeng/ripple';
import {FileUploadModule} from 'primeng/fileupload';
import {DividerModule} from 'primeng/divider';
import {ToolbarModule} from 'primeng/toolbar';

import {MessageModule} from 'primeng/message'
import {RatingModule} from 'primeng/rating';
import {TableModule} from 'primeng/table';
import {ConfirmPopupModule} from 'primeng/confirmpopup';
import { TagModule } from 'primeng/tag';
import {StepsModule} from 'primeng/steps';


@NgModule({
  declarations: [],
  exports: [
    AutoCompleteModule,
    RadioButtonModule,
    PasswordModule,
    ProgressBarModule,
    ChipModule,
    ChipsModule,
    CardModule,
    ButtonModule,
    DropdownModule,
    CalendarModule,
    DialogModule,
    InputTextModule,
    InputTextareaModule,
    InputNumberModule,
    InputMaskModule,
    PaginatorModule,
    ToastModule,
    RippleModule,
    FileUploadModule,
    DividerModule,
    MessageModule,
    RatingModule,
    ConfirmPopupModule,
    TableModule,
    TagModule,
    ToolbarModule,
    StepsModule,
    ConfirmDialogModule
  ]
})
export class PrimengComponentsModule { }
