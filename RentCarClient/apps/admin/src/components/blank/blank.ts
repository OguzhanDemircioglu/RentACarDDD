import {
  ChangeDetectionStrategy,
  Component,
  inject,
  Input,
  input,
  ViewEncapsulation,
} from '@angular/core';
import { NgClass, Location, DatePipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { EntityModel } from '../../models/entity.model';

@Component({
  selector: 'app-blank',
  imports: [NgClass, RouterLink, DatePipe],
  templateUrl: './blank.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export default class Blank {
  readonly pageIcon = input.required<string>();
  readonly pageTitle = input.required<string>();
  readonly pageDescription = input<string>('');
  readonly status = input<boolean>(false);
  readonly showStatus = input<boolean>(true);
  readonly showBackButton = input<boolean>(true);
  readonly showEditButton = input<boolean>(false);
  readonly editButtonUrl = input<string>('');
  readonly audit = input<EntityModel>();
  readonly showAudit = input<boolean>(true);

  readonly #location = inject(Location);

  back() {
    this.#location.back();
  }
}
