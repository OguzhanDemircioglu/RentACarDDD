import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

export const authGuard: CanActivateFn = (route, state) => {
  const token = localStorage.getItem('token');
  const router = inject(Router);
  if (!token) {
    router.navigateByUrl('/login').then(() => {});
    return false;
  }

  try {
    const decode = jwtDecode(token);
    const now = new Date().getTime() / 1000;
    const exp = decode.exp ?? 0;

    if (exp! <= now) {
      router.navigateByUrl('/login').then(() => {});
      return false;
    }
  } catch (error) {
    router.navigateByUrl('/login').then(() => {});
    return false;
  }

  return true;
};
