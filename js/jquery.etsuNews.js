(function ($) {

    $.fn.extend({
        // plugin name 'etsuNews' - a function that accepts an options object
        etsuNews: function (options) {

            var defaults = {

                url: "news_handler.ashx",
                feed: "rss/news2012.xml",
                xpath: "/rss/channel/item",
                quantity: "4",
                displayMethod: "rss_sample_2",
                tags: "all",
                colleges: "all",
                categories: "all",
                callback: function (obj, data) { $(obj).html(data); }

            };// end defaults

            var options = $.extend(defaults, options);

            // for each DOM element returned by the selector 
            return this.each(function () {
                var o = options;
                var params_to_send = { feed: o.feed, xpath: o.xpath, quantity: o.quantity, displayMethod: o.displayMethod, categories: o.categories, colleges: o.colleges, tags: o.tags, start: o.start, end: o.end };
                var obj = $(this);

                $.ajax({
                    url: o.url,
                    data: params_to_send,
                    contentType: "text/plain",
                    success: function (data) { o.callback(obj, data); }
                });


            }); // end this.each

        } // end etsuNews

    }); // end fn.extend

})($); // end anonymous wrapper for etsuNews jQuery plugin