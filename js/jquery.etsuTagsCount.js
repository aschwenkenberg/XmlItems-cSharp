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

            }; // end defaults

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

        // works for all vlaues with one tag
        for (var i = 0; i < obj.TagTotals.length; i++) {

            var name = obj.TagTotals[i].Name;
            name = name.replace(/&amp;/g, '&');

            $("input[name='chk_tag'][value='" + name + "']").parent().append(' (' + obj.TagTotals[i].Total + ')');

        }

        // identify tag check boxes with commas in the value...
        //  split on comma
        // get each individual tag count , adding them togther

        var checkboxes_with_commas = $("input[name='chk_tag'][value*=',']");

        $.each(checkboxes_with_commas, function (index, current_checkbox) {
            var count = 0;

            var whole_value = $(current_checkbox).val();

            var split_values = whole_value.split(",");

            $.each(split_values, function (i, current_value) {

                var current_total = $.grep(obj.TagTotals, function (o) {
                    return o.Name === current_value;
                })[0].Total;

                console.log("current value : " + current_value + " , current total : " + current_total);

            });


        });


    }

})($);                 // end anonymous wrapper for etsuNews jQuery plugin