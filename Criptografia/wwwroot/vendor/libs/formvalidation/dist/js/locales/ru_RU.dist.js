/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
(function webpackUniversalModuleDefinition(root, factory) {
	if(typeof exports === 'object' && typeof module === 'object')
		module.exports = factory();
	else if(typeof define === 'function' && define.amd)
		define([], factory);
	else {
		var a = factory();
		for(var i in a) (typeof exports === 'object' ? exports : root)[i] = a[i];
	}
})(self, () => {
return /******/ (() => { // webpackBootstrap
/******/ 	var __webpack_modules__ = ({

/***/ "./wwwroot/vendor/libs/formvalidation/dist/js/locales/ru_RU.js":
/*!*********************************************************************!*\
  !*** ./wwwroot/vendor/libs/formvalidation/dist/js/locales/ru_RU.js ***!
  \*********************************************************************/
/***/ (function(module, exports, __webpack_require__) {

eval("var __WEBPACK_AMD_DEFINE_FACTORY__, __WEBPACK_AMD_DEFINE_RESULT__;function _typeof(o) { \"@babel/helpers - typeof\"; return _typeof = \"function\" == typeof Symbol && \"symbol\" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && \"function\" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? \"symbol\" : typeof o; }, _typeof(o); }\n(function (global, factory) {\n  ( false ? 0 : _typeof(exports)) === 'object' && \"object\" !== 'undefined' ? module.exports = factory() :  true ? !(__WEBPACK_AMD_DEFINE_FACTORY__ = (factory),\n\t\t__WEBPACK_AMD_DEFINE_RESULT__ = (typeof __WEBPACK_AMD_DEFINE_FACTORY__ === 'function' ?\n\t\t(__WEBPACK_AMD_DEFINE_FACTORY__.call(exports, __webpack_require__, exports, module)) :\n\t\t__WEBPACK_AMD_DEFINE_FACTORY__),\n\t\t__WEBPACK_AMD_DEFINE_RESULT__ !== undefined && (module.exports = __WEBPACK_AMD_DEFINE_RESULT__)) : (0);\n})(this, function () {\n  'use strict';\n\n  /**\n   * Russian language package\n   * Translated by @cylon-v. Improved by @stepin, @oleg-voloshyn\n   */\n  var ru_RU = {\n    base64: {\n      default: 'Пожалуйста, введите корректную строку base64'\n    },\n    between: {\n      default: 'Пожалуйста, введите значение от %s до %s',\n      notInclusive: 'Пожалуйста, введите значение между %s и %s'\n    },\n    bic: {\n      default: 'Пожалуйста, введите правильный номер BIC'\n    },\n    callback: {\n      default: 'Пожалуйста, введите корректное значение'\n    },\n    choice: {\n      between: 'Пожалуйста, выберите %s-%s опций',\n      default: 'Пожалуйста, введите корректное значение',\n      less: 'Пожалуйста, выберите хотя бы %s опций',\n      more: 'Пожалуйста, выберите не больше %s опций'\n    },\n    color: {\n      default: 'Пожалуйста, введите правильный номер цвета'\n    },\n    creditCard: {\n      default: 'Пожалуйста, введите правильный номер кредитной карты'\n    },\n    cusip: {\n      default: 'Пожалуйста, введите правильный номер CUSIP'\n    },\n    date: {\n      default: 'Пожалуйста, введите правильную дату',\n      max: 'Пожалуйста, введите дату перед %s',\n      min: 'Пожалуйста, введите дату после %s',\n      range: 'Пожалуйста, введите дату в диапазоне %s - %s'\n    },\n    different: {\n      default: 'Пожалуйста, введите другое значение'\n    },\n    digits: {\n      default: 'Пожалуйста, введите только цифры'\n    },\n    ean: {\n      default: 'Пожалуйста, введите правильный номер EAN'\n    },\n    ein: {\n      default: 'Пожалуйста, введите правильный номер EIN'\n    },\n    emailAddress: {\n      default: 'Пожалуйста, введите правильный адрес эл. почты'\n    },\n    file: {\n      default: 'Пожалуйста, выберите файл'\n    },\n    greaterThan: {\n      default: 'Пожалуйста, введите значение большее или равное %s',\n      notInclusive: 'Пожалуйста, введите значение больше %s'\n    },\n    grid: {\n      default: 'Пожалуйста, введите правильный номер GRId'\n    },\n    hex: {\n      default: 'Пожалуйста, введите правильное шестнадцатиричное число'\n    },\n    iban: {\n      countries: {\n        AD: 'Андорре',\n        AE: 'Объединённых Арабских Эмиратах',\n        AL: 'Албании',\n        AO: 'Анголе',\n        AT: 'Австрии',\n        AZ: 'Азербайджане',\n        BA: 'Боснии и Герцеговине',\n        BE: 'Бельгии',\n        BF: 'Буркина-Фасо',\n        BG: 'Болгарии',\n        BH: 'Бахрейне',\n        BI: 'Бурунди',\n        BJ: 'Бенине',\n        BR: 'Бразилии',\n        CH: 'Швейцарии',\n        CI: \"Кот-д'Ивуаре\",\n        CM: 'Камеруне',\n        CR: 'Коста-Рике',\n        CV: 'Кабо-Верде',\n        CY: 'Кипре',\n        CZ: 'Чешская республика',\n        DE: 'Германии',\n        DK: 'Дании',\n        DO: 'Доминикане Республика',\n        DZ: 'Алжире',\n        EE: 'Эстонии',\n        ES: 'Испании',\n        FI: 'Финляндии',\n        FO: 'Фарерских островах',\n        FR: 'Франции',\n        GB: 'Великобритании',\n        GE: 'Грузии',\n        GI: 'Гибралтаре',\n        GL: 'Гренландии',\n        GR: 'Греции',\n        GT: 'Гватемале',\n        HR: 'Хорватии',\n        HU: 'Венгрии',\n        IE: 'Ирландии',\n        IL: 'Израиле',\n        IR: 'Иране',\n        IS: 'Исландии',\n        IT: 'Италии',\n        JO: 'Иордании',\n        KW: 'Кувейте',\n        KZ: 'Казахстане',\n        LB: 'Ливане',\n        LI: 'Лихтенштейне',\n        LT: 'Литве',\n        LU: 'Люксембурге',\n        LV: 'Латвии',\n        MC: 'Монако',\n        MD: 'Молдове',\n        ME: 'Черногории',\n        MG: 'Мадагаскаре',\n        MK: 'Македонии',\n        ML: 'Мали',\n        MR: 'Мавритании',\n        MT: 'Мальте',\n        MU: 'Маврикии',\n        MZ: 'Мозамбике',\n        NL: 'Нидерландах',\n        NO: 'Норвегии',\n        PK: 'Пакистане',\n        PL: 'Польше',\n        PS: 'Палестине',\n        PT: 'Португалии',\n        QA: 'Катаре',\n        RO: 'Румынии',\n        RS: 'Сербии',\n        SA: 'Саудовской Аравии',\n        SE: 'Швеции',\n        SI: 'Словении',\n        SK: 'Словакии',\n        SM: 'Сан-Марино',\n        SN: 'Сенегале',\n        TL: 'Восточный Тимор',\n        TN: 'Тунисе',\n        TR: 'Турции',\n        VG: 'Британских Виргинских островах',\n        XK: 'Республика Косово'\n      },\n      country: 'Пожалуйста, введите правильный номер IBAN в %s',\n      default: 'Пожалуйста, введите правильный номер IBAN'\n    },\n    id: {\n      countries: {\n        BA: 'Боснии и Герцеговине',\n        BG: 'Болгарии',\n        BR: 'Бразилии',\n        CH: 'Швейцарии',\n        CL: 'Чили',\n        CN: 'Китае',\n        CZ: 'Чешская республика',\n        DK: 'Дании',\n        EE: 'Эстонии',\n        ES: 'Испании',\n        FI: 'Финляндии',\n        HR: 'Хорватии',\n        IE: 'Ирландии',\n        IS: 'Исландии',\n        LT: 'Литве',\n        LV: 'Латвии',\n        ME: 'Черногории',\n        MK: 'Македонии',\n        NL: 'Нидерландах',\n        PL: 'Польше',\n        RO: 'Румынии',\n        RS: 'Сербии',\n        SE: 'Швеции',\n        SI: 'Словении',\n        SK: 'Словакии',\n        SM: 'Сан-Марино',\n        TH: 'Тайланде',\n        TR: 'Турции',\n        ZA: 'ЮАР'\n      },\n      country: 'Пожалуйста, введите правильный идентификационный номер в %s',\n      default: 'Пожалуйста, введите правильный идентификационный номер'\n    },\n    identical: {\n      default: 'Пожалуйста, введите такое же значение'\n    },\n    imei: {\n      default: 'Пожалуйста, введите правильный номер IMEI'\n    },\n    imo: {\n      default: 'Пожалуйста, введите правильный номер IMO'\n    },\n    integer: {\n      default: 'Пожалуйста, введите правильное целое число'\n    },\n    ip: {\n      default: 'Пожалуйста, введите правильный IP-адрес',\n      ipv4: 'Пожалуйста, введите правильный IPv4-адрес',\n      ipv6: 'Пожалуйста, введите правильный IPv6-адрес'\n    },\n    isbn: {\n      default: 'Пожалуйста, введите правильный номер ISBN'\n    },\n    isin: {\n      default: 'Пожалуйста, введите правильный номер ISIN'\n    },\n    ismn: {\n      default: 'Пожалуйста, введите правильный номер ISMN'\n    },\n    issn: {\n      default: 'Пожалуйста, введите правильный номер ISSN'\n    },\n    lessThan: {\n      default: 'Пожалуйста, введите значение меньшее или равное %s',\n      notInclusive: 'Пожалуйста, введите значение меньше %s'\n    },\n    mac: {\n      default: 'Пожалуйста, введите правильный MAC-адрес'\n    },\n    meid: {\n      default: 'Пожалуйста, введите правильный номер MEID'\n    },\n    notEmpty: {\n      default: 'Пожалуйста, введите значение'\n    },\n    numeric: {\n      default: 'Пожалуйста, введите корректное действительное число'\n    },\n    phone: {\n      countries: {\n        AE: 'Объединённых Арабских Эмиратах',\n        BG: 'Болгарии',\n        BR: 'Бразилии',\n        CN: 'Китае',\n        CZ: 'Чешская республика',\n        DE: 'Германии',\n        DK: 'Дании',\n        ES: 'Испании',\n        FR: 'Франции',\n        GB: 'Великобритании',\n        IN: 'Индия',\n        MA: 'Марокко',\n        NL: 'Нидерландах',\n        PK: 'Пакистане',\n        RO: 'Румынии',\n        RU: 'России',\n        SK: 'Словакии',\n        TH: 'Тайланде',\n        US: 'США',\n        VE: 'Венесуэле'\n      },\n      country: 'Пожалуйста, введите правильный номер телефона в %s',\n      default: 'Пожалуйста, введите правильный номер телефона'\n    },\n    promise: {\n      default: 'Пожалуйста, введите корректное значение'\n    },\n    regexp: {\n      default: 'Пожалуйста, введите значение соответствующее шаблону'\n    },\n    remote: {\n      default: 'Пожалуйста, введите правильное значение'\n    },\n    rtn: {\n      default: 'Пожалуйста, введите правильный номер RTN'\n    },\n    sedol: {\n      default: 'Пожалуйста, введите правильный номер SEDOL'\n    },\n    siren: {\n      default: 'Пожалуйста, введите правильный номер SIREN'\n    },\n    siret: {\n      default: 'Пожалуйста, введите правильный номер SIRET'\n    },\n    step: {\n      default: 'Пожалуйста, введите правильный шаг %s'\n    },\n    stringCase: {\n      default: 'Пожалуйста, вводите только строчные буквы',\n      upper: 'Пожалуйста, вводите только заглавные буквы'\n    },\n    stringLength: {\n      between: 'Пожалуйста, введите строку длиной от %s до %s символов',\n      default: 'Пожалуйста, введите значение корректной длины',\n      less: 'Пожалуйста, введите не больше %s символов',\n      more: 'Пожалуйста, введите не меньше %s символов'\n    },\n    uri: {\n      default: 'Пожалуйста, введите правильный URI'\n    },\n    uuid: {\n      default: 'Пожалуйста, введите правильный номер UUID',\n      version: 'Пожалуйста, введите правильный номер UUID версии %s'\n    },\n    vat: {\n      countries: {\n        AT: 'Австрии',\n        BE: 'Бельгии',\n        BG: 'Болгарии',\n        BR: 'Бразилии',\n        CH: 'Швейцарии',\n        CY: 'Кипре',\n        CZ: 'Чешская республика',\n        DE: 'Германии',\n        DK: 'Дании',\n        EE: 'Эстонии',\n        EL: 'Греции',\n        ES: 'Испании',\n        FI: 'Финляндии',\n        FR: 'Франции',\n        GB: 'Великобритании',\n        GR: 'Греции',\n        HR: 'Хорватии',\n        HU: 'Венгрии',\n        IE: 'Ирландии',\n        IS: 'Исландии',\n        IT: 'Италии',\n        LT: 'Литве',\n        LU: 'Люксембурге',\n        LV: 'Латвии',\n        MT: 'Мальте',\n        NL: 'Нидерландах',\n        NO: 'Норвегии',\n        PL: 'Польше',\n        PT: 'Португалии',\n        RO: 'Румынии',\n        RS: 'Сербии',\n        RU: 'России',\n        SE: 'Швеции',\n        SI: 'Словении',\n        SK: 'Словакии',\n        VE: 'Венесуэле',\n        ZA: 'ЮАР'\n      },\n      country: 'Пожалуйста, введите правильный номер ИНН (VAT) в %s',\n      default: 'Пожалуйста, введите правильный номер ИНН'\n    },\n    vin: {\n      default: 'Пожалуйста, введите правильный номер VIN'\n    },\n    zipCode: {\n      countries: {\n        AT: 'Австрии',\n        BG: 'Болгарии',\n        BR: 'Бразилии',\n        CA: 'Канаде',\n        CH: 'Швейцарии',\n        CZ: 'Чешская республика',\n        DE: 'Германии',\n        DK: 'Дании',\n        ES: 'Испании',\n        FR: 'Франции',\n        GB: 'Великобритании',\n        IE: 'Ирландии',\n        IN: 'Индия',\n        IT: 'Италии',\n        MA: 'Марокко',\n        NL: 'Нидерландах',\n        PL: 'Польше',\n        PT: 'Португалии',\n        RO: 'Румынии',\n        RU: 'России',\n        SE: 'Швеции',\n        SG: 'Сингапуре',\n        SK: 'Словакии',\n        US: 'США'\n      },\n      country: 'Пожалуйста, введите правильный почтовый индекс в %s',\n      default: 'Пожалуйста, введите правильный почтовый индекс'\n    }\n  };\n  return ru_RU;\n});\n\n//# sourceURL=webpack://Materialize/./wwwroot/vendor/libs/formvalidation/dist/js/locales/ru_RU.js?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module is referenced by other modules so it can't be inlined
/******/ 	var __webpack_exports__ = __webpack_require__("./wwwroot/vendor/libs/formvalidation/dist/js/locales/ru_RU.js");
/******/ 	
/******/ 	return __webpack_exports__;
/******/ })()
;
});