(function ($) {

    $.fn.extend({
        // plugin name 'etsuTagsCount' - a function that accepts an options object
        etsuTagsCount: function (options) {

            var tags = "";
            $('input[name="chk_tag"]').each(function (index) {
                if (index != 0) {
                    tags += ",";
                }
                tags += $(this).val();
            });

            var defaults = {

                url: "tags_count_handler.ashx",
                feed: "rss/news2012.xml",
                xpath: "/rss/channel/item",             
                
                callback: function (obj, data) { $(obj).html(data); }

            };// end defaults

            var options = $.extend(defaults, options);

            // for each DOM element returned by the selector 
            return this.each(function () {
                var o = options;
                var params_to_send = { url: o.url, feed: o.feed, xpath: o.xpath, tags: tags };
                var obj = $(this);

                $.ajax({
                    url: o.url,
                    data: params_to_send,
                    contentType: "text/plain",
                    success: function (data) {
                        o.callback(obj, data);
                        displayTagsCount(data);
                    }
                });


            }); // end this.each

        } // end etsuTagsCount

    }); // end fn.extend


    //TagsCount Display Function appending count to input field
    function displayTagsCount(jsonResultObject) {

        obj = JSON.parse(jsonResultObject);

        for (var i = 0; i < obj.TagTotals.length; i++) {

            var name = obj.TagTotals[i].Name;
            name = name.replace(/&amp;/g, '&');

            $("input[name='chk_tag'][value='" + name + "']").parent().append(' (' + obj.TagTotals[i].Total + ')');

        }
    }

})($); // end anonymous wrapper for etsuNews jQuery plugin