import { initializeApp } from "firebase/app";
import {
    GoogleAuthProvider,
    User,
    getAuth,
    onAuthStateChanged,
    signInWithEmailAndPassword,
    signInWithPopup,
    createUserWithEmailAndPassword,
    signOut,
} from "firebase/auth";
import React from "react";
import { firebaseConfig } from "../common/FirebaseConfig";

const app = initializeApp(firebaseConfig);
const auth = getAuth(app);

function useAuth() {
    const [currentUser, setCurrentUser] = React.useState < User | null > (null);
    const isAuthenticated = !!currentUser;

    React.useEffect(() => {
        const unsubscribe = onAuthStateChanged(auth, (user) => {
            setCurrentUser(user);
        });

        return unsubscribe;
    }, []);

    const signOutUser = () => signOut(auth);

    const signInUser = (email, password) => {
        return signInWithEmailAndPassword(auth, email, password);
    };

    const signInWithGoogle = () => {
        return signInWithPopup(auth, new GoogleAuthProvider());
    };

    const createUser = (email, password) => {
        return createUserWithEmailAndPassword(auth, email, password);
    };


    return {
        currentUser,
        isAuthenticated,
        signInUser,
        signInWithGoogle,
        signOut: signOutUser,
        createUser
    };
}

export default useAuth;