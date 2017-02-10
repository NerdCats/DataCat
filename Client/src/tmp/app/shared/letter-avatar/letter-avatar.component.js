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
// taken from https://github.com/rajan-g/angular2-letter-avatar/blob/master/directives/letter-avatar.directive.ts
var core_1 = require("@angular/core");
var LetterAvatarComponent = (function () {
    function LetterAvatarComponent(el) {
        this.background = 'red';
        this.fontSize = 49;
        this.padding = 28;
        this.letter = '?';
        this.size = 100;
        this.fontColor = '#FFFFFF';
        this.props = null;
        this._el = el.nativeElement;
    }
    LetterAvatarComponent.prototype.test = function () {
        this.generateLetter();
    };
    LetterAvatarComponent.prototype.generateLetter = function () {
        if (!this.avatarData) {
            throw Error('LetterAvatarComponent config not provided');
        }
        if (!this.avatarData.text) {
            this.avatarData.text = '?';
        }
        var size = this.avatarData && this.avatarData.size ? this.avatarData.size : 100;
        this.fontColor = this.avatarData.fontColor ? this.avatarData.fontColor : '#FFFFFF';
        var isSquare = this.avatarData && this.avatarData.isSquare ? true : false;
        var border = this.avatarData && this.avatarData.border ? this.avatarData.border : '1px solid #d3d3d3';
        var background = this.avatarData && this.avatarData.background ? this.avatarData.background : null;
        var text = this.avatarData && this.avatarData.text ? this.avatarData.text : null;
        this.background = background;
        var textArray = text.split(' ');
        var letter = textArray[0].substr(0, 1) + '' + (textArray.length > 1 ? textArray[1].substr(0, 1) : '');
        letter = letter.toUpperCase();
        this.fontSize = (39 * size) / 100;
        this.padding = (28 * size) / 100;
        this.letter = letter;
        this.size = size;
        this.props = {};
        this.props.size = size + 'px';
        this.props.lineheight = this.size + 'px';
        this.props.letter = letter;
        this.props.fontSize = this.fontSize + 'px';
        if (isSquare) {
            this.props.borderradius = '0%';
        }
        else {
            this.props.borderradius = '50%';
        }
        this.props.textalign = 'center';
        this.props.border = border;
        this.props.background = background;
        if (this.avatarData.fixedColor && !background) {
            this.props.background = background || this.colorize(letter);
        }
        else {
            this.props.background = background || this.getRandomColor();
        }
        return true;
    };
    ;
    LetterAvatarComponent.prototype.getRandomColor = function () {
        var letters = '0123456789ABCDEF'.split('');
        var color = '#';
        for (var i = 0; i < 6; i++) {
            color += letters[Math.floor(Math.random() * 16)];
        }
        return color;
    };
    LetterAvatarComponent.prototype.colorize = function (str) {
        var hash = 0;
        for (var i = 0; i < str.length; i++) {
            // tslint:disable-next-line:no-bitwise
            hash = str.charCodeAt(i++) + ((hash << 5) - hash);
        }
        ;
        var color = Math.floor(Math.abs((Math.sin(hash) * 10000) % 1 * 16777216)).toString(16);
        return '#' + Array(6 - color.length + 1).join('0') + color;
    };
    LetterAvatarComponent.prototype.ngOnInit = function () {
        this.generateLetter();
    };
    LetterAvatarComponent.prototype.ngOnChanges = function () {
        var args = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            args[_i] = arguments[_i];
        }
        this.generateLetter();
    };
    return LetterAvatarComponent;
}());
__decorate([
    core_1.Input('avatardata'),
    __metadata("design:type", Object)
], LetterAvatarComponent.prototype, "avatarData", void 0);
LetterAvatarComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'avatar',
        templateUrl: 'letter-avatar.html',
        changeDetection: core_1.ChangeDetectionStrategy.OnPush
    }),
    __metadata("design:paramtypes", [core_1.ElementRef])
], LetterAvatarComponent);
exports.LetterAvatarComponent = LetterAvatarComponent;

//# sourceMappingURL=letter-avatar.component.js.map
