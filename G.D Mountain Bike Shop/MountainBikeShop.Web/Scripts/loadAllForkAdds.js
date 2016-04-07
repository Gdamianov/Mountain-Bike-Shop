jQuery(function () {
    $.getJSON("Forks/AllForkAdds", "", function (data) {
        $(data).each(function (index, element) {
            
            var $addDiv = $("<div>").attr("class", "add"),
                $header = $("<header>"),
                $section = $("<section>"),

                $brandModel = $("<h1>").text(element.Brand + " " + element.Model),
                $h2 = $("<h2>").text("Price: " + element.Price + " &#36"),
                $pInfo = $("<p>").html("Posted on: " + element.PostedOn + "by: <span class='glyphicon glyphicon-user' aria-hidden='true'></span>" + element.Username),
                $pMoreDetails = $("<p>");
                $anchor = $("<a>").text("More Details").attr("href", "Forks/Add/" + element.Id).attr("class", "btn btn-info");
                $header.append($brandModel);
                $section.append($h2);
                $section.append($pInfo);
                $pMoreDetails.append($anchor);
                $section.append($pMoreDetails);
            $addDiv.append($header);
            $addDiv.append($section);
            $(".adds-container").append($addDiv);
            
        })
    })
})