function initNews() {

    $('#newslisting').etsuNews({
        quantity: OUC.custom_news.quantity,
        feed: OUC.custom_news.feed,
        displayMethod: OUC.custom_news.displayMethod,
        categories: OUC.custom_news.categories,
        colleges: OUC.custom_news.colleges,
        tags: OUC.custom_news.tags,
        start: OUC.custom_news.start,
        end: OUC.custom_news.end
    });
    return false;
}
function bindNewsFilterControls(){

$(".custom_news_category_link").click(function (e) {
    e.preventDefault();
    var val = $(this).attr('id');

    OUC.custom_news.categories = "";
    OUC.custom_news.categories = val;
    if (OUC.custom_news.remember == true) {
        //setCookie('custom_news_remember_tags', OUC.custom_news.tags, 365);
    }
    initNews();
    return false;
});


$('#from').bind('change', function (e) {
    var val = $(this).val();
    OUC.custom_news.start = "";
    OUC.custom_news.start = val;
    initNews();
    return false;
});

$('#to').bind('change', function (e) {
    var val = $(this).val();
    OUC.custom_news.end = "";
    OUC.custom_news.end = val;
    initNews();
    return false;
});


   $('input[name="chk_tag"]').bind('change', function (e) {
        //OUC.custom_news.start = 0;
        //deleteCookie('custom_news_remember_tags');
        OUC.custom_news.tags = "";
        $('input[name="chk_tag"]:checked').each(function (index) {
            if (index != 0) {
                OUC.custom_news.tags += ",";
            }
            OUC.custom_news.tags += $(this).val();
        });
        if (OUC.custom_news.remember == true) {
            //setCookie('custom_news_remember_tags', OUC.custom_news.tags, 365);
        }
        initNews();
    });


$('input[name="chk_college"]').bind('change', function (e) {
        //OUC.custom_news.start = 0;
        //deleteCookie('custom_news_remember_colleges');
        OUC.custom_news.colleges = "";
        $('input[name="chk_college"]:checked').each(function (index) {
            if (index != 0) {
                OUC.custom_news.colleges += ",";
            }
            OUC.custom_news.colleges += $(this).val();
        });
        if (OUC.custom_news.remember == true) {
            //setCookie('custom_news_remember_colleges', OUC.custom_news.colleges, 365);
        }
        initNews();
    });
} // end Bind Controls

function getCookie(c_name) {
    var i, x, y, ARRcookies = document.cookie.split(";");
    for (i = 0; i < ARRcookies.length; i++) {
        x = ARRcookies[i].substr(0, ARRcookies[i].indexOf("="));
        y = ARRcookies[i].substr(ARRcookies[i].indexOf("=") + 1);
        x = x.replace(/^\s+|\s+$/g, "");
        if (x == c_name) {
            return unescape(y);
        }
    }
}

function setCookie(c_name, value, exdays) {
    var exdate = new Date();
    exdate.setDate(exdate.getDate() + exdays);
    var c_value = escape(value) + ((exdays == null) ? "" : "; expires=" + exdate.toUTCString());
    document.cookie = c_name + "=" + c_value;
}
function deleteCookie(c_name) {
    document.cookie = encodeURIComponent(c_name) + "=deleted; expires=" + new Date(0).toUTCString();
}
function checkCookie(_cookie_name) {
    var cookie_name = getCookie(_cookie_name);
    if (cookie_name != null && cookie_name != "") {
        return true;
    } else {
        return false;
    }
}