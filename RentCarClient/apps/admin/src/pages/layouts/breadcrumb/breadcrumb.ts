import {
  ChangeDetectionStrategy,
  Component,
  inject,
  ViewEncapsulation,
} from '@angular/core';
import { BreadcrumbService } from '../../../services/breadcrumb';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-breadcrumb',
  imports: [RouterLink, NgClass, RouterLinkActive],
  templateUrl: './breadcrumb.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export default class Breadcrumb {
  readonly breadcrumbsService = inject(BreadcrumbService);
}
