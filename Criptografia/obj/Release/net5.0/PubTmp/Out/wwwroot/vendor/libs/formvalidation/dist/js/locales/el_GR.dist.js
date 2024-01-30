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

/***/ "./wwwroot/vendor/libs/formvalidation/dist/js/locales/el_GR.js":
/*!*********************************************************************!*\
  !*** ./wwwroot/vendor/libs/formvalidation/dist/js/locales/el_GR.js ***!
  \*********************************************************************/
/***/ (function(module, exports, __webpack_require__) {

eval("var __WEBPACK_AMD_DEFINE_FACTORY__, __WEBPACK_AMD_DEFINE_RESULT__;function _typeof(o) { \"@babel/helpers - typeof\"; return _typeof = \"function\" == typeof Symbol && \"symbol\" == typeof Symbol.iterator ? function (o) { return typeof o; } : function (o) { return o && \"function\" == typeof Symbol && o.constructor === Symbol && o !== Symbol.prototype ? \"symbol\" : typeof o; }, _typeof(o); }\n(function (global, factory) {\n  ( false ? 0 : _typeof(exports)) === 'object' && \"object\" !== 'undefined' ? module.exports = factory() :  true ? !(__WEBPACK_AMD_DEFINE_FACTORY__ = (factory),\n\t\t__WEBPACK_AMD_DEFINE_RESULT__ = (typeof __WEBPACK_AMD_DEFINE_FACTORY__ === 'function' ?\n\t\t(__WEBPACK_AMD_DEFINE_FACTORY__.call(exports, __webpack_require__, exports, module)) :\n\t\t__WEBPACK_AMD_DEFINE_FACTORY__),\n\t\t__WEBPACK_AMD_DEFINE_RESULT__ !== undefined && (module.exports = __WEBPACK_AMD_DEFINE_RESULT__)) : (0);\n})(this, function () {\n  'use strict';\n\n  /**\n   * Greek language package\n   * Translated by @pRieStaKos\n   */\n  var el_GR = {\n    base64: {\n      default: 'Παρακαλώ εισάγετε μια έγκυρη κωδικοποίηση base 64'\n    },\n    between: {\n      default: 'Παρακαλώ εισάγετε μια τιμή μεταξύ %s και %s',\n      notInclusive: 'Παρακαλώ εισάγετε μια τιμή μεταξύ %s και %s αυστηρά'\n    },\n    bic: {\n      default: 'Παρακαλώ εισάγετε έναν έγκυρο αριθμό BIC'\n    },\n    callback: {\n      default: 'Παρακαλώ εισάγετε μια έγκυρη τιμή'\n    },\n    choice: {\n      between: 'Παρακαλώ επιλέξτε %s - %s επιλογές',\n      default: 'Παρακαλώ εισάγετε μια έγκυρη τιμή',\n      less: 'Παρακαλώ επιλέξτε %s επιλογές στο ελάχιστο',\n      more: 'Παρακαλώ επιλέξτε %s επιλογές στο μέγιστο'\n    },\n    color: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο χρώμα'\n    },\n    creditCard: {\n      default: 'Παρακαλώ εισάγετε έναν έγκυρο αριθμό πιστωτικής κάρτας'\n    },\n    cusip: {\n      default: 'Παρακαλώ εισάγετε έναν έγκυρο αριθμό CUSIP'\n    },\n    date: {\n      default: 'Παρακαλώ εισάγετε μια έγκυρη ημερομηνία',\n      max: 'Παρακαλώ εισάγετε ημερομηνία πριν από %s',\n      min: 'Παρακαλώ εισάγετε ημερομηνία μετά από %s',\n      range: 'Παρακαλώ εισάγετε ημερομηνία μεταξύ %s - %s'\n    },\n    different: {\n      default: 'Παρακαλώ εισάγετε μια διαφορετική τιμή'\n    },\n    digits: {\n      default: 'Παρακαλώ εισάγετε μόνο ψηφία'\n    },\n    ean: {\n      default: 'Παρακαλώ εισάγετε έναν έγκυρο αριθμό EAN'\n    },\n    ein: {\n      default: 'Παρακαλώ εισάγετε έναν έγκυρο αριθμό EIN'\n    },\n    emailAddress: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο email'\n    },\n    file: {\n      default: 'Παρακαλώ επιλέξτε ένα έγκυρο αρχείο'\n    },\n    greaterThan: {\n      default: 'Παρακαλώ εισάγετε μια τιμή μεγαλύτερη ή ίση με %s',\n      notInclusive: 'Παρακαλώ εισάγετε μια τιμή μεγαλύτερη από %s'\n    },\n    grid: {\n      default: 'Παρακαλώ εισάγετε έναν έγκυρο αριθμό GRId'\n    },\n    hex: {\n      default: 'Παρακαλώ εισάγετε έναν έγκυρο δεκαεξαδικό αριθμό'\n    },\n    iban: {\n      countries: {\n        AD: 'Ανδόρα',\n        AE: 'Ηνωμένα Αραβικά Εμιράτα',\n        AL: 'Αλβανία',\n        AO: 'Αγκόλα',\n        AT: 'Αυστρία',\n        AZ: 'Αζερμπαϊτζάν',\n        BA: 'Βοσνία και Ερζεγοβίνη',\n        BE: 'Βέλγιο',\n        BF: 'Μπουρκίνα Φάσο',\n        BG: 'Βουλγαρία',\n        BH: 'Μπαχρέιν',\n        BI: 'Μπουρούντι',\n        BJ: 'Μπενίν',\n        BR: 'Βραζιλία',\n        CH: 'Ελβετία',\n        CI: 'Ακτή Ελεφαντοστού',\n        CM: 'Καμερούν',\n        CR: 'Κόστα Ρίκα',\n        CV: 'Cape Verde',\n        CY: 'Κύπρος',\n        CZ: 'Δημοκρατία της Τσεχίας',\n        DE: 'Γερμανία',\n        DK: 'Δανία',\n        DO: 'Δομινικανή Δημοκρατία',\n        DZ: 'Αλγερία',\n        EE: 'Εσθονία',\n        ES: 'Ισπανία',\n        FI: 'Φινλανδία',\n        FO: 'Νησιά Φερόε',\n        FR: 'Γαλλία',\n        GB: 'Ηνωμένο Βασίλειο',\n        GE: 'Γεωργία',\n        GI: 'Γιβραλτάρ',\n        GL: 'Γροιλανδία',\n        GR: 'Ελλάδα',\n        GT: 'Γουατεμάλα',\n        HR: 'Κροατία',\n        HU: 'Ουγγαρία',\n        IE: 'Ιρλανδία',\n        IL: 'Ισραήλ',\n        IR: 'Ιράν',\n        IS: 'Ισλανδία',\n        IT: 'Ιταλία',\n        JO: 'Ιορδανία',\n        KW: 'Κουβέιτ',\n        KZ: 'Καζακστάν',\n        LB: 'Λίβανος',\n        LI: 'Λιχτενστάιν',\n        LT: 'Λιθουανία',\n        LU: 'Λουξεμβούργο',\n        LV: 'Λετονία',\n        MC: 'Μονακό',\n        MD: 'Μολδαβία',\n        ME: 'Μαυροβούνιο',\n        MG: 'Μαδαγασκάρη',\n        MK: 'πΓΔΜ',\n        ML: 'Μάλι',\n        MR: 'Μαυριτανία',\n        MT: 'Μάλτα',\n        MU: 'Μαυρίκιος',\n        MZ: 'Μοζαμβίκη',\n        NL: 'Ολλανδία',\n        NO: 'Νορβηγία',\n        PK: 'Πακιστάν',\n        PL: 'Πολωνία',\n        PS: 'Παλαιστίνη',\n        PT: 'Πορτογαλία',\n        QA: 'Κατάρ',\n        RO: 'Ρουμανία',\n        RS: 'Σερβία',\n        SA: 'Σαουδική Αραβία',\n        SE: 'Σουηδία',\n        SI: 'Σλοβενία',\n        SK: 'Σλοβακία',\n        SM: 'Σαν Μαρίνο',\n        SN: 'Σενεγάλη',\n        TL: 'Ανατολικό Τιμόρ',\n        TN: 'Τυνησία',\n        TR: 'Τουρκία',\n        VG: 'Βρετανικές Παρθένοι Νήσοι',\n        XK: 'Δημοκρατία του Κοσσυφοπεδίου'\n      },\n      country: 'Παρακαλώ εισάγετε έναν έγκυρο αριθμό IBAN στην %s',\n      default: 'Παρακαλώ εισάγετε έναν έγκυρο αριθμό IBAN'\n    },\n    id: {\n      countries: {\n        BA: 'Βοσνία και Ερζεγοβίνη',\n        BG: 'Βουλγαρία',\n        BR: 'Βραζιλία',\n        CH: 'Ελβετία',\n        CL: 'Χιλή',\n        CN: 'Κίνα',\n        CZ: 'Δημοκρατία της Τσεχίας',\n        DK: 'Δανία',\n        EE: 'Εσθονία',\n        ES: 'Ισπανία',\n        FI: 'Φινλανδία',\n        HR: 'Κροατία',\n        IE: 'Ιρλανδία',\n        IS: 'Ισλανδία',\n        LT: 'Λιθουανία',\n        LV: 'Λετονία',\n        ME: 'Μαυροβούνιο',\n        MK: 'Μακεδονία',\n        NL: 'Ολλανδία',\n        PL: 'Πολωνία',\n        RO: 'Ρουμανία',\n        RS: 'Σερβία',\n        SE: 'Σουηδία',\n        SI: 'Σλοβενία',\n        SK: 'Σλοβακία',\n        SM: 'Σαν Μαρίνο',\n        TH: 'Ταϊλάνδη',\n        TR: 'Τουρκία',\n        ZA: 'Νότια Αφρική'\n      },\n      country: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό ταυτότητας στην %s',\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό ταυτότητας'\n    },\n    identical: {\n      default: 'Παρακαλώ εισάγετε την ίδια τιμή'\n    },\n    imei: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό IMEI'\n    },\n    imo: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό IMO'\n    },\n    integer: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό'\n    },\n    ip: {\n      default: 'Παρακαλώ εισάγετε μία έγκυρη IP διεύθυνση',\n      ipv4: 'Παρακαλώ εισάγετε μία έγκυρη διεύθυνση IPv4',\n      ipv6: 'Παρακαλώ εισάγετε μία έγκυρη διεύθυνση IPv6'\n    },\n    isbn: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό ISBN'\n    },\n    isin: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό ISIN'\n    },\n    ismn: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό ISMN'\n    },\n    issn: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό ISSN'\n    },\n    lessThan: {\n      default: 'Παρακαλώ εισάγετε μια τιμή μικρότερη ή ίση με %s',\n      notInclusive: 'Παρακαλώ εισάγετε μια τιμή μικρότερη από %s'\n    },\n    mac: {\n      default: 'Παρακαλώ εισάγετε μία έγκυρη MAC διεύθυνση'\n    },\n    meid: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό MEID'\n    },\n    notEmpty: {\n      default: 'Παρακαλώ εισάγετε μια τιμή'\n    },\n    numeric: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο δεκαδικό αριθμό'\n    },\n    phone: {\n      countries: {\n        AE: 'Ηνωμένα Αραβικά Εμιράτα',\n        BG: 'Βουλγαρία',\n        BR: 'Βραζιλία',\n        CN: 'Κίνα',\n        CZ: 'Δημοκρατία της Τσεχίας',\n        DE: 'Γερμανία',\n        DK: 'Δανία',\n        ES: 'Ισπανία',\n        FR: 'Γαλλία',\n        GB: 'Ηνωμένο Βασίλειο',\n        IN: 'Ινδία',\n        MA: 'Μαρόκο',\n        NL: 'Ολλανδία',\n        PK: 'Πακιστάν',\n        RO: 'Ρουμανία',\n        RU: 'Ρωσία',\n        SK: 'Σλοβακία',\n        TH: 'Ταϊλάνδη',\n        US: 'ΗΠΑ',\n        VE: 'Βενεζουέλα'\n      },\n      country: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό τηλεφώνου στην %s',\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό τηλεφώνου'\n    },\n    promise: {\n      default: 'Παρακαλώ εισάγετε μια έγκυρη τιμή'\n    },\n    regexp: {\n      default: 'Παρακαλώ εισάγετε μια τιμή όπου ταιριάζει στο υπόδειγμα'\n    },\n    remote: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό'\n    },\n    rtn: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό RTN'\n    },\n    sedol: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό SEDOL'\n    },\n    siren: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό SIREN'\n    },\n    siret: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό SIRET'\n    },\n    step: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο βήμα από %s'\n    },\n    stringCase: {\n      default: 'Παρακαλώ εισάγετε μόνο πεζούς χαρακτήρες',\n      upper: 'Παρακαλώ εισάγετε μόνο κεφαλαία γράμματα'\n    },\n    stringLength: {\n      between: 'Παρακαλούμε, εισάγετε τιμή μεταξύ %s και %s μήκος χαρακτήρων',\n      default: 'Παρακαλώ εισάγετε μια τιμή με έγκυρο μήκος',\n      less: 'Παρακαλούμε εισάγετε λιγότερο από %s χαρακτήρες',\n      more: 'Παρακαλούμε εισάγετε περισσότερο από %s χαρακτήρες'\n    },\n    uri: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο URI'\n    },\n    uuid: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό UUID',\n      version: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό έκδοσης %s'\n    },\n    vat: {\n      countries: {\n        AT: 'Αυστρία',\n        BE: 'Βέλγιο',\n        BG: 'Βουλγαρία',\n        BR: 'Βραζιλία',\n        CH: 'Ελβετία',\n        CY: 'Κύπρος',\n        CZ: 'Δημοκρατία της Τσεχίας',\n        DE: 'Γερμανία',\n        DK: 'Δανία',\n        EE: 'Εσθονία',\n        EL: 'Ελλάδα',\n        ES: 'Ισπανία',\n        FI: 'Φινλανδία',\n        FR: 'Γαλλία',\n        GB: 'Ηνωμένο Βασίλειο',\n        GR: 'Ελλάδα',\n        HR: 'Κροατία',\n        HU: 'Ουγγαρία',\n        IE: 'Ιρλανδία',\n        IS: 'Ισλανδία',\n        IT: 'Ιταλία',\n        LT: 'Λιθουανία',\n        LU: 'Λουξεμβούργο',\n        LV: 'Λετονία',\n        MT: 'Μάλτα',\n        NL: 'Ολλανδία',\n        NO: 'Νορβηγία',\n        PL: 'Πολωνία',\n        PT: 'Πορτογαλία',\n        RO: 'Ρουμανία',\n        RS: 'Σερβία',\n        RU: 'Ρωσία',\n        SE: 'Σουηδία',\n        SI: 'Σλοβενία',\n        SK: 'Σλοβακία',\n        VE: 'Βενεζουέλα',\n        ZA: 'Νότια Αφρική'\n      },\n      country: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό ΦΠΑ στην %s',\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό ΦΠΑ'\n    },\n    vin: {\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο αριθμό VIN'\n    },\n    zipCode: {\n      countries: {\n        AT: 'Αυστρία',\n        BG: 'Βουλγαρία',\n        BR: 'Βραζιλία',\n        CA: 'Καναδάς',\n        CH: 'Ελβετία',\n        CZ: 'Δημοκρατία της Τσεχίας',\n        DE: 'Γερμανία',\n        DK: 'Δανία',\n        ES: 'Ισπανία',\n        FR: 'Γαλλία',\n        GB: 'Ηνωμένο Βασίλειο',\n        IE: 'Ιρλανδία',\n        IN: 'Ινδία',\n        IT: 'Ιταλία',\n        MA: 'Μαρόκο',\n        NL: 'Ολλανδία',\n        PL: 'Πολωνία',\n        PT: 'Πορτογαλία',\n        RO: 'Ρουμανία',\n        RU: 'Ρωσία',\n        SE: 'Σουηδία',\n        SG: 'Σιγκαπούρη',\n        SK: 'Σλοβακία',\n        US: 'ΗΠΑ'\n      },\n      country: 'Παρακαλώ εισάγετε ένα έγκυρο ταχυδρομικό κώδικα στην %s',\n      default: 'Παρακαλώ εισάγετε ένα έγκυρο ταχυδρομικό κώδικα'\n    }\n  };\n  return el_GR;\n});\n\n//# sourceURL=webpack://Materialize/./wwwroot/vendor/libs/formvalidation/dist/js/locales/el_GR.js?");

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
/******/ 	var __webpack_exports__ = __webpack_require__("./wwwroot/vendor/libs/formvalidation/dist/js/locales/el_GR.js");
/******/ 	
/******/ 	return __webpack_exports__;
/******/ })()
;
});