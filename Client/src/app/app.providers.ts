import { LOCAL_STORAGE_PROVIDERS, LOGGER_PROVIDERS } from './shared';
import { AuthGuard } from './auth/auth.guard';

export const APP_PROVIDERS = [
    AuthGuard,
    ...LOCAL_STORAGE_PROVIDERS,
    ...LOGGER_PROVIDERS
];
