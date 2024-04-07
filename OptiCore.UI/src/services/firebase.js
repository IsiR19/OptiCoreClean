import { initializeApp } from 'firebase/app';
import {
  getAuth,
  GoogleAuthProvider,
  signInWithPopup,
  signInWithEmailAndPassword as fireEmailAndPassword,
  onAuthStateChanged as fireOnAuthStateChanged,
  signOut as fireSignOut,
} from 'firebase/auth';
import { getAnalytics } from 'firebase/analytics';
import config from '../config';

const googleProvider = new GoogleAuthProvider();
googleProvider.addScope('https://www.googleapis.com/auth/userinfo.profile');
googleProvider.addScope('profile');
googleProvider.addScope('openid');
googleProvider.addScope('https://www.googleapis.com/auth/user.phonenumbers.read');
export const firebase = initializeApp(config.firebase);
export const firebaseAuth = getAuth(firebase);
export const googlePopup = () => signInWithPopup(firebaseAuth, googleProvider);
export const signInWithEmailAndPassword = (email, password) =>
  fireEmailAndPassword(firebaseAuth, email, password);
export const onAuthStateChanged = (next) =>
  fireOnAuthStateChanged(firebaseAuth, next);
export const signOut = () => fireSignOut(firebaseAuth);
//** Analytics */
export const analytics = getAnalytics(firebase);
