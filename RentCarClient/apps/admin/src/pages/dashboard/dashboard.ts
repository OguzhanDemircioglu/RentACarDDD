import {
  ChangeDetectionStrategy,
  Component,
  inject,
  OnInit,
  ViewEncapsulation,
} from '@angular/core';
import { BreadcrumbService } from '../../services/breadcrumb';

@Component({
  imports: [],
  templateUrl: './dashboard.html',
  encapsulation: ViewEncapsulation.None,
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export default class Dashboard implements OnInit {
  readonly #breadCrumbService = inject(BreadcrumbService);

  constructor() {}

  ngOnInit(): void {
    this.#breadCrumbService.setDashboard();
  }
}
