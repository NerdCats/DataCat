"use strict";
var shared_1 = require("./shared");
var auth_guard_1 = require("./auth/auth.guard");
exports.APP_PROVIDERS = [
    auth_guard_1.AuthGuard
].concat(shared_1.LOCAL_STORAGE_PROVIDERS, shared_1.LOGGER_PROVIDERS);

//# sourceMappingURL=app.providers.js.map
