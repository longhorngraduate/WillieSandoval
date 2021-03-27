//1.  Find the browser name:
function getBrowserName() {
    var result;
    //UPDATE 4/18/2018  -   https://stackoverflow.com/questions/4565112/javascript-how-to-find-out-if-the-user-browser-is-chrome/13348618#13348618:
    // please note, 
    // that IE11 now returns undefined again for window.chrome
    // and new Opera 30 outputs true for window.chrome
    // but needs to check if window.opr is not undefined
    // and new IE Edge outputs to true now for window.chrome
    // and if not iOS Chrome check
    // so use the below updated condition
    var isChromium = window.chrome;
    var winNav = window.navigator;
    var vendorName = winNav.vendor;
    var isOpera = typeof window.opr !== "undefined";
    var isIEedge = winNav.userAgent.indexOf("Edge") > -1;
    var isIOSChrome = winNav.userAgent.match("CriOS");

    if (isIOSChrome) {
        // is Google Chrome on IOS
        result = "Chrome";
    } else if (
        isChromium !== null &&
        typeof isChromium !== "undefined" &&
        vendorName === "Google Inc." &&
        isOpera === false &&
        isIEedge === false
    ) {
        // is Google Chrome
        result = "Chrome";
    } else if (isIEedge) {
        result = "IEedge";
    } else {
        // not Google Chrome 
        result = "not Chrome";
    }

    return result;
}



//2.  exit function with async for Google and sync for everything else:
function exit() {
    var browser_name = getBrowserName();
    if (browser_name == "Chrome") {
        jQuery.ajax({
            type: "POST",
            url: strSecureRootPath + "/myAjaxClass.aspx/obfuscateExitFunction",
            contentType: 'application/json',
            dataType: "json",
            cache: false,
            data: "{ 'someGuid': '" + gvarsomeGuid + "', " +
                "'ReadOnly': '" + ReadOnly + "'" +
                "}"
        });
    }
    else {
        //Must use "async: false"
        jQuery.ajax({
            type: "POST",
            async: false,
            url: strSecureRootPath + "/myAjaxClass.aspx/obfuscateExitFunction",
            contentType: 'application/json',
            dataType: "json",
            cache: false,
            data: "{ 'someGuid': '" + gvarsomeGuid + "', " +
                "'ReadOnly': '" + ReadOnly + "'" +
                "}"
        });
    }

    parentWindowRefresh();
}

function parentWindowRefresh() {
    if (typeof window.opener == 'undefined') {
        window.location.href = "ParentPageName.aspx?someGuid=" + gvarsomeGuid;
    }
    else if (window.opener.closed) {
        window.location.href = "ParentPageName.aspx?someGuid=" + gvarsomeGuid;
    }
    else {
        window.opener.location.href = "ParentPageName.aspx?someGuid=" + gvarsomeGuid;
        window.close();
    }
}