"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var elasticsearch_1 = require("elasticsearch");
var index_1 = require("../shared/index");
/** Job search service powered by elasticsearch */
var JobSearchService = (function () {
    function JobSearchService(loggerService) {
        this.loggerService = loggerService;
        if (!this._client) {
            this._connect();
        }
    }
    /** Execute a full text search over a elasticsearch index */
    JobSearchService.prototype.textSearch = function (indexName, query) {
        if (query) {
            this.loggerService.log(query);
            return this._client.search({
                index: indexName,
                q: "title:" + query
            });
        }
        else {
            Promise.resolve({});
        }
    };
    /** Check whether the elasticsearch serever is available or not */
    JobSearchService.prototype.isAvailable = function () {
        return this._client.ping({
            requestTimeout: Infinity,
            body: 'hello elasticsearch!'
        });
    };
    JobSearchService.prototype._connect = function () {
        this._client = new elasticsearch_1.Client({
            host: 'http://localhost:9200',
            log: 'trace'
        });
    };
    return JobSearchService;
}());
JobSearchService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [index_1.LoggerService])
], JobSearchService);
exports.JobSearchService = JobSearchService;

//# sourceMappingURL=job-search.service.js.map
