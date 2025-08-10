﻿export interface NavigationModel {
  title: string;
  url?: string;
  icon?: string;
  haveSubMenu?: boolean;
  subNavs?: NavigationModel[];
}

export const navigations: NavigationModel[] = [
  {
    title: 'Dashboard',
    url: '/',
    icon: 'bi-speedometer2',
  }
];
