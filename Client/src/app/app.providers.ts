import { LOCAL_STORAGE_PROVIDERS, LOGGER_PROVIDERS } from './shared';
import { AuthGuard } from './auth/auth.guard';
import { DASHBOARD_PROVIDERS } from './dashboard/index';

export const APP_PROVIDERS = [
    AuthGuard,
    ...LOCAL_STORAGE_PROVIDERS,
    ...LOGGER_PROVIDERS,
    ...DASHBOARD_PROVIDERS
];
