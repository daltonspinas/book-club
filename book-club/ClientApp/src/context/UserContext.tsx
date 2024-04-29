import { UserInfo } from '../interfaces/types';
import React, { createContext } from 'react';

type AppUserContextType = {
    appUser?: UserInfo,
    setAppUser?: any
}

export const AppUserContext = createContext<AppUserContextType>({});